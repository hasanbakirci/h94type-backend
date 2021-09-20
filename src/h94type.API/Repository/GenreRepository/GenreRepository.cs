using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using h94type.API.Models;
using Microsoft.EntityFrameworkCore;

namespace h94type.API.Repository.GenreRepository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _context;
        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Genre genre)
        {
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var result = await GetById(id);
            _context.Genres.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Genre>> GetAll()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<Genre> GetById(Guid id)
        {
            return await _context.Genres.FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<Genre> GetByGenreName(string genreName)
        {
            return await _context.Genres.FirstOrDefaultAsync(q => q.GenreName == genreName);
        }

        public async Task Update(Guid id, Genre genre)
        {
            var result = await GetById(id);
            result.GenreName = genre.GenreName != default ? genre.GenreName : result.GenreName;
            result.IsActive = genre.IsActive != default ? genre.IsActive : result.IsActive;
            await _context.SaveChangesAsync();
        }
    }
}