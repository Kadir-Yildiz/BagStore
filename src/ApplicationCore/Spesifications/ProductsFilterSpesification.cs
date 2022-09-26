using ApplicationCore.Entities;
using Ardalis.Specification;


namespace ApplicationCore.Spesifications
{
	public class ProductsFilterSpesification : Specification<Product>
	{
		public ProductsFilterSpesification(int? categoryId, int? brandId)
		{
			if (categoryId.HasValue)
				Query.Where(x => x.CategoryId == categoryId);

			if (brandId.HasValue)
				Query.Where(x => x.BrandId == brandId);

		}
	}
}
