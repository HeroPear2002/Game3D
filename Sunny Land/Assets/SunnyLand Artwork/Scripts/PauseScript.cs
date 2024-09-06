using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel, settingPanel;
    private bool isHideSetting = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
            if(settingPanel.activeInHierarchy)
			{
                hideSettingPanel();
			}
			if(!settingPanel.activeInHierarchy && pausePanel.activeInHierarchy)
			{
                hidePausePanel();
            }
		}
		if (Input.GetKeyDown(KeyCode.P))
		{
            showPausePanel();
		}
    }

    public void showPausePanel()
	{
        pausePanel.SetActive(true);
        Time.timeScale = 0;
	}

    public void hidePausePanel()
	{
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void showSetingPanel()
	{
        settingPanel.SetActive(true);
	}

    public void hideSettingPanel()
	{
        settingPanel.SetActive(false);
    }
}
