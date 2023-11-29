using MediatR;
using RentACar.Application.Features.Mediator.Queries.SocialMediaQueries;
using RentACar.Application.Features.Mediator.Results.FooterAddressResults;
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
    public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetSocialMediaByIdQueryResult
            {
                SocialMediaId = value.SocialMediaId,
                Url = value.Url,
                Icon = value.Icon,
                Name = value.Name
            };
        }
    }
}
