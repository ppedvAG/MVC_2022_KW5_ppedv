namespace GeoRelationSample.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }


        #region Navigation 
        public virtual ICollection<LanguageInCountry> LanguageInCountriesRef { get; set; }
        #endregion
    }
}
