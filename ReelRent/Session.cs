namespace ReelRent
{
    public static class Session
    {
        public static User CurrentUser { get; set; }

        public static bool IsAuthenticated => CurrentUser != null;
        public static bool IsAdmin => IsAuthenticated && CurrentUser.IsAdmin;
    }
}