using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using h94type.API.Dtos;
using h94type.API.Dtos.Requests.GenreRequest;
using h94type.API.Models;
using h94type.API.Repository.GenreRepository;
using h94type.API.Results;

namespace h94type.API.Services.GenreService
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepositry;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository genreRepositry, IMapper mapper)
        {
            _genreRepositry = genreRepositry;
            _mapper = mapper;
        }

        public async Task<IResult> Create(CreateGenreRequest request)
        {
            var result = await _genreRepositry.GetByGenreName(request.GenreName);
            if(result != null)
                return new ErrorResult(false,"Genre Zaten Mevcut");
            await _genreRepositry.Create(_mapper.Map<Genre>(request));
            return new SuccessResult(true,"Genre Eklendi..");
        }

        public async Task<IResult> Delete(Guid id)
        {
            var result = await _genreRepositry.GetById(id);
            if(result is null)
                return new ErrorResult(false,"Genre Bulunamadı..");
            await _genreRepositry.Delete(id);
            return new SuccessResult(true,"Genre Silindi..");
        }

        public async Task<IDataResult<GenreViewModel>> GetById(Guid id)
        {
            var result = await _genreRepositry.GetById(id);
            if(result is null)
                return new ErrorDataResult<GenreViewModel>("Genre Bulunamadı..");
            return new SuccessDataResult<GenreViewModel>(_mapper.Map<GenreViewModel>(result),"Genre Listelendi..");
        }

        public async Task<IDataResult<IEnumerable<GenreViewModel>>> GetAll()
        {
            
            return new SuccessDataResult<IEnumerable<GenreViewModel>>
            (_mapper.Map<IEnumerable<GenreViewModel>>(await _genreRepositry.GetAll()),"Genre Listelendi..");
        }

        public async Task<IDataResult<GenreViewModel>> GetByGenreName(string genreName)
        {
            var result = await _genreRepositry.GetByGenreName(genreName);
            if(result is null)
                return new ErrorDataResult<GenreViewModel>("Genre Bulunamadı..");
            return new SuccessDataResult<GenreViewModel>(_mapper.Map<GenreViewModel>(result),"Genre Listelendi..");
        }

        public async Task<IResult> Update(Guid id, UpdateGenreRequest request)
        {
            var result = await _genreRepositry.GetById(id);
            if(result is null)
                return new ErrorResult(false,"Genre Bulunamadı..");
            await _genreRepositry.Update(id,_mapper.Map<Genre>(request));
            return new SuccessResult(true,"Genre Güncellendi..");
        }
    }
}