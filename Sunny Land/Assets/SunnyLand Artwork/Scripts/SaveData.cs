using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData : MonoBehaviour
{
    public int levelPass;
	public int numberOfItem;

	public SaveData() { }

	public SaveData(int levelPass, int numberOfItem)
	{
		this.levelPass = levelPass;
		this.numberOfItem = numberOfItem;
	}
	public void setDefault()
	{
		levelPass = 1;
		numberOfItem = 0;
	}
}
