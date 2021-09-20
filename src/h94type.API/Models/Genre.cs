using System;
using System.Collections.Generic;

namespace h94type.API.Models
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string GenreName { get; set; }
        public bool IsActive {get; set;} = true;
    }
}