using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAnimation : MonoBehaviour
{
    [SerializeField] private float speed = 100f;
    [SerializeField] private bool isMoveToRight = false;
    private RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
		if (!isMoveToRight)
		{
            if (rect.anchoredPosition.x == 1920) rect.anchoredPosition = new Vector2(0, rect.anchoredPosition.y);
            rect.anchoredPosition = Vector2.MoveTowards(rect.anchoredPosition, new Vector2(1920, rect.anchoredPosition.y), speed * Time.deltaTime);
		}
		else
		{
            if (rect.anchoredPosition.x == -1920) rect.anchoredPosition = new Vector2(0, rect.anchoredPosition.y);
            rect.anchoredPosition = Vector2.MoveTowards(rect.anchoredPosition, new Vector2(-1920, rect.anchoredPosition.y), speed * Time.deltaTime);
        }
    }
}
