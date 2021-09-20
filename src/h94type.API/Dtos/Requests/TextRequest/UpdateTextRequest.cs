using System;

namespace h94type.API.Dtos.Requests.TextRequest
{
    public class UpdateTextRequest
    {
        public string Word { get; set; }
        public string Translation { get; set; }
        public bool Star { get; set; }
        public bool IsActive {get; set;}
    }
}