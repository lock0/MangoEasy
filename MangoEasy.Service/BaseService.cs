namespace MangoEasy.Service
{
    public class BaseService
    {
        public readonly MongoDbApiDataContext DbContext;

        public BaseService(MongoDbApiDataContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
