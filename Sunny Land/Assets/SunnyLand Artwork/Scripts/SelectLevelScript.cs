using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevelScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] listTextMesh;
    private int currentButton = 0;
    private int currentIndexI = 0, currentIndexJ = 0;
    private int[,] arrayControll = new int[,] { {1, 2, 3 }, {4, 5, 6 } };
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        try
        {
            //IDataService dataService = new JsonDataService();
            //SaveData loadSave = dataService.LoadData<SaveData>("/data.json");
            //StaticData.levelPass = loadSave.levelPass;
           // StaticData.numberOfItem = loadSave.numberOfItem;
        }
        catch (Exception e)
        {
            Debug.LogError($"Could not read file!");
        }
        for (int i = 0; i < listTextMesh.Length; i++)
		{
			if (i + 1 <= StaticData.levelPass)
			{
				listTextMesh[i].text = (i + 1).ToString();
			}
			else
			{
				listTextMesh[i].text = "?";
			}
            if(i + 1 == listTextMesh.Length)
			{
                listTextMesh[i].text = "...";
            }
		}
		//      setAllDefaultColor();
		//      listTextMesh[currentButton].color = new Color32(248, 188, 0, 255);
	}

    // Update is called once per frame
    void Update()
    {
   //     if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
   //     {
   //         currentIndexJ++;
   //         if (currentIndexJ > 2)
   //         {
   //             currentIndexJ = 0;
   //             currentIndexI = 1;
   //         }
   //         if(currentIndexJ > 5)
			//{
   //             currentIndexI = 0;
   //             currentIndexJ = 0;
			//}
   //     }
   //     if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
   //     {
   //         currentIndexJ--;
   //         if (currentIndexJ < 0)
   //         {
   //             currentIndexJ = 5;
   //             currentIndexI = 5;
   //         }
   //     }
   //     if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
   //     {
   //         currentIndexI--;
   //         if (currentIndexI < 1)
   //         {
   //             currentIndexI = 0;
   //         }
   //     }
   //     if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
   //     {
   //         currentIndexI++;
   //         if (currentIndexI > 1)
   //         {
   //             currentIndexI = 1;
   //         }
   //     }
   //     setAllDefaultColor();
   //     Debug.Log(currentIndexI + "~" + currentIndexJ);
   //     listTextMesh[arrayControll[currentIndexI, currentIndexJ] - 1].color = new Color32(248, 188, 0, 255);
    }
	private void FixedUpdate()
	{
        
    }
	public int getCurrentButton()
    {
        return currentButton;
    }

    public void setCurrentButton(int current)
    {
        currentButton = current;
    }

    private void setAllDefaultColor()
	{
        for(int i = 0; i < listTextMesh.Length; i++)
		{
            listTextMesh[i].color = new Color32(255, 131, 0, 255);
        }
	}
}
