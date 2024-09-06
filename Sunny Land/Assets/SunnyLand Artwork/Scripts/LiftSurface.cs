using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftSurface : MonoBehaviour
{
	//[SerializeField] private GameObject Lift;

	// 
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Player")
		{
			// Gán cha cho player
			// mục đích khi object cha của player thay đổi tọa độ thì player cũng thay đổi theo
			// giải thích : gán cha của player là liftSurface -> khi liftSurface thay đổi tọa độ thì player cũng di chuyển theo
			collision.gameObject.transform.SetParent(transform);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Player")
		{
			collision.gameObject.transform.SetParent(null);
		}
	}
}
