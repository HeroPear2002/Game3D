using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectPanelButtonScrip : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
    [SerializeField] private int value;
    [SerializeField] private GameObject Panel;
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private AudioSource pressSound;
    [SerializeField] private bool isSelectPanelScrip, isSelectPanelContinueScript;
    private Color32 oldColor;
    private SelectPanelScript selectPanelScript;
    private SelectPanelContinueScript selectPanelContinueScript;
    // Start is called before the first frame update
    void Start()
    {
        oldColor = textMesh.color;
		if (isSelectPanelScrip)
		{
            selectPanelScript = Panel.GetComponent<SelectPanelScript>();
        }
		if (isSelectPanelContinueScript)
		{
            selectPanelContinueScript = Panel.GetComponent<SelectPanelContinueScript>();
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void OnPointerEnter(PointerEventData eventData)
	{
        if (StaticData.isSound) pressSound.Play();
        textMesh.color = new Color32(255, 131, 0, 255);
		if (isSelectPanelScrip)
		{
            selectPanelScript.setCurrentButton(value);
            selectPanelScript.isHover = true;
        }
		if (isSelectPanelContinueScript)
		{
            selectPanelContinueScript.setCurrentButton(value);
            selectPanelContinueScript.isHover = true;
		}
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        textMesh.color = oldColor;
    }

	public void OnPointerClick(PointerEventData eventData)
	{
		if (isSelectPanelScrip && value == 2)
		{
            selectPanelScript.displaySettingPanel();
		}
        if (isSelectPanelScrip && value == 3)
        {
            Application.Quit();
        }
        if (isSelectPanelContinueScript && value == 3)
		{
            selectPanelContinueScript.displaySettingPanel();
		}
        //if (isSelectPanelContinueScript && value == 2)
        //{
        //    SaveData saveData = new SaveData(1, 0);
        //    IDataService dataService = new JsonDataService();
        //    dataService.SaveData("/data.json", saveData);
        //}
        if (isSelectPanelContinueScript && value == 4)
        {
            Application.Quit();
        }
    }
}
