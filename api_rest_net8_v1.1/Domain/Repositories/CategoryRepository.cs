using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dws.Note_one.Api.Domain.Models;
using Dws.Note_one.Api.Domain.Repositories.IRepositories;
using Dws.Note_one.Api.Persistence.Contexts;

namespace Dws.Note_one.Api.Domain.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {

        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Category>> ListAsync()
        {
        return await _context.Categories.ToListAsync(); 
        }
        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
        }
    }
}