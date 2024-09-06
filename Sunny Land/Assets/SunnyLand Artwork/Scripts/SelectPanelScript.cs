using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class SelectPanelScript : MonoBehaviour
{
    // Start is called before the first frame update
    private int currentButton = 1;
    [SerializeField] private string selectLevel;
    [SerializeField] private GameObject SettingPanel;
    [SerializeField] private TextMeshProUGUI newGame, setting, exit;
    [SerializeField] private AudioSource pressSound;
    public bool isHover = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (isHover)
		{
            if (currentButton == 1)
            {
                exit.color = new Color32(248, 188, 0, 255);
                setting.color = new Color32(248, 188, 0, 255);
                newGame.color = new Color32(255, 131, 0, 255);
            }
            if (currentButton == 2)
            {
                newGame.color = new Color32(248, 188, 0, 255);
                exit.color = new Color32(248, 188, 0, 255);
                setting.color = new Color32(255, 131, 0, 255);
            }
            if (currentButton == 3)
            {
                setting.color = new Color32(248, 188, 0, 255);
                newGame.color = new Color32(248, 188, 0, 255);
                exit.color = new Color32(255, 131, 0, 255);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (StaticData.isSound) pressSound.Play();
            currentButton++;
            if (currentButton > 3)
            {
                currentButton = 1;
            }
            if (currentButton == 1)
            {
                exit.color = new Color32(248, 188, 0, 255);
                newGame.color = new Color32(255, 131, 0, 255);
            }
            if (currentButton == 2)
            {
                newGame.color = new Color32(248, 188, 0, 255);
                setting.color = new Color32(255, 131, 0, 255);
            }
            if (currentButton == 3)
            {
                setting.color = new Color32(248, 188, 0, 255);
                exit.color = new Color32(255, 131, 0, 255);
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (StaticData.isSound) pressSound.Play();
            currentButton--;
            if (currentButton < 1)
            {
                currentButton = 3;
            }
            if (currentButton == 1)
            {
                newGame.color = new Color32(255, 131, 0, 255);
                setting.color = new Color32(248, 188, 0, 255);
            }
            if (currentButton == 2)
            {
                setting.color = new Color32(255, 131, 0, 255);
                exit.color = new Color32(248, 188, 0, 255);
            }
            if (currentButton == 3)
            {
                newGame.color =  new Color32(248, 188, 0, 255);
                exit.color = new Color32(255, 131, 0, 255);
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) && this.isActiveAndEnabled)
        {
            //if(currentButton == 1) {
            //    SceneManager.LoadScene(selectLevel);
            //    SaveData saveData = new SaveData(1, 0);
            //    IDataService dataService = new JsonDataService();
            //    dataService.SaveData("/data.json", saveData);
            //    Debug.Log("LevelScreen");
            //}
            if(currentButton == 2)
            {
                displaySettingPanel();
                Debug.Log("SettingScreen");
            }
            if(currentButton == 3)
            {
                Application.Quit();
                Debug.Log("Exit");
            }
        }
        if(Input.GetKeyDown(KeyCode.Escape) && SettingPanel.activeInHierarchy)
        {
            SettingPanel.SetActive(false);
        }
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
    public void displaySettingPanel()
    {
        SettingPanel.SetActive(true);
    }
}
