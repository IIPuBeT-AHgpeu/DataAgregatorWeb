namespace DataAgregatorWeb.Services
{
    public interface ISimpleLogger
    {
        public void Log(LogLevel level, string message);
        public void LogToFile(LogLevel level, string message, string path);
    }
}
