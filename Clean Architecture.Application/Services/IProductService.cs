

using Clean_Architecture.Application.DTOs;

namespace Clean_Architecture.Application.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDisplayDTO>> GetAllProductsDTOAsync();
        Task<ProductDisplayDTO> GetProductDTOByIdAsync(int id);
        Task<ProductDisplayDTO> AddAsync(ProductDTO productDTO);
        Task<ProductDisplayDTO> UpdateAsync(ProductDTO productDTO);
        Task DeleteAsync(int id);

    }
}
