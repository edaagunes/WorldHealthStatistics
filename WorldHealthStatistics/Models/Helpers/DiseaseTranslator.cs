namespace WorldHealthStatistics.Models.Helpers
{
	public static class DiseaseTranslator
	{
		public static string TranslateDiseaseName(string diseaseName)
		{
			var dictionary = new Dictionary<string, string>
			{
				{"Polio", "Çocuk Felci"},
				{"Alzheimer's Disease", "Alzheimer Hastalığı"},
				{"Leprosy", "Cüzzam"},
				{"Hepatitis", "Hepatit"},
				{"COVID-19", "COVID-19"},
				{"Zika", "Zika"},
				{"Malaria", "Sıtma"},
				{"Hypertension", "Yüksek Tansiyon"},
				{"Cancer", "Kanser"},
				{"Diabetes", "Diyabet"},
				{"Rabies", "Kuduz"},
				{"Measles", "Kızamık"},
				{"Cholera", "Kolera"},
				{"Tuberculosis", "Verem"},
				{"Dengue", "Dang Humması"},
				{"Ebola", "Ebola"},
				{"Parkinson's Disease", "Parkinson Hastalığı"},
				{"HIV/AIDS", "HIV/AIDS"},
				{"Asthma", "Astım"},
				{"Influenza", "Grip"}
			};

			return dictionary.ContainsKey(diseaseName) ? dictionary[diseaseName] : diseaseName;
		}

		public static string TranslateCategory(string category)
		{
			var categoryDictionary = new Dictionary<string, string>
			{
				{"Respiratory", "Solunum Yolu"},
				{"Infectious", "Bulaşıcı"},
				{"Metabolic", "Metabolik"},
				{"Viral", "Viral"},
				{"Cardiovascular", "Kardiyovasküler"},
				{"Genetic", "Genetik"},
				{"Autoimmune", "Otoimmün"},
				{"Bacterial", "Bakteriyel"},
				{"Parasitic", "Parazitik"}
			};

			return categoryDictionary.ContainsKey(category) ? categoryDictionary[category] : category;
		}
	}
}
