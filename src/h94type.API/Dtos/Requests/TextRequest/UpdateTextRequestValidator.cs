using FluentValidation;

namespace h94type.API.Dtos.Requests.TextRequest
{
    public class UpdateTextRequestValidator : AbstractValidator<UpdateTextRequest>
    {
        public UpdateTextRequestValidator()
        {
            RuleFor(req => req.Word).NotEmpty().MinimumLength(2).MaximumLength(40);
            RuleFor(req => req.Translation).NotEmpty().MinimumLength(2).MaximumLength(40);
            RuleFor(req => req.Star).Must(x => x == false || x == true);
        }
    }
}