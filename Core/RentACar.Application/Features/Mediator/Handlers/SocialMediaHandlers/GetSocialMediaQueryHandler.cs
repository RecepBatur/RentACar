using MediatR;
using RentACar.Application.Features.Mediator.Queries.SocialMediaQueries;
using RentACar.Application.Features.Mediator.Results.SocialMediaResults;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync();
            return value.Select(x => new GetSocialMediaQueryResult
            {
                SocialMediaId = x.SocialMediaId,
                Icon = x.Icon,
                Name = x.Name,
                Url = x.Url
            }).ToList();
        }
    }
}
