//using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonDataService /*: IDataService*/
{
	public bool SaveData<T>(string RelativePath, T data)
	{
		string path = Application.persistentDataPath + RelativePath;
		try
		{
			if (File.Exists(path))
			{
				Debug.Log("Data exists. Deleting old file and writing a new one!");
				File.Delete(path);
			}
			else
			{
				Debug.Log("Writing file for the first time!");
			}
			
			using FileStream stream = File.Create(path);
			stream.Close();
			string json = JsonUtility.ToJson(data);
			File.WriteAllText(path, json);
			//File.WriteAllText(path, JsonConvert.SerializeObject(data));
			return true;
		}
		catch (Exception e)
		{
			Debug.LogError($"Unable to save data due to : {e.Message} {e.StackTrace}");
			return false;
		}
		
	}
	//public T LoadData<T>(string RelativePath)
	//{
	//	string path = Application.persistentDataPath + RelativePath;
	//	if (!File.Exists(path))
	//	{
	//		//Debug.LogError($"Cannot load file at {path}. File does not exist!");
	//		using FileStream stream = File.Create(path);
	//		stream.Close();
	//		//string json = JsonUtility.ToJson(new SaveData(1,0));
	//		//File.WriteAllText(path, json);
	//		//throw new FileNotFoundException($"{path} does not exist !");
	//	}
	//	try
	//	{
	//		T data = JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
	//		return data;
	//	}catch(Exception e)
	//	{
	//		Debug.LogError($"Failed to load data due to : {e.Message} {e.StackTrace}");
	//		throw e;
	//	}
	//}

}
