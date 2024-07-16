using UbEcommerce.API.Application.Requests.Category;
using UbEcommerce.API.Application.Responses;
using UbEcommerce.API.Domain.Entities;

namespace UbEcommerce.API.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<Response<Category?>> Create(CreateCategoryRequest request);
        Task<Response<Category?>> Update(UpdateCategoryRequest request);
        Task<Response<Category?>> Delete(DeleteCategoryRequest request);
        Task<Response<Category?>> GetCategoryById(GetCategoryByIdRequest request);
    }
}
