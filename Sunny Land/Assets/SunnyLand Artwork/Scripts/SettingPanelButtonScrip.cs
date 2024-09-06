using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanelButtonScrip : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] Sprite imageOn, imageOff;
    [SerializeField] bool isMusic, isSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
		if (isMusic)
		{
            if (StaticData.isMusic)
            {
                StaticData.isMusic = false;
                button.image.sprite = imageOff;
            }
            else
            {
                StaticData.isMusic = true;
                button.image.sprite = imageOn;
            }
        }
		if (isSound)
		{
            if (StaticData.isSound)
            {
                StaticData.isSound = false;
                button.image.sprite = imageOff;
            }
            else
            {
                StaticData.isSound = true;
                button.image.sprite = imageOn;
            }
        }
    }
}
