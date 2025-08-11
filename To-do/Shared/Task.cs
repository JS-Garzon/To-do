using To_do.Interfaces;

namespace To_do.Shared
{
    public class Task : ITask
    {
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public int TaskId { get; set; }
        public string TaskStatus { get; set; }
    }
}
