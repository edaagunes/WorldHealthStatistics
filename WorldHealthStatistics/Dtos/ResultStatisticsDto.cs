using System.Diagnostics.Metrics;

namespace WorldHealthStatistics.Dtos
{
	public class ResultStatisticsDto
	{
        public string Country { get; set; }
        public int Year { get; set; }
        public string DiseaseName { get; set; }
        public string DiseaseCategory { get; set; }
        public decimal PrevalenceRate { get; set; }
        public decimal IncidenceRate { get; set; }
        public decimal MortalityRate { get; set; }
        public string AgeGroup { get; set; }
        public string Gender { get; set; }
        public int PopulationAffected { get; set; }
        public decimal HealthcareAccess { get; set; }
        public decimal DoctorsPer1000 { get; set; }
        public decimal HospitalBedsPer1000 { get; set; }
        public string TreatmentType { get; set; }
        public decimal AverageTreatmentCost { get; set; }
        public string AvailabilityOfVaccines { get; set; }
        public decimal RecoveryRate { get; set; }
        public decimal DALYs { get; set; }
        public decimal ImprovementIn5Years { get; set; }
        public decimal PerCapitaIncome { get; set; }
        public decimal EducationIndex { get; set; }
        public decimal UrbanizationRate { get; set; }

	}
}
