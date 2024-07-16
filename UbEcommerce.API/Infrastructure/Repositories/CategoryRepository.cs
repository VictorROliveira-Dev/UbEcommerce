using Microsoft.EntityFrameworkCore;
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

        public async Task<Response<Category?>> Create(CreateCategoryRequest request)
        {
            var category = new Category
            {
                Name = request.Name,
            };

            try
            {
                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();

                return new Response<Category?>(category, 201, "Categoria criada com sucesso.");
            }
            catch
            {
                return new Response<Category?>(null, 500, "Não foi possível criar uma categoria");
            }

        }

        public async Task<Response<Category?>> Delete(DeleteCategoryRequest request)
        {
            try
            {
                var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == request.CategoryId);

                if (category == null)
                {
                    return new Response<Category?>(null, 404, $"Não encontramos uma categoria o Id: {request.CategoryId}.");
                }

                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();

                return new Response<Category?>(category, 204, "Categoria removida com sucesso.");
            }
            catch
            {
                return new Response<Category?>(null, 400, "Categoria não removida.");
            }

        }

        public async Task<Response<Category?>> GetCategoryById(GetCategoryByIdRequest request)
        {
            try
            {
                var category = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == request.CategoryId);
                return category is null ? new Response<Category?>(null, 404, $"Não encontramos categoria com o Id: {request.CategoryId}.") : new Response<Category?>(category, 200);
            }
            catch
            {
                return new Response<Category?>(null, 400, "Não foi possível retornar a cateogoria.");
            }
        }

        public async Task<Response<Category?>> Update(UpdateCategoryRequest request)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == request.CategoryId);

            if (category is null)
            {
                return new Response<Category?>(null, 404, $"Não encontramos categoria com o Id: {request.CategoryId}");
            }

            category.Name = request.Name;

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return new Response<Category?>(category, 204);
        }
    }
}
