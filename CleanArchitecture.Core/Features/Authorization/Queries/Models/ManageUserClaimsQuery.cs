using CleanArchitecture.Core.Bases;
using CleanArchitecture.Data.Results;
using MediatR;

namespace CleanArchitecture.Core.Features.Authorization.Queries.Models
{
    public class ManageUserClaimsQuery : IRequest<Response<ManageUserClaimsResult>>
    {
        public int UserId { get; set; }
    }
}
