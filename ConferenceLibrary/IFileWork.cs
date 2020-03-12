namespace ConferenceLibrary
{
    public interface IFileWork
    {
        void ReadFromFile(string filePath);
        void WriteToFile(string filePath);
    }
}
