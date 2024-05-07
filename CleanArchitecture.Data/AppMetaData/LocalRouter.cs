namespace CleanArchitecture.Data.AppMetaData
{
    public static class LocalRouter
    {
        public const string root = "Api";
        public const string version = "v1";
        public const string Rule = $"{root}/{version}";

        public static class StudentRouting
        {
            public const string Prefix = $"{Rule}/Student";
            public const string List = $"{Prefix}/List";
            public const string PaginatedList = $"{Prefix}/PaginatedList";


            public const string GetByID = $"{Prefix}/{{Id}}";
            public const string Create = $"{Prefix}/Create";
            public const string Edit = $"{Prefix}/Edit";
            public const string Delete = $"{Prefix}/Delete/{{Id}}";

        }

        public static class DepartmentRouting
        {
            public const string Prefix = $"{Rule}/Department";

            public const string GetByID = $"{Prefix}/Id";
        }

        public static class UserRouting
        {
            public const string Prefix = $"{Rule}/User";
            public const string List = $"{Prefix}/List";
            public const string PaginatedList = $"{Prefix}/PaginatedList";


            public const string GetByID = $"{Prefix}/{{Id}}";
            public const string Create = $"{Prefix}/Create";
            public const string Edit = $"{Prefix}/Edit";
            public const string Delete = $"{Prefix}/Delete/{{Id}}";
            public const string ChangePassword = $"{Prefix}/ChangePassword";
        }

        //Authentication
        public static class Authentication
        {
            public const string Prefix = $"{Rule}/Authentication";
            public const string SignIn = $"{Prefix}/SignIn";
            public const string RefreshToken = $"{Prefix}/RefreshToken";
            public const string ValidateToken = $"{Prefix}/ValidateToken";

        }

        //Authorization
        public static class Authorization
        {
            public const string Prefix = $"{Rule}/Authorization";
            public const string Roles = Prefix + "/Role";
            public const string Claims = Prefix + "/Claim";
            public const string Create = $"{Roles}/Role/Create";
            public const string Edit = $"{Roles}/Role/Edit";
            public const string Delete = $"{Roles}/Role/Delete/{{Id}}";
            public const string List = $"{Roles}/List";
            public const string GetByID = $"{Roles}/{{Id}}";
            public const string ManageUserRoles = $"{Roles}/ManageUserRoles/{{userId}}";
            public const string UpdateUserRoles = $"{Roles}/UpdateUserRoles";
            public const string ManageUserCalims = $"{Claims}/ManageUserCalims/{{userId}}";
            public const string UpdateUserClaims = $"{Claims}/UpdateUserClaims";


            //

            //ValidateToken
        }
    }
}
