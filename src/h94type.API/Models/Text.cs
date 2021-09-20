using System;

namespace h94type.API.Models
{
    public class Text
    {
        public Guid Id { get; set; }
        public string Word { get; set; }
        public string Translation { get; set; }
        public bool Star { get; set; } = false;
        public Guid GenreId { get; set; }
        public Genre Genre { get; set; }
        public bool IsActive {get; set;} = true;
    }
}