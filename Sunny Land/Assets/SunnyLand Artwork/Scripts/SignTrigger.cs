using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SignTrigger : MonoBehaviour
{
    [SerializeField] private GameObject levelCompelePanel;
	[SerializeField] private int value;
	[SerializeField] private AudioSource audioSource;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			//audioSource.Play();
			//levelCompelePanel.SetActive(true);
			//Time.timeScale = 0;
			//if (value + 1 == 6) value -= 1;
			//SaveData saveData = new SaveData(value + 1, StaticData.numberOfItem);
			//IDataService dataService = new JsonDataService();
			//dataService.SaveData("/data.json", saveData);
		}
    }
}
