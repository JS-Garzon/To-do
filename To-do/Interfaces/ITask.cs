namespace To_do.Interfaces
{
    public interface ITask
    {
        string TaskName { get; set; }
        string TaskDescription { get; set; }
        int TaskId { get; set; }
        string TaskStatus { get; set; }
    }
}
