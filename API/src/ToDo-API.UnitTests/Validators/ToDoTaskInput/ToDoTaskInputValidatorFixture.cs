using FluentAssertions;
using FluentValidation.Results;
using Gwtdo;
using Todo_API.Domain.Enums;
using Todo_API.Domain.Inputs;
using ToDo_API.Web.Validators;

namespace ToDo_API.UnitTests.Validators.ToDoTaskInput
{
    using Act = Act<ToDoTaskInputValidatorFixture>;
    using Arrange = Arrange<ToDoTaskInputValidatorFixture>;
    using Assert = Assert<ToDoTaskInputValidatorFixture>;
    public class ToDoTaskInputValidatorFixture : IFixture
    {
        internal CreateToDoTaskInput Input;
        internal ValidationResult Result;
        internal CreateToDoTaskValidator Validator;
        internal CancellationToken CancellationToken;

        public void Setup()
        {
            CancellationToken = new CancellationToken();
        }
    }

    internal static class Setup
    {
        public static Arrange I_have_a_validator(this Arrange fixture)
        {
            return fixture.Setup(f => f.Validator = new CreateToDoTaskValidator());
        }

        public static Arrange I_have_a_valid_payload(this Arrange fixture)
        {
            return fixture.Setup(f =>
                f.Input = new CreateToDoTaskInput { Title = "Test Title", Description = "Test Description", PriorityId = Priority.Urgent, TargetDate = DateTime.UtcNow.Date.AddDays(1) }
            );
        }

        public static Arrange I_have_a_payload_with_invalid_target_date(this Arrange fixture)
        {
            return fixture.Setup(f =>
                f.Input = new CreateToDoTaskInput { Title = "Test Title", Description = "Test Description", PriorityId = Priority.Urgent, TargetDate = DateTime.UtcNow.Date.AddDays(-1) }
            );
        }

        public static Arrange I_have_a_payload_with_invalid_priority(this Arrange fixture)
        {
            return fixture.Setup(f =>
                f.Input = new CreateToDoTaskInput { Title = "Test Title", Description = "Test Description", PriorityId = Priority.Low + 1, TargetDate = DateTime.UtcNow.Date.AddDays(1) }
            );
        }
    }

    internal static class Exercise
    {
        public static Act I_validate_the_payload(this Act fixture)
        {
            return fixture.It(async f =>
            {
                f.Result = await f.Validator.ValidateAsync(f.Input, f.CancellationToken);
            });
        }
    }

    internal static class Verify
    {
        public static Assert My_validation_returns_sucess(this Assert fixture)
        {
            return fixture.Expect(f => f.Result.IsValid.Should().BeTrue());
        }

        public static Assert Without_errors(this Assert fixture)
        {
            return fixture.Expect(f => f.Result.Errors.Should().HaveCount(0));
        }

        public static Assert My_validation_returns_unsucess(this Assert fixture)
        {
            return fixture.Expect(f => f.Result.IsValid.Should().BeFalse());
        }

        public static Assert With_errors(this Assert fixture)
        {
            return fixture.Expect(f => f.Result.Errors.Should().HaveCountGreaterThan(0));
        }
    }
}
