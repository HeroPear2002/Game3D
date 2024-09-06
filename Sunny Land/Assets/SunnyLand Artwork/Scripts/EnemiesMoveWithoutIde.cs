using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMoveWithoutIde : MonoBehaviour
{
	//[SerializeField] private GameObject startPoint, endPoint;
	[SerializeField] private GameObject[] waypoint;
	private int currentWaypointIndex = 0;
	[SerializeField] private float speed = 2f;
	[SerializeField] private bool isFlip = true;
    GameObject currentPoint;
    private SpriteRenderer sprite;
	private Animator anim;
	// Start is called before the first frame update
	void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
		//currentPoint = startPoint;
	}

    // Update is called once per frame
    void Update()
    {
		//if (Vector2.Distance(startPoint.transform.position, transform.position) < .1f)
		//{
		//	sprite.flipX = true;
		//	currentPoint = endPoint;
		//}
		//if (Vector2.Distance(endPoint.transform.position, transform.position) < .1f)
		//{
		//	sprite.flipX = false;
		//	currentPoint = startPoint;
		//}
		//transform.position = Vector2.MoveTowards(transform.position, currentPoint.transform.position, Time.deltaTime * speed);

		// Tọa độ của waypoint							// Tọa độ của object chứa script
		// 2 object startPoint & endPoint
		// waypoint[0] = startPoint			waypoint[1] = endPoint
		// Distance (startPoint : tọa độ của startPoint, tọa độ của object chứa sciprt này -> 1 con enemy nào đó)
		// tính khoảng cách giữa startPoint và  tọa độ của object chứa sciprt này nếu  < 0.1f -> object đã đi chuyển tới điểm startPoint
		if (Vector2.Distance(waypoint[currentWaypointIndex].transform.position, transform.position) < .1f)
		// Ví dụ currentWaypointIndex = 0 -> startPoint
		// 
		{
			// isFlip là một biến bool xác định object có flip hay không
			if (isFlip)	{sprite.flipX = true;}
			currentWaypointIndex++;
			if (currentWaypointIndex >= waypoint.Length)
			{
				currentWaypointIndex = 0;
				if (isFlip) { sprite.flipX = false; }
			}
		}
		// kiểm tra xem object có ở trạng thái destroy không 
		// có đang ở animation destroy hay không
		if(anim.GetInteger("state") != 3)
		{
			// di chuyển từ điểm này đến điểm kia
			// di chuyển từ tọa độ hiện tại của object chứa script này (enemy) đến startPoint || endPoint tùy thuộc vào currentWaypointIndex
			transform.position = Vector2.MoveTowards(transform.position, waypoint[currentWaypointIndex].transform.position, Time.deltaTime * speed);
		}
	}
}
