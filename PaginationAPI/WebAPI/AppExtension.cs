namespace WebAPI
{
    public static class AppExtension
    {
        public static async Task Seed(this WebApplication application)
        {
            var scope = application.Services.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<Seeder>();

            await seeder.Seed();
        }
    }
}
