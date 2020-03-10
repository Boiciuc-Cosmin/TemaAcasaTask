namespace Task
{
    public interface IFileWork
    {
        public void ReadFromFile(string filePath);
        public void WriteToFile(string filePath);
    }
}
