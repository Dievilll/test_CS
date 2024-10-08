using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Workers_tabs.Data;
using Workers_tabs.DTOs.Def;
using Workers_tabs.Interfaces;
using Workers_tabs.Models;
using Workers_tabs.Queries;

namespace Workers_tabs.Repository
{
    public class DefRepository : IDefRepository
    {
        private readonly ApplicationDBContext _context;
        public DefRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Def> CreateAsync(Def defModel)
        {
            await _context.Defs.AddAsync(defModel);
            await _context.SaveChangesAsync();
            return defModel;
        }

        public Task<bool> DefExists(int id)
        {
            return _context.Defs.AnyAsync(s => s.Id == id);
        }

        public async Task<Def?> DeleteAsync(int id)
        {
            var defModel = await _context.Defs.FirstOrDefaultAsync(x => x.Id == id);

            if (defModel == null)
            {
                return null;
            }

            _context.Defs.Remove(defModel);
            await _context.SaveChangesAsync();
            return defModel;
        }

        public async Task<List<Def>> GetAllAsync(QueryObject query)
        {
            var stocks = _context.Defs.Include(x => x.Comments).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.CompanyName))
            {
                stocks = stocks.Where(x => x.CompanyName.Contains(query.CompanyName));
            }

            if(!string.IsNullOrWhiteSpace(query.Symbol))
            {
                stocks = stocks.Where(x => x.Symbol.Contains(query.Symbol));
            }

            if(!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if(query.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
                {
                    stocks = query.IsDescending ? stocks.OrderByDescending(x => x.Symbol) : stocks.OrderBy(x => x.Symbol);
                }
            }

            return await stocks.ToListAsync();
        }

        public async Task<Def?> GetByIdAsync(int id)
        {
            return await _context.Defs.Include(x => x.Comments).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Def?> UpdateAsync(int id, UpdateDefRequestDto defDto)
        {
            var existingDef = await _context.Defs.FirstOrDefaultAsync(x => x.Id == id);
            if (existingDef == null)
            {
                return null;
            }
            existingDef.Symbol = defDto.Symbol;
            existingDef.CompanyName = defDto.CompanyName;
            existingDef.Purchase = defDto.Purchase;
            existingDef.LastDiv = defDto.LastDiv;
            existingDef.Industry = defDto.Industry;
            existingDef.MarketCap = defDto.MarketCap;

            await _context.SaveChangesAsync(); 
            return existingDef;
        }
    }
}