using FluentValidation;
using Mediatr.Sample.Command;

namespace Mediatr.Sample.Validation;

public class TestCommandValidator : AbstractValidator<TestCommand>
{
	public TestCommandValidator()
	{
		RuleFor(x => x.Value)
			.NotEmpty();
	}
}
