using System;
using h94type.API.Models;

namespace h94type.API.Dtos
{
    public class TextViewModel
    {
        public Guid Id { get; set; }
        public string Word { get; set; }
        public string Translation { get; set; }
        public string Genre { get; set; }
        public bool Star { get; set; }
        public bool IsActive { get; set; }
    }
}