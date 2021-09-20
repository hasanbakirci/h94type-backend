using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using h94type.API.Dtos;
using h94type.API.Dtos.Requests.GenreRequest;
using h94type.API.Services.GenreService;
using Microsoft.AspNetCore.Mvc;

namespace h94type.API.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public GenreController(IGenreService genreService, IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreViewModel>>> GetAll()
        {
           var genres = await _genreService.GetAll();
           if(genres.Success){
                return Ok(genres);
            }
            return BadRequest(genres);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GenreViewModel>> Get(Guid id)
        {
            var genre = await _genreService.GetById(id);
            if(genre.Success){
                return Ok(genre);
            }
            return BadRequest(genre);
                    
        }
        [HttpGet("/GetByName/{name}")]
        public async Task<ActionResult<GenreViewModel>> Get(string name)
        {
            var genre = await _genreService.GetByGenreName(name);
            if(genre.Success){
               return Ok(genre); 
            }
            return BadRequest(genre);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateGenreRequest request) 
        {
            var result = await _genreService.Create(request);
            if(result.Success){
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _genreService.Delete(id);
            if(result.Success){
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateGenreRequest request)
        {
            var result = await _genreService.Update(id,request);
            if(result.Success){
                return Ok();
            }
            return BadRequest();
        }
    }
}