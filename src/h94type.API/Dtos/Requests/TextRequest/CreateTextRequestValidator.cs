using FluentValidation;

namespace h94type.API.Dtos.Requests.TextRequest
{
    public class CreateTextRequestValidator : AbstractValidator<CreateTextRequest>
    {
        public CreateTextRequestValidator()
        {
            RuleFor(req => req.Word).NotEmpty().MinimumLength(2).MaximumLength(40);
            RuleFor(req => req.Translation).NotEmpty().MinimumLength(2).MaximumLength(40);
            RuleFor(req => req.GenreId).NotEmpty();
        }
    }
}