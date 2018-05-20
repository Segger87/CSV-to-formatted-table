using System;

namespace StringCSVTable
{
	class Program
	{
		static void Main(string[] args)
		{
			//I know using a + to concat is expensive on performance but I have concatenated this string for cleaner code
			string csvString = "Publication Date,Title,Authors," +
				"28 / 11 / 2008,Learning C# 3.0,Jesse Liberty & Brian MacDonald," +
				"16 / 09 / 2013,Head First C#,Jennifer Greene & Andrew Stellman," +
				"27 / 10 / 2015,Learn C# in One Day and Learn It Well: C# for Beginners with Hands-on Project: Volume 3,Jamie Chan";

			csvString = csvString.Replace("Publication Date", "Pub Date");
			var csvData = csvString.Split(',');

			for (int i = 0; i < csvData.Length; i++)
			{
				if (i % 3 == 0)
				{
					Console.WriteLine(String.Format("|{0,-15}|{1, -25}|{2, -25}|", TruncateString(csvData[i]),
																				TruncateString(csvData[i + 1]),
																				TruncateString(csvData[i + 2])));
				}
			}

			Console.ReadLine();
		}
		public static string TruncateString(string csv)
		{
			string seperator = "|\n|===================================================================";
			if (csv.Contains("Authors"))
			{
				//the contains method is a bad idea because if any other column introduces the word author it will add the seperator
				return String.Format("{0, -25}{1,-25}", csv, seperator);
			}
			if (csv.Length >= 20)
			{
				return csv.Substring(0, 20) + "...";
			}
			return csv;
		}
	}
}
