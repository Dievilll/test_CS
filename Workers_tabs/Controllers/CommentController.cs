using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Workers_tabs.DTOs;
using Workers_tabs.DTOs.Comment;
using Workers_tabs.Interfaces;
using Workers_tabs.Mappers;

namespace Workers_tabs.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IDefRepository _defRepo;
        public CommentController(ICommentRepository commentRepo, IDefRepository defRepo)
        {
            _commentRepo = commentRepo;
            _defRepo = defRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
                
            var comments = await _commentRepo.GetAllAsync();

            var CommentDto = comments.Select(s => s.ToCommentDto());
            
            return Ok(CommentDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var comment = await _commentRepo.GetByIdAsync(id);

            if(comment == null) 
            {
                return NotFound();

            }
            
            return Ok(comment.ToCommentDto());
        }

        [HttpPost("{defId:int}")]
        public async Task<IActionResult> Create([FromRoute] int defId, CreateCommentDto commentDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!await _defRepo.DefExists(defId))
            {
                return BadRequest("Def doesn't exists");
            }

            var commentModel = commentDto.ToCommentFromCreate(defId);
            await _commentRepo.CreateAsync(commentModel);

            return CreatedAtAction(nameof(GetById), new { id = commentModel.Id}, commentModel.ToCommentDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentDto updateDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var commentModel = await _commentRepo.UpdateAsync(id, updateDto.ToCommentFromUpdate());

            if(commentModel == null)
            {
                return NotFound("Comment not found");
            }

            return Ok(commentModel.ToCommentDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var commentModel = await _commentRepo.DeleteAsync(id);
            
            if(commentModel == null)
            {
                return NotFound("Comment not found");
            }

            return NoContent();
        }
    }
}