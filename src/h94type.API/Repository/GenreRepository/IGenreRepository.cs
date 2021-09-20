using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using h94type.API.Models;

namespace h94type.API.Repository.GenreRepository
{
    public interface IGenreRepository
    {
        Task Create(Genre genre);
        Task<IEnumerable<Genre>> GetAll();
        Task<Genre> GetById(Guid id);
        Task<Genre> GetByGenreName(string genreName);
        Task Delete(Guid id);
        Task Update(Guid id, Genre genre);
    }
}