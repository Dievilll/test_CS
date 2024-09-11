using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            var comments = await _commentRepo.GetAllAsync();

            var CommentDto = comments.Select(s => s.ToCommentDto());
            
            return Ok(CommentDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comment = await _commentRepo.GetByIdAsync(id);

            if(comment == null) 
            {
                return NotFound();

            }
            
            return Ok(comment.ToCommentDto());
        }

        [HttpPost("{defId}")]
        public async Task<IActionResult> Create([FromRoute] int defId, CreateCommentDto commentDto)
        {
            if(!await _defRepo.DefExists(defId))
            {
                return BadRequest("Def doesn't exists");
            }

            var commentModel = commentDto.ToCommentFromCreate(defId);
            await _commentRepo.CreateAsync(commentModel);

            return CreatedAtAction(nameof(GetById), new { id = commentModel}, commentModel.ToCommentDto());
        }
    }
}