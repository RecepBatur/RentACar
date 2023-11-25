using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Queries.AboutQueries
{
    public class GetAboutByIdQuery
    {
        public GetAboutByIdQuery(int id) //Diğer tarafta bir nesne üzerinden bu Id'yi çağıracağım için constructor metodunu oluşturdum.
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
