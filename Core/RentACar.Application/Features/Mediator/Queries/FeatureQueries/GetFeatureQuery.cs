using MediatR;
using RentACar.Application.Features.Mediator.Results.FeatureResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Queries.FeatureQueries
{
    public class GetFeatureQuery : IRequest<List<GetFeatureQueryResult>> //CQRS'da listeleme işlemi gerçekleştirirken query tarafında herhangi bir sınıfını oluşturmuyorduk. Ama burada oluşturmak gerekiyor. Çünkü bunu mediator üzerinden yönetebilmek için. / IRequest çağrıldığı zaman bir liste olarak bana GetFeatureQueryResult geriye döndür.
    {

    }
}
