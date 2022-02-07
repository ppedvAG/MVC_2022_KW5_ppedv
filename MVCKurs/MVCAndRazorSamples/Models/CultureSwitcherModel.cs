#nullable disable
using System.Globalization;

namespace MVCAndRazorSamples.Models
{
    public class CultureSwitcherModel
    {
        public CultureInfo CurrentUICulture { get;set; }

        public List<CultureInfo> SupportedCultures { get; set; }
    }
}
