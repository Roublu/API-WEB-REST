using System.Collections.Generic;
using System.Threading.Tasks;
using Dws.Note_one.Api.Domain.Models;
using Dws.Note_one.Api.Domain.Services.IServices;
using Dws.Note_one.Api.Domain.Repositories.IRepositories;
using Dws.Note_one.Api.Domain.Services.Communication;

namespace Dws.Note_one.Api.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _categoryRepository.ListAsync();
        }
            public async Task<SaveCategoryResponse> SaveAsync(Category category)
            {
                try
                {
                    await _categoryRepository.AddAsync(category);
                    await _unitOfWork.CompleteAsync();

                    return new SaveCategoryResponse(category);;
                }
                catch (Exception ex)
                {
                    return new SaveCategoryResponse($"An error occurred when the category: {ex.Message}");

                }
            }       
    }       
}