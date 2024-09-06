using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderDetector : MonoBehaviour
{
    [SerializeField] private PlayerController player;

	//private void OnCollisionEnter2D(Collision2D collision)
	//{
	//	if (collision.gameObject.CompareTag("Ladder"))
	//	{
	//           player.ClimbingAllowed = true;
	//	}
	//}

	//private void OnCollisionExit2D(Collision2D collision)
	//{
	//	if (collision.gameObject.CompareTag("Ladder"))
	//	{
	//           player.ClimbingAllowed = false;
	//	}
	//}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Ladder"))
		{
			player.ClimbingAllowed = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Ladder"))
		{
			player.ClimbingAllowed = false;
		}
	}
}
