using System;

namespace h94type.API.Dtos
{
    public class GenreViewModel
    {
        public Guid Id { get; set; }
        public string GenreName { get; set; }
        public bool IsActive { get; set; }
    }
}