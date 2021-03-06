using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using h94type.API.Dtos;
using h94type.API.Dtos.Requests.TextRequest;
using h94type.API.Models;
using h94type.API.Repository.TextRepository;
using h94type.API.Results;

namespace h94type.API.Services.TextService
{
    public class TextService : ITextService
    {
        private readonly ITextRepository _textRepository;
        private readonly IMapper _mapper;

        public TextService(ITextRepository textRepository,IMapper mapper)
        {
            _textRepository = textRepository;
            _mapper = mapper;
        }

        public async Task<IResult> Create(CreateTextRequest request)
        {
            CreateTextRequestValidator validate = new CreateTextRequestValidator();
            var result = await _textRepository.GetByWord(request.Word);
            if(result != null || !validate.Validate(request).IsValid)
                return new ErrorResult(false,"Text Zaten Mevcut");
            await _textRepository.Create(_mapper.Map<Text>(request));
            return new SuccessResult(true,"Text Eklendi..");
        }

        public async Task<IResult> Delete(Guid id)
        {
            var result = await _textRepository.GetById(id);
            if(result is null)
                return new ErrorResult(false,"Text Bulunamad─▒..");
            await _textRepository.Delete(id);
            return new SuccessResult(true,"Text Silindi..");
        }

        public async Task<IDataResult<TextViewModel>> GetById(Guid id)
        {
            var result = await _textRepository.GetById(id);
            if(result is null)
                return new ErrorDataResult<TextViewModel>("Text bulunamad─▒.");
            return new SuccessDataResult<TextViewModel>(_mapper.Map<TextViewModel>(result),"Text Listelendi..");
        }

        public async Task<IDataResult<IEnumerable<TextViewModel>>> GetAll()
        {
            return new SuccessDataResult<IEnumerable<TextViewModel>>
            (_mapper.Map<IEnumerable<TextViewModel>>(await _textRepository.GetAll()),"Text Listelendi..");
            
        }

        public async Task<IResult> Update(Guid id,UpdateTextRequest request)
        {
            var result = await _textRepository.GetById(id);
            if(result is null)
                return new ErrorResult(false,"Text Bulunamad─▒..");
            await _textRepository.Update(id,_mapper.Map<Text>(request));
            return new SuccessResult(true,"Text G├╝ncelledi..");
        }


        public async Task<IDataResult<TextViewModel>> GetByWord(string word)
        {
            var result = await _textRepository.GetByWord(word);
            if(result is null)
                return new ErrorDataResult<TextViewModel>("Text Bulunamad─▒..");
            return new SuccessDataResult<TextViewModel>(_mapper.Map<TextViewModel>(result),"Text Listelendi..");
        }

        public async Task<IDataResult<IEnumerable<TextViewModel>>> GetAllByGenreName(string genreName)
        {
            return new SuccessDataResult<IEnumerable<TextViewModel>>
            (_mapper.Map<IEnumerable<TextViewModel>>(await _textRepository.GetAllByGenreName(genreName)),"Text, Genre T├╝r├╝ne G├Âre Listelendi..");
        }

        public async Task<IDataResult<IEnumerable<TextViewModel>>> GetAllByGenreNameAndStarly(string genreName)
        {
            return new SuccessDataResult<IEnumerable<TextViewModel>>
            (_mapper.Map<IEnumerable<TextViewModel>>(await _textRepository.GetAllByGenreNameAndStarly(genreName)),"Text, Genre T├╝r├╝ne ve Star Durumuna G├Âre Listelendi..");
        }
    }
}