using System;
using FluentValidation;

namespace ApiDotNet6.Application.DTOs.Validations
{
	public class PersonDTOValidator : AbstractValidator<PersonDTO>
	{
		public PersonDTOValidator()
		{
			RuleFor(x => x.Document)
				.NotEmpty()
				.NotNull()
				.WithMessage("Document deve ser informado!");

			RuleFor(x => x.Name)
				.NotNull()
				.NotEmpty()
				.WithMessage("Name deve ser informado!");

			RuleFor(x => x.Phone)
				.NotEmpty()
				.NotNull()
				.WithMessage("Phonen  deve ser informado!");

		}
	}
}

