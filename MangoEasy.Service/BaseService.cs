namespace MangoEasy.Service
{
    public class BaseService
    {
        public readonly MangoEasyDataContext DbContext;

        public BaseService(MangoEasyDataContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
