using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using h94type.API.Dtos;
using h94type.API.Dtos.Requests.TextRequest;
using h94type.API.Results;

namespace h94type.API.Services.TextService
{
    public interface ITextService
    {
        Task<IResult> Create(CreateTextRequest request);
        Task<IDataResult<IEnumerable<TextViewModel>>> GetAll();
        Task<IDataResult<TextViewModel>> GetById(Guid id);
        Task<IDataResult<TextViewModel>> GetByWord(string word);
        Task<IResult> Delete(Guid id);
        Task<IResult> Update(Guid id, UpdateTextRequest text);
        Task<IDataResult<IEnumerable<TextViewModel>>> GetAllByGenreName(string genreName);
        Task<IDataResult<IEnumerable<TextViewModel>>> GetAllByGenreNameAndStarly(string genreName);
    }
}