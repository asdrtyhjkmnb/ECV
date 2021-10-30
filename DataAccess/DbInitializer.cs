namespace DataAccess
{
    public static class DbInitializer
    {
        public static void Initialize(ECVCoreContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
