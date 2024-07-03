using DesignPatterns_Labb1.Managers;
using DesignPatterns_Labb1.Models;

namespace DesignPatterns_Labb1.Commands
{
	public class CompleteTask : ICommand
	{
		private readonly TaskManager _taskManager;
		private readonly ToDoTask _task;

		public CompleteTask(TaskManager taskManager, ToDoTask task)
		{
			_taskManager = taskManager;
			_task = task;
		}

		public void Execute()
		{
			_taskManager.CompleteTask(_task);
		}
	}
}
