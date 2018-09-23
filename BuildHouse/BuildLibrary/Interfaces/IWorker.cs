namespace BuildLibrary.Interfaces
{
    internal interface IWorker
    {
        string Name { get; set; }
        string Position { get; }

        bool CheckWork(IPart obj);
    }
}
