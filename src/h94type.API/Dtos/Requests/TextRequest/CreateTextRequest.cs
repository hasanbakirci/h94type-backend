using System;

namespace h94type.API.Dtos.Requests.TextRequest
{
    public class CreateTextRequest
    {
        public string Word { get; set; }
        public string Translation { get; set; }
        public Guid GenreId { get; set; }
    }
}