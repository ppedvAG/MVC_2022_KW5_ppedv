namespace MVCAndRazorSamples.Services
{
    public class TimeService : ITimeService
    {
        public string CurrentTime()
        {
            return DateTime.Now.ToString();
        }
    }
}
