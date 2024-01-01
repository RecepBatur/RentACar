using MediatR;
using RentACar.Application.Features.CQRS.Results.CarResults;
using RentACar.Application.Features.Mediator.Queries.BlogQueries;
using RentACar.Application.Features.Mediator.Results.BlogResults;
using RentACar.Application.Interfaces.BlogInterfaces;
using RentACar.Application.Interfaces.CarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetLastThreeBlogsWithAuthorsQueryHandler : IRequestHandler<GetLastThreeBlogsWithAuthorsQuery, List<GetLastThreeBlogsWithAuthorsQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetLastThreeBlogsWithAuthorsQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLastThreeBlogsWithAuthorsQueryResult>> Handle(GetLastThreeBlogsWithAuthorsQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetLastThreeBlogsWithAuthors();
            return values.Select(x => new GetLastThreeBlogsWithAuthorsQueryResult
            {
                AuthorId = x.AuthorId,
                BlogId = x.BlogId,
                CategoryId = x.CategoryId,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                Title = x.Title,
                AuthorName = x.Author.AuthorName
            }).ToList();
        }
    }
}
