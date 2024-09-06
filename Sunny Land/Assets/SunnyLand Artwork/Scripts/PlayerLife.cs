using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int playerLife = 3;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private float timeDisplayPanel = 2f;
    private int numberOfHearts;
    [SerializeField] private TextMeshProUGUI TMPHearts;
    // Start is called before the first frame update
    void Start()
    {
        numberOfHearts = playerLife;
        string strTMPHeart = "";
        //viết và hiển thị hình ảnh số trái tim của player
        // tạo sprite asscess để hiển thị hình ảnh trái tim -> số mạng 
        for(int i = 0; i < playerLife; i++)
		{
            strTMPHeart += " <sprite=2> ";
        }
        TMPHearts.text = strTMPHeart;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerLife == 0)
		{
            Invoke("DisplayLosePanel",timeDisplayPanel);
		}
    }

	private void FixedUpdate()
	{
        string strTMPHeart = "";
        if(playerLife != numberOfHearts)
		{
            for(int i = 0; i < playerLife; i++)
			{
                strTMPHeart += " <sprite=2> ";
            }
            for(int i = 0; i < numberOfHearts - playerLife; i++)
			{
                strTMPHeart += " <sprite=3> ";
            }
            TMPHearts.text = strTMPHeart;
		}
		else
		{
            for (int i = 0; i < playerLife; i++)
            {
                strTMPHeart += " <sprite=2> ";
            }
            TMPHearts.text = strTMPHeart;
        }
	}

	public int getPlayerLife()
	{
        return playerLife;
	}

    public void increasePlayerLife()
	{
        playerLife++;
        if (playerLife > numberOfHearts) playerLife = numberOfHearts;
	}

    public void decreasePlayerLife()
	{
        playerLife--;
        if (playerLife < 0) playerLife = 0;
	}
    
    private void DisplayLosePanel()
	{
        losePanel.SetActive(true);
        //pause screen
        Time.timeScale = 0;
    }
}
