using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanelScrip : MonoBehaviour
{
    [SerializeField] Button buttonMusic, buttonSound;
    [SerializeField] Toggle toggleFullScreen;
    [SerializeField] Sprite imageMusicOn, imageMusicOff, imageSoundOn, imageSoundOff, imageFullScreenOn, imageFullScreenOff;
    private int currentButton = 1;
    // Start is called before the first frame update
    void Start()
    {
        if (StaticData.isMusic)
        {
            buttonMusic.image.sprite = imageMusicOn;
        }
        else
        {
            buttonMusic.image.sprite = imageMusicOff;
        }
		if (StaticData.isSound)
		{
            buttonSound.image.sprite = imageSoundOn;
		}
		else
		{
            buttonSound.image.sprite = imageSoundOff;
		}
        if (StaticData.isFullScreen)
		{
            toggleFullScreen.image.sprite = imageFullScreenOn;
		}
		else
		{
            toggleFullScreen.image.sprite = imageFullScreenOff;
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
