using UbEcommerce.API.Application.Requests.Category;
using UbEcommerce.API.Application.Responses;
using UbEcommerce.API.Domain.Entities;
using UbEcommerce.API.Domain.Repositories;
using UbEcommerce.API.Infrastructure.Persistence;

namespace UbEcommerce.API.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public Task<Response<Category>> Create(CreateCategoryRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Category>> Delete(DeleteCategoryRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Category>> GetCategoryById(GetCategoryByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Category>> Update(UpdateCategoryRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
