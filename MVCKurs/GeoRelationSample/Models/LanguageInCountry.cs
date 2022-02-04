namespace GeoRelationSample.Models
{
    public class LanguageInCountry
    {
        public int Id { get; set; }
        public int Percent { get; set; }

        public int LanguageId { get; set; }
        public int CountryId { get; set; }


        #region Navigations
        public virtual Country CountryRef { get; set; }
        public virtual Language Languages { get; set; }
        #endregion
    }
}