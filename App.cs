using System;
using DesignPatterns_Labb1.Commands;
using DesignPatterns_Labb1.Managers;
using DesignPatterns_Labb1.Models;
using DesignPatterns_Labb1.Observers;

namespace DesignPatterns_Labb1
{
	internal class App
	{
		// Singleton pattern: Ensuring a single instance of TaskManager
		private TaskManager _taskManager = TaskManager.Instance;

		// Observer pattern: UserInterface observing TaskManager for changes
		private UserInterface _ui = new();

		public void Run()
		{
			// Observer pattern: Registering UserInterface as an observer of TaskManager
			_taskManager.AddObserver(_ui);
			InitializeData();
			MainLoop();
		}

		private void InitializeData()
		{
			var task1 = new ToDoTask("Go running");
			var task2 = new ToDoTask("Feed the cats");

			// Command pattern: Encapsulating actions to add and complete tasks
			_taskManager.AddTask(task1);
			_taskManager.AddTask(task2);
			_taskManager.CompleteTask(task2);
		}

		private void MainLoop()
		{
			bool running = true;
			while (running)
			{
				_ui.MainScreen();
				_ui.DisplayMenu();
				var input = Console.ReadLine().ToLower();

				// Handling user input to execute commands
				switch (input)
				{
					case "a":
						AddTask();
						break;
					case "r":
						RemoveTask();
						break;
					case "c":
						CompleteTask();
						break;
					case "q":
						running = false;
						break;
					default:
						Console.WriteLine("Invalid option. Please try again.");
						break;
				}
			}
		}

		private void AddTask()
		{
			var taskName = _ui.GetTaskName();
			if (!string.IsNullOrWhiteSpace(taskName))
			{
				var newTask = new ToDoTask(taskName);
				// Command pattern: Encapsulating the action to add a task
				_taskManager.AddTask(newTask);
			}
			else
			{
				Console.WriteLine("Task name cannot be empty.");
			}
		}

		private void RemoveTask()
		{
			var taskNumber = _ui.GetTaskNumber();
			if (taskNumber > 0 && taskNumber <= _taskManager.Tasks.Count)
			{
				var taskToRemove = _taskManager.Tasks[taskNumber - 1];
				// Command pattern: Encapsulating the action to remove a task
				_taskManager.RemoveTask(taskToRemove);
			}
			else
			{
				Console.WriteLine("Invalid task number. Please try again.");
			}
		}

		private void CompleteTask()
		{
			var taskNumber = _ui.GetTaskNumber();
			if (taskNumber > 0 && taskNumber <= _taskManager.Tasks.Count)
			{
				var taskToComplete = _taskManager.Tasks[taskNumber - 1];
				// Command pattern: Encapsulating the action to complete a task
				_taskManager.CompleteTask(taskToComplete);
			}
			else
			{
				Console.WriteLine("Invalid task number. Please try again.");
			}
		}
	}
}
