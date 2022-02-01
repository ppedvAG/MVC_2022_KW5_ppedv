namespace KonfigurationSampleApp.Models
{
    public class ArrayExample
    {
        //public string[] Entries { get; set; } = new string[] { "", "" }; -> wäre ein Bug 
        public string[] Entries { get; set; } = default!;
    }
}
