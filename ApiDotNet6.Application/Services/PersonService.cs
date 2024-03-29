﻿using System;
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

        public async Task<ResultService> DeleteAsync(int id)
        {
            var data = await _personRepository.GetByIdAsync(id);

            if (data == null)
                return ResultService.Fail<PersonDTO>("Pessoa não foi encontrada");

            await _personRepository.DeleteAsync(data);

            var person = _mapper.Map<PersonDTO>(data);

            return ResultService.Ok($"{person.Name} deletad(o)a com sucesso!");
        }

        public async Task<ResultService<ICollection<PersonDTO>>> GetAsync()
        {
            var data = await _personRepository.GetPeopleAsync();

            var people = _mapper.Map<ICollection<PersonDTO>>(data);
            
            return ResultService.Ok<ICollection<PersonDTO>>(people);
        }

        public async Task<ResultService<PersonDTO>> GetByIdAsync(int id)
        {
            var data = await _personRepository.GetByIdAsync(id);

            if (data == null)
                return ResultService.Fail<PersonDTO>("Pessoa não foi encontrada");

            var person = _mapper.Map<PersonDTO>(data);

            return ResultService.Ok<PersonDTO>(person);
        }

        public async Task<ResultService> UpdateAsync(PersonDTO personDTO)
        {
            if (personDTO == null)
                return ResultService.Fail<PersonDTO>("Objeto deve ser informado!");

            var validation = new PersonDTOValidator().Validate(personDTO);
            if(!validation.IsValid)
                return ResultService.RequestError<PersonDTO>("Problemas na validação!", validation);

            var person = await _personRepository.GetByIdAsync(personDTO.Id);
            if (person == null)
                return ResultService.Fail<PersonDTO>("Pessoa não foi encontrada");

            person = _mapper.Map<PersonDTO, Person>(personDTO, person);

            await _personRepository.EditAsync(person);

            return ResultService.Ok($"Pessoa editada");
        }
    }
}

