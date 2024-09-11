using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workers_tabs.DTOs.Comment;
using Workers_tabs.Models;

namespace Workers_tabs.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                DefId = commentModel.DefId
            };
        }

        public static Comment ToCommentFromCreate(this CreateCommentDto commentDto, int defId)
        {
            return new Comment
            {
                Title = commentDto.Title,
                Content = commentDto.Content,
                DefId = defId
            };
        }
    }
}