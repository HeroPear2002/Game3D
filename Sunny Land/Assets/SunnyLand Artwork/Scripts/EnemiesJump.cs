using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesJump : MonoBehaviour
{
    // Start is called before the first frame update
    private enum MovementState { ide,jumping, falling, destroy}
    MovementState state = MovementState.ide;
    private bool facingRight = false, isJumping = false, isFalling = false, isIde = true, isGrounded = false;
    [SerializeField] private float jumpForceX = 2f;
    [SerializeField] private float jumpForceY = 4f;
    [SerializeField] private float lastYPos = 0;
    [SerializeField] private float ideTime = 2f;
    [SerializeField] private float currentIdeTime = 0;
    [SerializeField] private LayerMask jumpAbleGround;
    [SerializeField] private GameObject startPoint, endPoint;
    private Animation currentAnim;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    void Start()
    {
        // thay đổi tọa độ
        rb = GetComponent<Rigidbody2D>();
        // thay đổi sate animation
        anim = GetComponent<Animator>();
        // flip sprite 
        sprite = GetComponent<SpriteRenderer>();
        // dùng cho isground để kiểm tra object có đang ở ground hay không
        coll = GetComponent<BoxCollider2D>();
        // Lấy tọa độ y hiện tại của object (mục đích : để kiểm tra xem nó có đang ở trạng thái jump hay không)
        lastYPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

    }

	private void FixedUpdate()
	{
		if (isIde)
		{
            currentIdeTime += Time.deltaTime;
            if(currentIdeTime >= ideTime)
			{
                currentIdeTime = 0;
                // sau mỗi ideTime (2s) thì enemy sẽ nhảy 1 lần
                jump();
			}
		}
		if (IsGrounded() && isFalling)
		{
            isFalling = false;
            isJumping = false;
            isIde = true;
            anim.SetInteger("state", (int)MovementState.ide);
		}else if(transform.position.y > lastYPos && !isGrounded && !isIde)
		{
            isJumping = true;
            isFalling = false;
            anim.SetInteger("state", (int)MovementState.jumping);
        }
        else if(transform.position.y < lastYPos && !isGrounded && !isIde)
		{
            isJumping = false;
            isFalling = true;
            anim.SetInteger("state", (int)MovementState.falling);
        }
        // lần đầu tiên nhảy
        // Ví dụ enemy(frog) đang nhảy lên -> tọa độ y hiện tại > toạn độ y (ban đầu)

        lastYPos = transform.position.y;
	}

    private void jump()
	{
        // các biến bool dùng để kiểm soát trạng thái của enemy (ide, jump,fall)
        isJumping = true;
        isIde = false;
        int direction = 0;
        if(transform.position.x >= endPoint.transform.position.x)
		{

            facingRight = false;
            sprite.flipX = facingRight;
            //Debug.Log("end");
		}
		else if(transform.position.x <= startPoint.transform.position.x)
		{

            facingRight = true;
            sprite.flipX = facingRight;
            //Debug.Log("start");
        }
        // nếu enemy di chuyển sang bên phải -> tọa độ x phải tăng
		if (facingRight == true)
		{
            direction = 1;
		}
		else
		{
            direction = -1;
		}
        // có Rigidbody2D dynamic -> velocity để thay đổi tọa độ 
        // khi di chuyển sang bên phải có nghĩa là tọa dộ X sẽ tăng lên -> nếu facingRight == true -> enemy di chuyển 
        // sang bên phải -> tọa độ x tăng dần
        rb.velocity = new Vector2(jumpForceX * direction, jumpForceY);
	}

    private bool IsGrounded()
    {
        // phương thức kiểm tra xem object có đang ở ground hay không 
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpAbleGround);

        // hoàn toàn có thể kiểm tra isGround bằng cách gán thêm tag cho object mình muốn đặt làm ground sau đó 
        // tạo 1 biến kiểu bool trả về true || false khi player onCollisionEnter2D & onCollisionExit2D
    }

}
