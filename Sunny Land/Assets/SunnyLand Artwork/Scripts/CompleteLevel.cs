using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string selectLevel;
    public void OnPointerClick(PointerEventData eventData)
	{
        SceneManager.LoadScene(selectLevel);
    }
}
