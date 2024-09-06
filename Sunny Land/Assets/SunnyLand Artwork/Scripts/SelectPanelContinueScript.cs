using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPanelContinueScript : MonoBehaviour
{
    // Start is called before the first frame update
    private int currentButton = 1;
    [SerializeField] private string selectLevel;
    [SerializeField] private GameObject SettingPanel;
    [SerializeField] private TextMeshProUGUI Continue, newGame, setting, exit;
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
                newGame.color = new Color32(248, 188, 0, 255);
                setting.color = new Color32(248, 188, 0, 255);
                exit.color = new Color32(248, 188, 0, 255);
                Continue.color = new Color32(255, 131, 0, 255);
            }
            if (currentButton == 2)
            {
                Continue.color = new Color32(248, 188, 0, 255);
                setting.color = new Color32(248, 188, 0, 255);
                exit.color = new Color32(248, 188, 0, 255);
                newGame.color = new Color32(255, 131, 0, 255);
            }
            if (currentButton == 3)
            {
                Continue.color = new Color32(248, 188, 0, 255);
                newGame.color = new Color32(248, 188, 0, 255);
                exit.color = new Color32(248, 188, 0, 255);
                setting.color = new Color32(255, 131, 0, 255);
            }
            if (currentButton == 4)
            {
                Continue.color = new Color32(248, 188, 0, 255);
                newGame.color = new Color32(248, 188, 0, 255);
                setting.color = new Color32(248, 188, 0, 255);
                exit.color = new Color32(255, 131, 0, 255);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (StaticData.isSound) pressSound.Play();
            currentButton++;
            if (currentButton > 4)
            {
                currentButton = 1;
            }
            if (currentButton == 1)
            {
                exit.color = new Color32(248, 188, 0, 255);
                Continue.color = new Color32(255, 131, 0, 255);
            }
            if (currentButton == 2)
            {
                Continue.color = new Color32(248, 188, 0, 255);
                newGame.color = new Color32(255, 131, 0, 255);
            }
            if (currentButton == 3)
            {
                newGame.color = new Color32(248, 188, 0, 255);
                setting.color = new Color32(255, 131, 0, 255);
            }
            if(currentButton == 4)
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
                currentButton = 4;
            }
            if (currentButton == 1)
            {
                Continue.color = new Color32(255, 131, 0, 255);
                newGame.color = new Color32(248, 188, 0, 255);
            }
            if (currentButton == 2)
            {
                newGame.color = new Color32(255, 131, 0, 255);
                setting.color = new Color32(248, 188, 0, 255);
            }
            if (currentButton == 3)
            {
                setting.color = new Color32(255, 131, 0, 255);
                exit.color = new Color32(248, 188, 0, 255);
            }
            if (currentButton == 4)
            {
                Continue.color = new Color32(248, 188, 0, 255);
                exit.color = new Color32(255, 131, 0, 255);
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) && this.isActiveAndEnabled)
        {
            if (currentButton == 1)
            {
                SceneManager.LoadScene(selectLevel);
                Debug.Log("Continue");
            }
            if (currentButton == 2)
            {
                SceneManager.LoadScene(selectLevel);
                Debug.Log("New game");
            }
            if (currentButton == 3)
            {
                displaySettingPanel();
                Debug.Log("SettingScreen");
            }
            if (currentButton == 4)
            {
                Application.Quit();
                Debug.Log("Exit");
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape) && SettingPanel.activeInHierarchy)
        {
            SettingPanel.SetActive(false);
        }
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
