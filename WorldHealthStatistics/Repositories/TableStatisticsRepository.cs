using Dapper;
using System.Data;
using WorldHealthStatistics.Context;
using WorldHealthStatistics.Dtos;
using X.PagedList;
using X.PagedList.Extensions;


namespace WorldHealthStatistics.Repositories
{
	public class TableStatisticsRepository : ITableStatisticsRepository
	{
		private readonly HealthContext _context;
		private readonly IDbConnection _connection;

		public TableStatisticsRepository(HealthContext context)
		{
			_context = context;
			_connection = _context.CreateConnection();
		}
		public async Task<IPagedList<ResultStatisticsDto>> GetTotalAffectedPopulation(int pageNumber, int pageSize)
		{
			string query = @" WITH DiseaseAffected AS (
							  SELECT DiseaseName,DiseaseCategory,AvailabilityOfVaccines,Year, 
							  CAST(PopulationAffected AS BIGINT) AS PopulationAffected,RecoveryRate,
							  ROW_NUMBER() OVER(PARTITION BY DiseaseName ORDER BY Year DESC) AS RowNum
							  FROM HealthData
							  WHERE Year >= YEAR(GETDATE()) - 5)
							  SELECT DiseaseName, DiseaseCategory, AvailabilityOfVaccines,SUM(PopulationAffected) AS TotalAffectedPopulation,
							  AVG(RecoveryRate) AS AvgRecoveryRate
							  FROM DiseaseAffected
							  WHERE RowNum = 1 
							  GROUP BY DiseaseName, DiseaseCategory, AvailabilityOfVaccines
							  ORDER BY TotalAffectedPopulation DESC
                              ";

		

			var result = await _connection.QueryAsync<ResultStatisticsDto>(query);

			return result.ToList().ToPagedList(pageNumber, pageSize);
		}

		
	}
}
