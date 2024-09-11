using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workers_tabs.DTOs.Def;
using Workers_tabs.Models;

namespace Workers_tabs.Mappers
{
    public static class DefMappers
    {
        public static DefDto ToDefDto(this Def defmodel)
        {
            return new DefDto
            {
                Id = defmodel.Id,
                Symbol = defmodel.Symbol,
                CompanyName = defmodel.CompanyName,
                Purchase = defmodel.Purchase,
                LastDiv = defmodel.LastDiv,
                Industry = defmodel.Industry,
                MarketCap = defmodel.MarketCap,
                Comments = defmodel.Comments.Select(x => x.ToCommentDto()).ToList()
            };
        }

        public static Def ToDefFromCreateDto(this CreateDefRequestDto defDto)
        {
            return new Def
            {
                Symbol = defDto.Symbol,
                CompanyName = defDto.CompanyName,
                Purchase = defDto.Purchase,
                LastDiv = defDto.LastDiv,
                Industry = defDto.Industry,
                MarketCap = defDto.MarketCap
            };
        }
    }
}