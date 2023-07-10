using UnityEngine;
using System.IO;

public class SaveResponse
{
	private static string projectName = "PROJECT_EAVR-DEMO-DDW";
	private static string dataDirectoryName = "Data"; //Change Directory to Folder
	private static string dataFileName = "Player2.csv";
	private static string dataSeparator = ",";
	private static string[] dataHeaders = new string[3] {
		"SceneIndex",
        "EnvironmentName",
		"Count",
	};
	private static string timeStampHeader = "TimeStamp";

	public static void AppendToData(string scenarioNumber) //Appends Scene number to data file
	{
		VerifyDirectory();
		VerifyFile();
		using (StreamWriter sw = File.AppendText(GetFilePath()))
			sw.WriteLine(scenarioNumber);
	}

	public static void AppendToData(string[] strings) //Append to Data file
	{
		VerifyDirectory();
		VerifyFile();
		using (StreamWriter sw = File.AppendText(GetFilePath()))
		{
			string finalString = "";
			for (int i = 0; i < strings.Length; i++)
			{
				if (finalString != "")
				{
					finalString += dataSeparator;
				}
				finalString += strings[i];
			}
			finalString += dataSeparator + GetTimeStamp();
			sw.WriteLine(finalString);
		}
	}

	public static void CreateData() //Creates the Data File 
	{
		VerifyDirectory();
		using (StreamWriter sw = File.CreateText(GetFilePath()))
		{
			string finalString = "";
			for (int i = 0; i < dataHeaders.Length; i++)
			{
				if (finalString != "")
				{
					finalString += dataSeparator;
				}
				finalString += dataHeaders[i];
			}
			finalString += dataSeparator + timeStampHeader;
			sw.WriteLine(finalString);
		}
	}

	static void VerifyDirectory() //Verfifies the directory in which file is stored 
	{
		string dir = GetDirectoryPath();
		if (!Directory.Exists(dir))
		{
			Directory.CreateDirectory(dir);
		}
	}

	static void VerifyFile()
	{
		string file = GetFilePath();

		if (!File.Exists(file))
		{
			CreateData();

		}

	}

	static string GetDirectoryPath()
	{
		return Application.dataPath + "Assets/" + projectName + "/" + dataDirectoryName;
	}

	static string GetFilePath()
	{
		return GetDirectoryPath() + "/" + dataFileName;
	}

	static string GetTimeStamp()
	{
		return System.DateTime.Now.ToString();
	}

}


