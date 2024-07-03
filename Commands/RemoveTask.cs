using DesignPatterns_Labb1.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns_Labb1.Models;

namespace DesignPatterns_Labb1.Commands
{
	public class RemoveTaskCommand : ICommand
	{
		private TaskManager _taskManager;
		private ToDoTask _task;

		public RemoveTaskCommand(TaskManager taskManager, ToDoTask task)
		{
			_taskManager = taskManager;
			_task = task;
		}

		public void Execute()
		{
			_taskManager.RemoveTask(_task);
		}
	}
}
