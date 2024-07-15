

using AutoMapper;
using Clean_Architecture.Application.DTOs;
using Clean_Architecture.core.Entities;
using Clean_Architecture.core.Interfaces;

namespace Clean_Architecture.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDisplayDTO>> GetAllProductsDTOAsync()
        {
            var products = await _unitOfWork.ProductRepository.GetAllAsync(["Category"]);
            var productDTOs = _mapper.Map<IEnumerable<ProductDisplayDTO>>(products);
            return productDTOs;
        }

        public async Task<ProductDisplayDTO> GetProductDTOByIdAsync(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetAsync(p => p.Id == id, ["Category"]);
            var productDTO = _mapper.Map<ProductDisplayDTO>(product);
            return productDTO;
        }

        public async Task<ProductDisplayDTO> AddAsync(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.SaveAsync();
            product = await _unitOfWork.ProductRepository.GetAsync(p => p.Id == product.Id, ["Category"]);
            return _mapper.Map<ProductDisplayDTO>(product);
        }

        public async Task<ProductDisplayDTO> UpdateAsync(ProductDTO productDTO)
        {
            var existingProduct = await _unitOfWork.ProductRepository.GetAsync(p => p.Id == productDTO.Id);

            if (existingProduct == null)
            {
                return null;
            }

            _mapper.Map(productDTO, existingProduct);
            _unitOfWork.ProductRepository.Update(existingProduct);
            await _unitOfWork.SaveAsync();
            existingProduct = await _unitOfWork.ProductRepository.GetAsync(p => p.Id == productDTO.Id, ["Category"]);
            return _mapper.Map<ProductDisplayDTO>(existingProduct);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.ProductRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }
    }
}
