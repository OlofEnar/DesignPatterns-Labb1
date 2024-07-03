using DesignPatterns_Labb1.Models;

namespace DesignPatterns_Labb1.Observers
{
	// The IObserver interface is defined to
	// ensure that any observer has an Update
	// method that gets called when the subject's state changes.

	public interface IObserver
	{
		public void Update(List<ToDoTask> tasks);
	}
}