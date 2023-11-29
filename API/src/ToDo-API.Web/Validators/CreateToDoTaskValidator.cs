using FluentValidation;
using Todo_API.Domain.Inputs;

namespace ToDo_API.Web.Validators
{
    public class CreateToDoTaskValidator : AbstractValidator<CreateToDoTaskInput>
    {
        public CreateToDoTaskValidator()
        {
            RuleFor(x => x.TargetDate).GreaterThan(DateTime.Now.Date)
                .WithMessage("Must be a future date.");

            RuleFor(x => x.PriorityId).IsInEnum()
                .WithMessage("PriorityId must be between 1 and 4.");
        }
    }
}
