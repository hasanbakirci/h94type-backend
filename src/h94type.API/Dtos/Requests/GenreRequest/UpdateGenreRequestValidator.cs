using FluentValidation;

namespace h94type.API.Dtos.Requests.GenreRequest
{
    public class UpdateGenreRequestValidator :AbstractValidator<UpdateGenreRequest>
    {
        public UpdateGenreRequestValidator()
        {
            RuleFor(req => req.GenreName).NotEmpty().MinimumLength(2).MaximumLength(30);
        }
    }
}