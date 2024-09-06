using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrigger : MonoBehaviour
{
    [SerializeField] private GameObject player, startPoint, endPoint;
    [SerializeField] private float speed = 6f;
    [SerializeField] private float distanceAppear = 3f;
    private float distance = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance <= distanceAppear)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, endPoint.transform.position.y), speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, startPoint.transform.position.y), speed * Time.deltaTime);
        }
    }
}
