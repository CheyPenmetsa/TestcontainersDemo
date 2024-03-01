namespace ResidentApi.Logic.Database
{
    public class DatabaseInitializer
    {
        private readonly ResidentDbContext _dbContext;

        public DatabaseInitializer(ResidentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InitializeAsync()
            => await _dbContext.Database.EnsureCreatedAsync();
    }
}
