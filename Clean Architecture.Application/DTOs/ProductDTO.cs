
namespace Clean_Architecture.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Quentity { get; set; }
        public int? CatId { get; set; }
    }
}
