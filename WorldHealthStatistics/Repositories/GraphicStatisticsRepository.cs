using Dapper;
using System.Data;
using WorldHealthStatistics.Context;
using WorldHealthStatistics.Dtos;

namespace WorldHealthStatistics.Repositories
{
	public class GraphicStatisticsRepository : IGraphicStatisticsRepository
	{
		private readonly HealthContext _context;
		private readonly IDbConnection _connection;

		public GraphicStatisticsRepository(HealthContext context)
		{
			_context = context;
			_connection = _context.CreateConnection();
		}
		public async Task<List<ResultStatisticsDto>> GetCommonCountryByDiabetes()
		{
			string query = @" SELECT Top 10 Country,
							  SUM(PrevalenceRate) AS TotalPrevalenceRate
                              FROM HealthData
							  WHERE DiseaseName = 'Diabetes'
							  GROUP BY Country
							  ORDER BY TotalPrevalenceRate DESC
                              ";

			_connection.Open();

			var result = await _connection.QueryAsync<ResultStatisticsDto>(query);
			return result.ToList();

		}

		public async Task<List<ResultStatisticsDto>> GetLast5YearsDiseases()
		{
			string query = @"WITH RankedDiseases AS (
                             SELECT DiseaseName, Year,PrevalenceRate,RANK() OVER (
                             PARTITION BY Year 
                             ORDER BY 
                             CASE 
                             WHEN Year = 2020 AND DiseaseName = 'COVID-19' THEN 1
                             ELSE 0
                             END DESC,
                             PrevalenceRate DESC, 
                             DiseaseName
                             ) AS Rank
                             FROM HealthData
                             WHERE Country = 'Turkey'
                             AND Year BETWEEN 2019 AND 2023)
                             SELECT Year, DiseaseName, PrevalenceRate
                             FROM RankedDiseases
                             WHERE Rank = 1
                             ORDER BY Year";

			var result = await _connection.QueryAsync<ResultStatisticsDto>(query);
			return result.ToList();
		}

		public async Task<List<ResultStatisticsDto>> GetMostCommonLast5YearsDiseases()
		{
			string query = @"WITH DiseaseYearFrequency AS (
                             SELECT DiseaseName,Year,COUNT(*) AS Frequency,
                             AVG(MortalityRate) AS AvgMortalityRate
                             FROM HealthData
                             WHERE Country = 'Turkey'
                             GROUP BY DiseaseName, Year)
                             SELECT DiseaseName,Year,AvgMortalityRate
							 FROM DiseaseYearFrequency
							 WHERE Year IN (
							       SELECT TOP 1 Year 
								   FROM DiseaseYearFrequency AS InnerTable
								   WHERE InnerTable.DiseaseName = DiseaseYearFrequency.DiseaseName
								   ORDER BY Frequency DESC
							)
							ORDER BY AvgMortalityRate DESC";

			var result = await _connection.QueryAsync<ResultStatisticsDto>(query);
			return result.ToList();
		}
	}
}
