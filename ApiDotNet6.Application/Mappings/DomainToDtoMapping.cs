using System;
using ApiDotNet6.Application.DTOs;
using ApiDotNet6.Domain.Entities;
using AutoMapper;

namespace ApiDotNet6.Application.Mappings
{
	public class DomainToDtoMapping: Profile
	{
		public DomainToDtoMapping()
		{
			CreateMap<Person, PersonDTO>();
		}
	}
}

