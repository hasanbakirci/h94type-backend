using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using h94type.API.Dtos;
using h94type.API.Dtos.Requests.GenreRequest;
using h94type.API.Results;

namespace h94type.API.Services.GenreService
{
    public interface IGenreService
    {
        Task<IResult> Create(CreateGenreRequest request);
        Task<IDataResult<IEnumerable<GenreViewModel>>> GetAll();
        Task<IDataResult<GenreViewModel>> GetById(Guid id);
        Task<IDataResult<GenreViewModel>> GetByGenreName(string genreName);
        Task<IResult> Delete(Guid id);
        Task<IResult> Update(Guid id, UpdateGenreRequest request);
    }
}