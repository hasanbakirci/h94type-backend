using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using h94type.API.Dtos;
using h94type.API.Dtos.Requests.TextRequest;
using h94type.API.Services.TextService;
using Microsoft.AspNetCore.Mvc;

namespace h94type.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TextsController : ControllerBase
    {
        private readonly ITextService _textService;
        private readonly IMapper _mapper;
        public TextsController(ITextService textService,IMapper mapper)
        {
            _textService = textService;
            _mapper = mapper;
        }
        [HttpGet]
        public  async Task<ActionResult<IEnumerable<TextViewModel>>> GetAll()
        {
            var texts = await _textService.GetAll();
            if(texts.Success){
                return Ok(texts);
            }
            return BadRequest(texts);
        }
        [HttpGet("Search/GenreName/{genreName}")]
        public  async Task<ActionResult<IEnumerable<TextViewModel>>> GetAllByGenreName(string genreName)
        {
            var texts = await _textService.GetAllByGenreName(genreName);
            if(texts.Success){
                return Ok(texts);
            }
            return BadRequest(texts);
        }
        [HttpGet("Search/GenreNameAndStarly/{genreName}")]
        public  async Task<ActionResult<IEnumerable<TextViewModel>>> GetAllByGenreNameAndStarly(string genreName)
        {
            var texts = await _textService.GetAllByGenreNameAndStarly(genreName);
            if(texts.Success){
                return Ok(texts);
            }
            return BadRequest(texts);
        }

        [HttpGet("Search/id/{id}")]
        public async Task<ActionResult<TextViewModel>> GetById(Guid id)
        {
            var text = await _textService.GetById(id);
            if(text.Success){
                return Ok(text);
            }
            return BadRequest(text);
        }
        [HttpGet("Search/word/{word}")]
        public async Task<ActionResult<TextViewModel>> GetByWord(string word)
        {
            var text = await _textService.GetByWord(word);
            if(text.Success){
                return Ok(text);
            }
            return BadRequest(text);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateTextRequest request)
        {
            var result = await _textService.Create(request);
            if(result.Success){
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _textService.Delete(id);
            if(result.Success){
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateTextRequest request)
        {
            var result = await _textService.Update(id,request);
            if(result.Success){
                return Ok();
            }
            return BadRequest();
        }
        
    }
}
