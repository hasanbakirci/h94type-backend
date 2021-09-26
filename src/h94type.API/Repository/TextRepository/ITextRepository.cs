using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using h94type.API.Models;

namespace h94type.API.Repository.TextRepository
{
    public interface ITextRepository
    {
        Task Create(Text text);
        Task<IEnumerable<Text>> GetAll();
        Task<Text> GetById(Guid id);
        Task<Text> GetByWord(string word);
        Task Delete(Guid id);
        Task Update(Guid id, Text text);
        Task<IEnumerable<Text>> GetAllByGenreName(string genreName);
        Task<IEnumerable<Text>> GetAllByGenreNameAndStared(string genreName);
    }
}