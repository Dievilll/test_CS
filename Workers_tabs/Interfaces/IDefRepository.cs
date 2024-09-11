using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workers_tabs.DTOs.Def;
using Workers_tabs.Models;

namespace Workers_tabs.Interfaces
{
    public interface IDefRepository
    {
        Task<List<Def>> GetAllAsync();
        Task<Def?> GetByIdAsync(int id); 
        Task<Def> CreateAsync(Def defModel);
        Task<Def?> UpdateAsync(int id, UpdateDefRequestDto updateDto);
        Task<Def?> DeleteAsync(int id);
        Task<bool> DefExists(int id);
    }
}