using System.Security.Claims;

namespace CleanArchitecture.Data.Helper
{
    public static class ClaimStore
    {
        public static List<Claim> Claims = new()
        {
            new Claim("Create Student","false"),
            new Claim("Edit Student","false"),
            new Claim("Delete Student","false"),
        };

    }
}
