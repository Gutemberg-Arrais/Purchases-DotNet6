using System;
using ApiDotNet6.Application.DTOs;
using ApiDotNet6.Application.DTOs.Validations;
using ApiDotNet6.Application.Services.Interfaces;
using ApiDotNet6.Domain.Entities;
using ApiDotNet6.Domain.Repositories;
using AutoMapper;

namespace ApiDotNet6.Application.Services
{
	public class PersonService : IPersonService
	{
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

		public PersonService(IPersonRepository personRepository, IMapper mapper)
		{
            _personRepository = personRepository;
            _mapper = mapper;
		}

        public async Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO)
        {
            if (personDTO == null) return ResultService.Fail<PersonDTO>("Objeto deve ser informado!");

            var result = new PersonDTOValidator().Validate(personDTO);

            if (!result.IsValid) return ResultService.RequestError<PersonDTO>("Problemas na validação!", result);

            var person = _mapper.Map<Person>(personDTO);

            var data = await _personRepository.CreateAsync(person);

            return ResultService.Ok<PersonDTO>(_mapper.Map<PersonDTO>(data));
        }
    }
}

