namespace OrangeBricks.Core.Infrastructure.Data
{
    public class Repository
    {
        public static class Factory
        {
            public static EfRepository Create()
            {
                return new EfRepository(ApplicationDbContext.Instance);
            }
        }
    }
}