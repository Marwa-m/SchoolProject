namespace CleanArchitecture.Data.Results
{
    public class ManageUserClaimsResult
    {
        public int UserId
        {
            get; set;
        }

        public List<UserClaim> UserClaims { get; set; } = new();

        public class UserClaim
        {
            public UserClaim(string type)
            {
                Type = type;
            }

            public string Type { get; set; }
            public bool Value { get; set; } = false;
            // public bool HasClaim { get; set; } = false;

        }
    }
}
