namespace MVC_DependencyInjectionSamples.Services
{
    public class TimeService : ITimeService
    {
        string currentTime = string.Empty;

        public TimeService()
        {
            currentTime = DateTime.Now.ToString();
        }
        public string GetCurrentTime()
        {
            return currentTime;
        }
    }
}
