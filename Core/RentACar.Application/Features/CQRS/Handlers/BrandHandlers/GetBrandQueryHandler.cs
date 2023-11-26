using RentACar.Application.Features.CQRS.Results.BrandResults;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandQueryHandler
    {
        private readonly IRepository<Brand> _repository;

        public GetBrandQueryHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetBrandQueryResult>> Handle()
        {
            var value = await _repository.GetAllAsync();
            return value.Select(x => new GetBrandQueryResult
            {
                BrandId = x.BrandId,
                Name = x.Name,
            }).ToList();
        }
    }
}
