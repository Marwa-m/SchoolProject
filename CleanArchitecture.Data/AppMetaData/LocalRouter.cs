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
        }
    }
}
