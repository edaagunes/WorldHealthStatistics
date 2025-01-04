using Dapper;
using NuGet.Protocol.Plugins;
using WorldHealthStatistics.Context;
using WorldHealthStatistics.Dtos;
using WorldHealthStatistics.Models.StatisticsViewModel;

namespace WorldHealthStatistics.Repositories
{
	public class StatisticsRepository : IStatisticsRepository
	{
		private readonly HealthContext _context;

		public StatisticsRepository(HealthContext context)
		{
			_context = context;
		}

		public async Task<ResultStatisticsDto> GetMostCommonDiseaseInTurkey()
		{
			string query = @" SELECT TOP 1
							  DiseaseName,
							  AVG(PrevalenceRate) AS AveragePrevalenceRate
							  FROM HealthData
							  WHERE Country = 'Turkey'
							  GROUP BY DiseaseName
							  ORDER BY AVG(PrevalenceRate) DESC;";

			using var connection = _context.CreateConnection();
			connection.Open();

			var result = await connection.QueryFirstOrDefaultAsync<ResultStatisticsDto>(query);
			return result;

		}

		public async Task<ResultStatisticsDto> GetTopDoctorCountInTurkey()
		{
			string query = @" SELECT TOP 1 Year, MAX(DoctorsPer1000) AS MaxDoctorsPer1000
							  FROM HealthData
							  WHERE Country = 'Turkey' AND Year BETWEEN 2000 AND 2023
							  GROUP BY Year
							  ORDER BY MaxDoctorsPer1000 DESC;";

			using var connection = _context.CreateConnection();
			connection.Open();

			var result = await connection.QueryFirstOrDefaultAsync<ResultStatisticsDto>(query);
			return result;
		}
		public async Task<List<ResultStatisticsDto>> GetRecoveryRateEduIndexInTurkey()
		{
			string query = @" SELECT TOP 3 DiseaseName, AVG(RecoveryRate) AS AvgRecoveryRate, AVG(EducationIndex) AS AvgEducationIndex
							  FROM HealthData
                              WHERE Country = 'Turkey'
                              GROUP BY DiseaseName
                              HAVING AVG(EducationIndex) > 0.5 AND AVG(RecoveryRate) > 60
                              ORDER BY AvgRecoveryRate DESC;
                              ";

			using var connection = _context.CreateConnection();
			connection.Open();

			var result = await connection.QueryAsync<ResultStatisticsDto>(query);
			return result.ToList();
		}

		public async Task<StatusStatisticsViewModel> GetMostCommonDiseasesByGender()
		{
			string femaleQuery = @" SELECT TOP 1 DiseaseName, AVG(PrevalenceRate) AS AvgPrevalenceRate
									FROM HealthData
									WHERE Country = 'Turkey' AND Gender = 'Female'
									GROUP BY DiseaseName
									ORDER BY AvgPrevalenceRate DESC;
								  ";

			string maleQuery = @" SELECT TOP 1 DiseaseName, AVG(PrevalenceRate) AS AvgPrevalenceRate
								  FROM HealthData
								  WHERE Country = 'Turkey' AND Gender = 'Male'
								  GROUP BY DiseaseName
								  ORDER BY AvgPrevalenceRate DESC;
								  ";

			using var connection = _context.CreateConnection();
			connection.Open();

			var femaleDiseases = await connection.QueryFirstOrDefaultAsync<ResultStatisticsDto>(femaleQuery);
			var maleDiseases = await connection.QueryFirstOrDefaultAsync<ResultStatisticsDto>(maleQuery);

			return new StatusStatisticsViewModel
			{
				FemaleMostCommonDiseases = femaleDiseases,
				MaleMostCommonDiseases = maleDiseases
			};
		}
	}
}
