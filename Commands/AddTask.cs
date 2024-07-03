
using DesignPatterns_Labb1.Managers;
using DesignPatterns_Labb1.Models;

namespace DesignPatterns_Labb1.Commands
{
	//A concrete command that adds a task to TaskManager
	public class AddTask : ICommand
	{
		private readonly TaskManager _taskManager;
		private readonly ToDoTask _task;

		public AddTask(TaskManager taskManager, ToDoTask task)
		{
			_taskManager = taskManager;
			_task = task;
		}

		public void Execute()
		{
			_taskManager.AddTask(_task);
		}
	}
}
