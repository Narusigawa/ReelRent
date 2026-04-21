using System.Collections.Generic;

namespace ReelRent
{
    public class FilterCriteria
    {
        public string Title { get; set; } = "";
        public int? YearFrom { get; set; }
        public int? YearTo { get; set; }
        public List<string> Genres { get; set; } = new List<string>();
        public List<string> MediaFormats { get; set; } = new List<string>();
        public string Director { get; set; } = "";
        public string Actors { get; set; } = "";
        public string AgeRating { get; set; } = "";
    }
}