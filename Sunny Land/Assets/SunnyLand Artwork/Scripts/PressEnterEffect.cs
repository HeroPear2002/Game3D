using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressEnterEffect : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject pressEnterText,selectPanel, selectPanelContinue;
    [SerializeField] private AudioSource pressSound;
    [SerializeField] private float timeAppear = 1f,timeDisappear = 1f;
    private bool isStart = false, isEnd;

	private void Start()
	{
        Time.timeScale = 1;
	}

	// Update is called once per frame
	void Update()
    {
        if(isStart == false)
        {
            StartCoroutine(TextDisappear());
        }
        if(isEnd == false)
        {
            StartCoroutine(TextAppear());
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            if(StaticData.isSound) pressSound.Play();
			Destroy(pressEnterText);
			//IDataService dataService = new JsonDataService();
			//SaveData saveData = new SaveData(1, 120);
			//if (dataService.SaveData("/data.json", saveData))
			//{
			try
			{
                 //SaveData loadSave = dataService.LoadData<SaveData>("/data.json");
                 //StaticData.levelPass = loadSave.levelPass;
                 //StaticData.numberOfItem = loadSave.numberOfItem;
                 //if (loadSave.levelPass.Equals(1))
                // {
                 //   selectPanel.SetActive(true);
                 //}
                 //else
                 //{
                 //   selectPanelContinue.SetActive(true);
                 //}
            }
            catch (Exception e)
				{
                    Debug.LogError($"Could not read file!");
				}
			//}
			//else
			//	{
			//              Debug.LogError("Coudl not save file! ");
			//	}
		}
	}

    IEnumerator TextDisappear()
    {
        if(pressEnterText != null)
        {
            isStart = true;
            pressEnterText.SetActive(false);
            yield return new WaitForSeconds(timeDisappear);
            isStart = false;
            isEnd = false;
        }
    }
    IEnumerator TextAppear()
    {
        if (pressEnterText != null)
        {
            isEnd = false;
            pressEnterText.SetActive(true);
            yield return new WaitForSeconds(timeAppear);
            isEnd = true;
        }
    }
}
