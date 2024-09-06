using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private float timeDisappear = 1f;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private TextMeshProUGUI TMPGems;
    private PlayerLife playerLife;
    private string strTMPGems = "";
    private int numberOfGems = 0;
    private enum itemState { ide, destroy }
    private itemState state = itemState.ide;
    void Start()
    {
        playerLife = GetComponent<PlayerLife>();
    }
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Cherry") && collision.GetComponent<Animator>().GetInteger("state") != (int)itemState.destroy)
		{
            if (StaticData.isSound) audioSource.Play();
            playerLife.increasePlayerLife();
            collision.GetComponent<Animator>().SetInteger("state", (int)itemState.destroy);
            Destroy(collision.gameObject, timeDisappear);
		}
		if (collision.CompareTag("Gem") && collision.GetComponent<Animator>().GetInteger("state") != (int)itemState.destroy)
		{
            if (StaticData.isSound) audioSource.Play();
            numberOfGems++;
            strTMPGems = "  <sprite=0>x" + numberOfGems;
            TMPGems.text = strTMPGems;
            collision.GetComponent<Animator>().SetInteger("state", (int)itemState.destroy);
            Destroy(collision.gameObject, timeDisappear);
        }
	}
}
