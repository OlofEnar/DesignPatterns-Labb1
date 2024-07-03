
namespace DesignPatterns_Labb1.Models
{
    public class ToDoTask
    {
        public string TaskName { get; set; }
        public bool IsCompleted { get; set; } = false;

        public ToDoTask(string taskName)
        {
            TaskName = taskName;
        }
    }
}
