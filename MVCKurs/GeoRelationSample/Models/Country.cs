namespace GeoRelationSample.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }

        public string Capital { get; set; }

        public int ContinentId { get; set; } // Das geht in die DB  -> Stellt die Relation 

        #region Navigation
        public virtual Continent ContinentRef { get; set; } //Navigation mithilfe von Lazy Loading 
        public virtual ICollection<LanguageInCountry> LanguagesInCountryRef { get; set; }
        #endregion
    }
}
