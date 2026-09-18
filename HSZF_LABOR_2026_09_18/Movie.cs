using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HSZF_LABOR_2026_09_18
{
    internal class Movie
    {
        [JsonInclude]
        public string Title { get; private set; }
        [JsonInclude]
        public int Minutes { get; private set; }
        [JsonInclude] 
        public DateTime? ReleaseDate { get; private set; }
        [JsonConstructor]
        public Movie(string title, int minutes, DateTime? releaseDate)
        {
            Title = title;
            Minutes = minutes;
            ReleaseDate = releaseDate;
        }

        public override string ToString()
        {
            return $"{this.Title}\t{this.Minutes}\t{this.ReleaseDate?.Date.ToString("yyyy.MM.dd")}";
        }
    }
}
