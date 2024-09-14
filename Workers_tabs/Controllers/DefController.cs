using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Workers_tabs.Data;
using Workers_tabs.DTOs.Def;
using Workers_tabs.Interfaces;
using Workers_tabs.Mappers;
using Workers_tabs.Queries;

namespace Workers_tabs.Controllers
{
    [Route("api/def")]
    [ApiController]
    public class DefController: ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IDefRepository _defRepo;
        public DefController(ApplicationDBContext context, IDefRepository defRepository)
        {
            _defRepo = defRepository;
            _context = context;

        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var defs = await _defRepo.GetAllAsync(query);
            var defDto = defs.Select(s => s.ToDefDto());

            return Ok(defs);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var def = await _defRepo.GetByIdAsync(id);

            if(def == null)
            {
                return NotFound();
            }

            return Ok(def.ToDefDto()); 
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDefRequestDto defDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var defModel = defDto.ToDefFromCreateDto();

            await _defRepo.CreateAsync(defModel);

            return CreatedAtAction(nameof(GetById), new {id = defModel.Id}, defModel.ToDefDto()); //
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateDefRequestDto updateDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var defModel = await _defRepo.UpdateAsync(id, updateDto);

            if (defModel == null)
            {
                return NotFound();
            }

            return Ok(defModel.ToDefDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
                
            var defModel = await _defRepo.DeleteAsync(id);

            if (defModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}