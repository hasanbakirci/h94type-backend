using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using h94type.API.Models;
using Microsoft.EntityFrameworkCore;

namespace h94type.API.Repository.TextRepository
{
    public class TextRepository : ITextRepository
    {
        private readonly ApplicationDbContext _context;
        public TextRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task Create(Text text)
        {
            _context.Texts.Add(text);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var result = await GetById(id);
            _context.Texts.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Text>> GetAll()
        {
            return await _context.Texts.Include(x => x.Genre).ToListAsync();   
        }

        public async Task<IEnumerable<Text>> GetAllByGenreId(Guid id)
        {
            var result = await _context.Texts.Include(x => x.Genre).Where(x => x.GenreId == id).ToListAsync();
            return result.OrderBy(y => Guid.NewGuid()).ToList();
        }

        public async Task<IEnumerable<Text>> GetAllByGenreIdAndStared(Guid id)
        {
            var result = await _context.Texts.Include(x => x.Genre).Where(x => x.GenreId == id && x.Star == true).ToListAsync();
            return  result.OrderBy(y => Guid.NewGuid()).ToList();
        }

        public async Task<Text> GetById(Guid id)
        {
            return await _context.Texts.Include(x => x.Genre).Where(a => a.Id == id).SingleOrDefaultAsync();            
        }

        public async Task<Text> GetByWord(string word)
        {
            return await _context.Texts.Include(x => x.Genre).Where(q => q.Word == word).SingleOrDefaultAsync();
        }

        public async Task Update(Guid id, Text text)
        {
            var result = await GetById(id);
            result.Word = text.Word != default ? text.Word : result.Word;
            result.Translation = text.Translation != default ? text.Translation : result.Translation;
            result.Star = text.Star != default ? text.Star : result.Star;
            await _context.SaveChangesAsync();
        }
    }
}