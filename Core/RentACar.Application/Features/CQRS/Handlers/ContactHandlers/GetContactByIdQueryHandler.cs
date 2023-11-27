using RentACar.Application.Features.CQRS.Queries.ContactQueries;
using RentACar.Application.Features.CQRS.Results.ContactResults;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery getContactByIdQuery)
        {
            var value = await _repository.GetByIdAsync(getContactByIdQuery.Id);
            return new GetContactByIdQueryResult
            {
                ContactId = value.ContactId,
                Email = value.Email,
                Message = value.Message,
                Name = value.Name,
                SendDate = value.SendDate,
                Subject = value.Subject
            };
        }
        
    }
}
