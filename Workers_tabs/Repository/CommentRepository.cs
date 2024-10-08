using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Workers_tabs.Data;
using Workers_tabs.Interfaces;
using Workers_tabs.Models;

namespace Workers_tabs.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;

        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var commentModel = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if (commentModel == null)
            {
                return null;
            }

            _context.Comments.Remove(commentModel);
            await _context.SaveChangesAsync();

            return commentModel;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public Task<Comment?> GetByIdAsync([FromRoute] int id)
        {
            return _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Comment?> UpdateAsync(int id, Comment commentModel)
        {
            var existsComment = await _context.Comments.FindAsync(id);
            if (existsComment == null)
            {
                return null;
            }

            existsComment.Title = commentModel.Title;
            existsComment.Content = commentModel.Content;

            await _context.SaveChangesAsync();
            
            return existsComment;
        }
    }
}