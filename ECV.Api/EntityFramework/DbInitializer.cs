using ECV.Api.EntityFramework.Contexts;

namespace ECV.Api.EntityFramework
{
    public static class DbInitializer
    {
        public static void Initialize(ECVContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
