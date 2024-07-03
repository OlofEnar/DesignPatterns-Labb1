using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
using DesignPatterns_Labb1.Models;
using DesignPatterns_Labb1.Observers;

namespace DesignPatterns_Labb1.Managers
{
	// TaskManager is using Singleton to ensure
	// only one instance is being used across the app

	// The TaskManager class maintains a list of tasks and a list of observers.
	// When the state of the tasks changes (for example a task is added or removed,
	// it calls NotifyObservers(), which iterates through
	// the list of observers and calls their Update method.

	public class TaskManager
	{
		private static TaskManager _instance;
		private List<ToDoTask> _tasks = new();
		private List<IObserver> _observers = new();

		private TaskManager() { }

		// If a instance is already created, return it.
		// Otherwise create one. 
		public static TaskManager Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new TaskManager();
				}
				return _instance;
			}
		}

		public List<ToDoTask> Tasks => _tasks;

		public void AddTask(ToDoTask task)
		{
			_tasks.Add(task);
			NotifyObservers();
		}

		public void RemoveTask(ToDoTask task)
		{
			_tasks.Remove(task);
			NotifyObservers();
		}

		public void CompleteTask(ToDoTask task)
		{
			task.IsCompleted = true;
			NotifyObservers();
		}

		public void AddObserver(IObserver observer)
		{
			_observers.Add(observer);
		}

		private void NotifyObservers()
		{
			foreach (var observer in _observers)
			{
				observer.Update(_tasks);
			}
		}
	}
}