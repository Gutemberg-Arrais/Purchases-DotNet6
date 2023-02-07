﻿using System;
using ApiDotNet6.Application.DTOs;

namespace ApiDotNet6.Application.Services.Interfaces
{
	public interface IPersonService
	{
		Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO);
		Task<ResultService<ICollection<PersonDTO>>> GetAsync();
		Task<ResultService<PersonDTO>> GetByIdAsync(int id);
	}
}

