using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataService
{
	bool SaveData<T>(string RelativePath, T data);
	T LoadData<T>(string RelativePath);
}
