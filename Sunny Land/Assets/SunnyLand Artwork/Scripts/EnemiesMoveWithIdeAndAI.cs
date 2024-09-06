using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMoveWithIdeAndAI : MonoBehaviour
{
    [SerializeField] private GameObject player, startPoint, endPointLeft,endPointRight;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float distanceAttack = 4f;
    [SerializeField] private float ideTime = 2f;
    [SerializeField] private bool isFlip = true,isFollow = false;
    private float currentIdeTime = 0;
    private bool facingRight = false;
    private float distance = 0, distanceToStartPoint;
    private SpriteRenderer sprite;
    private Animator anim;
    private enum MovementState { ide, running, destroy }
    private MovementState state = MovementState.ide;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // tính khoảng cách giữa object có script ... với player
        distance = Vector2.Distance(transform.position, player.transform.position);
        // so sánh khoảng cách trên với khoảng cách tấn công
        if(distance < distanceAttack)
        {
            // flip sprite enemy 
            // nếu tọa độ X của player > tọa độ x của object có script(enemy nào đó)
            if (player.transform.position.x > transform.position.x)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
            // tất các các enemy đều có animation destroy
            // kiểm tra xem enemy có ở trạng thái destroy hay không
            if (anim.GetInteger("state") != 3)
			{
                anim.SetInteger("state", (int)MovementState.running);
                // enemy follow player theo tọa dộ player
				if (isFollow)
				{
                    // transform.position -> tọa độ của object chứa script
                    // player.transform.position -> tọa độ của player
                    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                }

				else
				{
                    // endPointLeft.transform.position, endPointRight.transform.position giới hạn mà enemy có thể follow player
                    // Tại sao lại có endPointLeft & endPointRight?
                    // Vì enemy sẽ follow player theo tọa độ x(nghĩa là chỉ di chuyển theo chiều ngang) nên cần giới hạn 
                    // (Ví dụ : chiều dài của ground gắn nên cần giói hạn điểm di chuyển mà enemy có thể follow player
                    // nếu không enemy sẽ bị đi ra khỏi ground)
                    if (transform.position.x >= endPointLeft.transform.position.x && transform.position.x <= endPointRight.transform.position.x)
					{
                        transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, transform.position.y), speed * Time.deltaTime);
                    }
                }
            }
		}
		else
		{
            // đây là trường hợp tổng quát code tái sử dụng được có enemy có startPoint có enemy không có
            // startPoint -> tọa độ điểm xuất phát của enemy -> enemy sẽ quay trở lại startPoint nếu distance < distanceAttack
            // dùng cho enemy khi khoảng cách giữa player và enemy > distanceAttack thì enemy đó sẽ quay trở về vị trí 
            // ban đầu (startPoint)
            if (startPoint != null)
			{
                // tính khoảng cách giữa enemy vs startPoint
                distanceToStartPoint = Vector2.Distance(transform.position, startPoint.transform.position);
                // enemy chưa về điểm xuất phát (distance > distanceAttack)
                if (distanceToStartPoint != 0)
				{
                    // flip sprite
                    // nếu tọa độ X của enemy > tọa độ X của startPoint -> flip 
                    if (startPoint.transform.position.x > transform.position.x)
                    {
                        sprite.flipX = true;
                    }
                    else
                    {
                        sprite.flipX = false;
                    }
                    // di chuyển trở lại điểm startPoint
                    transform.position = Vector2.MoveTowards(transform.position, startPoint.transform.position, speed * Time.deltaTime);
				}
                // tọa dộ của enemy == tọa độ của startPoint -> set animation ide cho enemy
				else
				{
                    anim.SetInteger("state", (int)MovementState.ide);
                }
             
            }
            // startPoint == null && distance > distanceAttack -> set animation ide cho enemy không có startPoint
            else
            {
                anim.SetInteger("state", (int)MovementState.ide);
            }
		}
    }

	private void FixedUpdate()
	{
        // sau mỗi ideTime -> flip
        currentIdeTime += Time.deltaTime;
        if (currentIdeTime >= ideTime)
        {
            currentIdeTime = 0;
			if (isFlip) { flip(); }
        }
    }

    private void flip()
	{
        facingRight = !facingRight;
        sprite.flipX = facingRight;
	}

}
