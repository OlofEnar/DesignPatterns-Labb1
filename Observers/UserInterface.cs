using System;
using System.Collections.Generic;
using DesignPatterns_Labb1.Models;

namespace DesignPatterns_Labb1.Observers
{
	//The UserInterface class implements the
	//IObserver interface and updates the displayed tasks when its
	//Update method is called.

	public class UserInterface : IObserver
	{
		private List<ToDoTask> _tasks;

		public void Update(List<ToDoTask> tasks)
		{
			_tasks = tasks;
			DisplayTasks();
		}

		public void MainScreen()
		{
			DisplayHeader();
			DisplayTasks();
		}

		private static void DisplayHeader()
		{
			Console.Clear();
			Console.WriteLine("*********************************");
			Console.WriteLine("*      LET'S GET STUFF DONE     *");
			Console.WriteLine("*********************************");
		}

		private void DisplayTasks()
		{
			Console.WriteLine("*  Todo                         *");
			Console.WriteLine("---------------------------------");
			if (_tasks != null && _tasks.Count > 0)
			{
				for (int i = 0; i < _tasks.Count; i++)
				{
					var task = _tasks[i];
					var status = task.IsCompleted ? "DONE!" : "";
					Console.WriteLine($"{i + 1}. {task.TaskName} {status}");
				}
			}
			else
			{
				Console.WriteLine("No tasks to display.");
			}
		}

		public void DisplayMenu()
		{
			Console.WriteLine("\n\n\n");
			Console.WriteLine("Menu:");
			Console.WriteLine("[a] Add a task");
			Console.WriteLine("[r] Remove a task");
			Console.WriteLine("[c] Mark a task as completed");
			Console.WriteLine("[q] Quit");
			Console.Write("Select an option: ");
		}

		public string GetTaskName()
		{
			Console.WriteLine("Enter the task name:");
			return Console.ReadLine();
		}

		public int GetTaskNumber()
		{
			Console.WriteLine("Enter the task number:");
			if (int.TryParse(Console.ReadLine(), out var taskNumber))
			{
				return taskNumber;
			}
			return -1; // Indicating invalid input
		}
	}
}
