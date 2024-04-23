using FlavorMatch.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlavorMatchAPI.Models
{
    public class DishesRepo
    {
        private readonly FlavorMatchAPIContext _context;

        public DishesRepo(FlavorMatchAPIContext context)
        {
            _context = context;
        }

        public async Task<List<Dishes>> GetDishes()
        {
            return await _context.Dishes.ToListAsync();
        }

        public async Task<Dishes> GetDish(int? id)
        {
            return await _context.Dishes.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task CreateDish([Bind("Id,Name,Ingredients,Description,Recipe,Type,Origin,Image")] Dishes dishes)
        {
            _context.Add(dishes);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDish(int id, [Bind("Id,Name,Ingredients,Description,Recipe,Type,Origin,Image")] Dishes dishes)
        {
            _context.Update(dishes);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDish(int id)
        {
            var dishes = await _context.Dishes.FindAsync(id);
            _context.Dishes.Remove(dishes);
            await _context.SaveChangesAsync();
        }
    }
}
