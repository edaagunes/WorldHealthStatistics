using Dapper;
using NuGet.Protocol.Plugins;
using System.Data;
using WorldHealthStatistics.Context;
using WorldHealthStatistics.Dtos;
using WorldHealthStatistics.Models.StatisticsViewModel;

namespace WorldHealthStatistics.Repositories
{
	public class StatusStatisticsRepository : IStatusStatisticsRepository
	{
		private readonly HealthContext _context;
		private readonly IDbConnection _connection;

		public StatusStatisticsRepository(HealthContext context)
		{
			_context = context;
			_connection = _context.CreateConnection();
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

			_connection.Open();

			var result = await _connection.QueryFirstOrDefaultAsync<ResultStatisticsDto>(query);
			return result;

		}

		public async Task<ResultStatisticsDto> GetTopDoctorCountInTurkey()
		{
			string query = @" SELECT TOP 1 Year, MAX(DoctorsPer1000) AS MaxDoctorsPer1000
							  FROM HealthData
							  WHERE Country = 'Turkey' AND Year BETWEEN 2000 AND 2023
							  GROUP BY Year
							  ORDER BY MaxDoctorsPer1000 DESC;";

			var result = await _connection.QueryFirstOrDefaultAsync<ResultStatisticsDto>(query);
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



			var result = await _connection.QueryAsync<ResultStatisticsDto>(query);
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

			var femaleDiseases = await _connection.QueryFirstOrDefaultAsync<ResultStatisticsDto>(femaleQuery);
			var maleDiseases = await _connection.QueryFirstOrDefaultAsync<ResultStatisticsDto>(maleQuery);

			return new StatusStatisticsViewModel
			{
				FemaleMostCommonDiseases = femaleDiseases,
				MaleMostCommonDiseases = maleDiseases
			};
		}

		public async Task<ResultStatisticsDto> GetMostCommonDiseasesByWorld()
		{
			string query = @"SELECT TOP 1 DiseaseName, TreatmentType, COUNT(*) AS Frequency
							 FROM HealthData
						     GROUP BY DiseaseName, TreatmentType
							 ORDER BY Frequency DESC; 
							";

			var result = await _connection.QueryFirstOrDefaultAsync<ResultStatisticsDto>(query);
			return result;
		}

		public async Task<ResultStatisticsDto> GetLeastCommonDiseasesByWorldWithCost()
		{
			string query = @"SELECT TOP 1 DiseaseName, AVG(AverageTreatmentCost) AS AvgTreatmentCost
							 FROM HealthData
							 GROUP BY DiseaseName
							 ORDER BY SUM(CAST(PopulationAffected AS BIGINT)) ASC;
							";
			var result = await _connection.QueryFirstOrDefaultAsync<ResultStatisticsDto>(query);
			return result;
		}

		public async Task<List<ResultStatisticsDto>> GetMostCommonDiseaseCategoryByWorldWithUrbanization()
		{
			string query = @"SELECT TOP 3 DiseaseCategory, 
							 AVG(MortalityRate) AS AvgMortalityRate, 
							 AVG(UrbanizationRate) AS AvgUrbanizationRate
							 FROM HealthData
							 GROUP BY DiseaseCategory
							 ORDER BY AvgUrbanizationRate desc;
							 ";
			var result = await _connection.QueryAsync<ResultStatisticsDto>(query);
			return result.ToList();
		}

		public async Task<List<ResultStatisticsDto>> GetMostCommonDiseasesByAgeGroup()
		{
			string query = @"WITH RankedDiseases AS (
							 SELECT AgeGroup, DiseaseName,
							 SUM(CAST(PopulationAffected AS BIGINT)) AS TotalAffected,
							 ROW_NUMBER() OVER (PARTITION BY AgeGroup ORDER BY SUM(CAST(PopulationAffected AS BIGINT)) DESC) AS RowNum
							 FROM HealthData
							 WHERE AgeGroup IN ('0-18', '19-35', '36-60', '61+')
							 GROUP BY AgeGroup, DiseaseName
							 )
							SELECT AgeGroup, DiseaseName, TotalAffected
							FROM RankedDiseases
							WHERE RowNum = 1;
							";
			var result = await _connection.QueryAsync<ResultStatisticsDto>(query);
			return result.ToList();
		}
	}
}
