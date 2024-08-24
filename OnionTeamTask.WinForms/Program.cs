using Microsoft.Extensions.DependencyInjection;
using OnionTeamTask.DomainLayer.DomainModels;
using OnionTeamTask.RepositoryLayer.Implementation;
using OnionTeamTask.RepositoryLayer.Interface;
using OnionTeamTask.RepositoryLayer;
using OnionTeamTask.ServiceLayer.Implementation;
using OnionTeamTask.ServiceLayer.Interface;
using Microsoft.EntityFrameworkCore;

namespace OnionTeamTask.WinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Set up the service collection
            var serviceCollection = new ServiceCollection();

            // Register DbContext (assuming you have a connection string or configuration in place)

            serviceCollection.AddDbContext<TeamTaskManDbContext>(options =>
                options.UseSqlServer("Server=LEGION\\SQLEXPRESS;Database=TeamTaskManDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true;")); // Use your actual connection string

            /*
                         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
                        => optionsBuilder.UseSqlServer("Server=LEGION\\SQLEXPRESS;Database=TeamTaskManDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true;");
            */
            // Register repositories
            serviceCollection.AddScoped<IRepository<Taskd>, Repository<Taskd>>();
            serviceCollection.AddScoped<IRepository<Category>, Repository<Category>>();
            serviceCollection.AddScoped<IRepository<Status>, Repository<Status>>();

            // Register services
            serviceCollection.AddScoped<ITaskService, TaskService>();
            serviceCollection.AddScoped<ICategoryService, CategoryService>();
            serviceCollection.AddScoped<IStatusService, StatusService>();

            // Build the service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Resolve services
            var taskService = serviceProvider.GetRequiredService<ITaskService>();
            var categoryService = serviceProvider.GetRequiredService<ICategoryService>();
            var statusService = serviceProvider.GetRequiredService<IStatusService>();

            // Run the main form with services injected
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(taskService, categoryService, statusService));
        }
    }
}