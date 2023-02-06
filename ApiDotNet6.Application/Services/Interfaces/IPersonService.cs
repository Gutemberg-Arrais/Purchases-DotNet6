using System;
using ApiDotNet6.Application.DTOs;

namespace ApiDotNet6.Application.Services.Interfaces
{
	public interface IPersonService
	{
		Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO);
	}
}

