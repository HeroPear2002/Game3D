using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanelToggleScript : MonoBehaviour
{
    private Toggle toggle;
    [SerializeField] Sprite imageOn, imageOff;
    // Start is called before the first frame update
    void Start()
    {
        toggle = GetComponent<Toggle>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeValue()
	{
        if (toggle.isOn)
        {
            StaticData.isFullScreen = true;
            toggle.image.sprite = imageOn;
            Screen.fullScreen = true;
        }
        else { 
            StaticData.isFullScreen = false;
            toggle.image.sprite = imageOff;
            Screen.fullScreen = false;
        }
    }
}
