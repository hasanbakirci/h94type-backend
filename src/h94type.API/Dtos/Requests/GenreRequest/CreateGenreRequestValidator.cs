using FluentValidation;

namespace h94type.API.Dtos.Requests.GenreRequest
{
    public class CreateGenreRequestValidator : AbstractValidator<CreateGenreRequest>
    {
        public CreateGenreRequestValidator()
        {
            RuleFor(req => req.GenreName).NotEmpty().MinimumLength(2).MaximumLength(30);
        }
    }
}