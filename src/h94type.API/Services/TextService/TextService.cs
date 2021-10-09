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
                return new ErrorResult(false,"Text Bulunamadı..");
            await _textRepository.Delete(id);
            return new SuccessResult(true,"Text Silindi..");
        }

        public async Task<IDataResult<TextViewModel>> GetById(Guid id)
        {
            var result = await _textRepository.GetById(id);
            if(result is null)
                return new ErrorDataResult<TextViewModel>("Text bulunamadı.");
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
                return new ErrorResult(false,"Text Bulunamadı..");
            await _textRepository.Update(id,_mapper.Map<Text>(request));
            return new SuccessResult(true,"Text Güncelledi..");
        }


        public async Task<IDataResult<TextViewModel>> GetByWord(string word)
        {
            var result = await _textRepository.GetByWord(word);
            if(result is null)
                return new ErrorDataResult<TextViewModel>("Text Bulunamadı..");
            return new SuccessDataResult<TextViewModel>(_mapper.Map<TextViewModel>(result),"Text Listelendi..");
        }

        public async Task<IDataResult<IEnumerable<TextViewModel>>> GetAllByGenreName(string genreName)
        {
            return new SuccessDataResult<IEnumerable<TextViewModel>>
            (_mapper.Map<IEnumerable<TextViewModel>>(await _textRepository.GetAllByGenreName(genreName)),"Text, Genre Türüne Göre Listelendi..");
        }

        public async Task<IDataResult<IEnumerable<TextViewModel>>> GetAllByGenreNameAndStarly(string genreName)
        {
            return new SuccessDataResult<IEnumerable<TextViewModel>>
            (_mapper.Map<IEnumerable<TextViewModel>>(await _textRepository.GetAllByGenreNameAndStarly(genreName)),"Text, Genre Türüne ve Star Durumuna Göre Listelendi..");
        }
    }
}