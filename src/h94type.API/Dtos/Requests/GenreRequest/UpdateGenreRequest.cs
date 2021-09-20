using FluentValidation;

namespace h94type.API.Dtos.Requests.GenreRequest
{
    public class UpdateGenreRequest 
    {
        public string GenreName { get; set; }
        public bool IsActive { get; set; }
    }
}