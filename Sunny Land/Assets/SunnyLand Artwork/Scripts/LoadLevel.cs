using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class LoadLevel : MonoBehaviour
{
	[SerializeField] private string SceneName;
	[SerializeField] private TextMeshProUGUI textMesh;
	public void Load()
	{
		if(!textMesh.text.Equals("?") && !textMesh.text.Equals("..."))
		{
			SceneManager.LoadScene(SceneName);
		}
	}
}
