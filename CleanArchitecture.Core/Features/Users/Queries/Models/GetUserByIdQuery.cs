using CleanArchitecture.Core.Bases;
using CleanArchitecture.Core.Features.Users.Queries.Results;
using MediatR;

namespace CleanArchitecture.Core.Features.Users.Queries.Models
{
    public class GetUserByIdQuery : IRequest<Response<GetUserByIdResponse>>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
