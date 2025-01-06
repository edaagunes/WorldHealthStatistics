using WorldHealthStatistics.Context;
using WorldHealthStatistics.Repositories;

namespace WorldHealthStatistics.Containers
{
	public static class Extensions
	{
		public static void ContainerDependencies(this IServiceCollection services)
		{
			services.AddScoped<HealthContext>();

			services.AddScoped<IStatusStatisticsRepository, StatusStatisticsRepository>();
			services.AddScoped<IGraphicStatisticsRepository, GraphicStatisticsRepository>();
		}
	}
}
