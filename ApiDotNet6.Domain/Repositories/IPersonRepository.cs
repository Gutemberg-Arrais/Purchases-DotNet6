using System;
using ApiDotNet6.Domain.Entities;

namespace ApiDotNet6.Domain.Repositories
{
	public interface IPersonRepository
	{
		Task<Person> GetByIdAsync(int id);
		Task<ICollection<Person>> GetPeopleAsync();
		Task<Person> CreatePersonAsync(Person person);
		Task EditAsync(Person person);
		Task DeleteAsync(Person person);
	}
}

