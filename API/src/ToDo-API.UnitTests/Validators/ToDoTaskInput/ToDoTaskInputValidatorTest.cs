using Gwtdo;

namespace ToDo_API.UnitTests.Validators.ToDoTaskInput
{
    public class ToDoTaskInputValidatorTest : Feature<ToDoTaskInputValidatorFixture>, IClassFixture<ToDoTaskInputValidatorFixture>
    {
        public ToDoTaskInputValidatorTest(ToDoTaskInputValidatorFixture fixture)
        {
            SetFixture(fixture);
            fixture.Setup();
        }

        [Fact]
        public void Validate_payload_sucessfully()
        {
            GIVEN
                .I_have_a_validator().And
                .I_have_a_valid_payload();

            WHEN
                .I_validate_the_payload();

            THEN
                .My_validation_returns_sucess().And
                .Without_errors();
        }

        [Fact]
        public void Validate_payload_with_invalid_target_date()
        {
            GIVEN
                .I_have_a_validator().And
                .I_have_a_payload_with_invalid_target_date();

            WHEN
                .I_validate_the_payload();

            THEN
                .My_validation_returns_unsucess().And
                .With_errors();

        }

        [Fact]
        public void Validate_payload_with_invalid_priority()
        {
            GIVEN
                .I_have_a_validator().And
                .I_have_a_payload_with_invalid_priority();

            WHEN
                .I_validate_the_payload();

            THEN
                .My_validation_returns_unsucess().And
                .With_errors();
        }
    }
}
