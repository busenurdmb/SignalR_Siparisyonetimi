using Application.Features.Mediator.Categories.Queries.GetProductsWithCategories;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Mediator.ProductsWithCategoriess.Queries.GetProductsWithCategoriessWithCategories
{

    public class GetListProductsWithCategoriesQuery : IRequest<List<GetListProductsWithCategoriesResponse>>
    {
        public class GetListProductsWithCategoriesQueryHandler : IRequestHandler<GetListProductsWithCategoriesQuery, List<GetListProductsWithCategoriesResponse>>
        {
            private readonly IProductRepository _ProductsRepository;
            private readonly IMapper _mapper;

            public GetListProductsWithCategoriesQueryHandler(IProductRepository productsRepository, IMapper mapper)
            {
                _ProductsRepository = productsRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListProductsWithCategoriesResponse>> Handle(GetListProductsWithCategoriesQuery request, CancellationToken cancellationToken)
            {
                var Products = await _ProductsRepository.GetProductsWithCategories2();
                //return Categories.Select(x => new GetListProductsWithCategoriesResponse
                //{
                //    ProductName = x.ProductName,
                //    Description= x.Description,
                //    Price = x.Price,
                //    ImageUrl = x.ImageUrl,
                //    ProductStatus = x.ProductStatus,
                //    CategoryID= x.CategoryID,
                //    CategoryName = x.Category.CategoryName

                //}
                //).ToList() ;
               var value= _mapper.Map<List<GetListProductsWithCategoriesResponse>>(Products);
                return value;
                
            }
        }
    }
}
