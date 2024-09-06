using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private PlayerLife playerLife;
    private bool facingRight = true, canMove = true, isCrouch = false, isHurt = false, isFading = false, isInSpike = false, isNotExitSpike = false;
    public bool ClimbingAllowed { get; set; }
    [SerializeField] private LayerMask jumpAbleGround;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float hurtForceX = 4f;
    [SerializeField] private float hurtForceY = 10f;
    [SerializeField] private float timeHurt = .5f;
    [SerializeField] private float timeFade = 2f;
    [SerializeField] private float timeFadeInOut = .05f;
    [SerializeField] private AudioSource audioJump,audioHurt,audioDestroyEnemy;
    private float dirX, dirY;
    private enum MovementState { ide, running, jumping, falling, crouch, climb, hurt, climbStop }
    private MovementState state = MovementState.ide;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        playerLife = GetComponent<PlayerLife>();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerLife.getPlayerLife() == 0)
		{
            canMove = false;
            anim.SetInteger("state", (int)MovementState.hurt);
            coll.isTrigger = true;
		}
        dirX = Input.GetAxisRaw("Horizontal");
        if (canMove && anim.GetInteger("state") != (int)MovementState.hurt)
        {
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        }
        
        dirY = Input.GetAxisRaw("Vertical");
        if(dirY > 0f)
        {
            if (IsGrounded() && !ClimbingAllowed && !isHurt)
            {
                if(StaticData.isSound) audioJump.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
        updateAnimationState();

        if (!isFading && isInSpike)
        {
            if (StaticData.isSound) audioHurt.Play();
            isHurt = true;
            canMove = false;
            rb.velocity = new Vector2(rb.velocity.x, hurtForceY);
        }
    }
    private void FixedUpdate()
    {
        if (ClimbingAllowed && !isCrouch && !isHurt)
        {
            rb.isKinematic = true;
            rb.velocity = new Vector2(rb.velocity.x, dirY * moveSpeed);
        }
        else
        {
            rb.isKinematic = false;
            //rb.velocity = new Vector2(dirX, rb.velocity.y * moveSpeed);
        }
    }
    private void updateAnimationState()
    {
        MovementState state = MovementState.ide;
        if(dirX > 0f )
        {
            if (canMove )
            {
                state = MovementState.running;
            }
            if (!facingRight)
            {
                Flip();
            }
        }else if(dirX < 0f )
        {
            if (canMove )
            {
                state = MovementState.running;
            }
            if (facingRight)
            {
                Flip();
            }
        }
		else
		{
			canMove = true;
			state = MovementState.ide;
		}
		if (rb.velocity.y > .1f  )
        {
            canMove = true;
            state = MovementState.jumping;
        }
        else if(rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        if(dirY < 0f && IsGrounded() && anim.GetInteger("state") != (int)MovementState.hurt)
        {
            canMove = false;
            state = MovementState.crouch;
            isCrouch = true;
        }
        else
        {
            isCrouch = false;
        }
        
        if(ClimbingAllowed && (dirY > 0f || dirY < 0f && !IsGrounded()))
        {
            state = MovementState.climb;
            canMove = false;
        }
        if(ClimbingAllowed && dirY == 0f && !IsGrounded() && !isHurt)
        {
            state = MovementState.climbStop;
            canMove = false;
        }
        if (ClimbingAllowed && IsGrounded() && dirY ==0f)
        {
            state = MovementState.ide;
        }
		if (isHurt)
		{
            state = MovementState.hurt;
            Invoke("setIsHurtFalse", timeHurt);
		}
        anim.SetInteger("state", (int)state);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpAbleGround);
    }


    private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Enemies_Frog"))
		{
			if (anim.GetInteger("state") == (int)MovementState.falling)
			{
                if (StaticData.isSound) audioDestroyEnemy.Play();
				rb.isKinematic = false;
				rb.velocity = new Vector2(rb.velocity.x, jumpForce);
				collision.gameObject.GetComponent<Animator>().SetInteger("state", 3);
				collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
				collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
				Destroy(collision.gameObject, 1f);
			}
			else
			{
				if (!isFading)
				{
                    if (StaticData.isSound) audioHurt.Play();
                    isHurt = true;
                    canMove = false;
                    playerLife.decreasePlayerLife();
                    if (collision.transform.position.x > transform.position.x)
                    {
                        rb.velocity = new Vector2(-hurtForceY, rb.velocity.y);
                    }
                    else
                    {
                        rb.velocity = new Vector2(hurtForceY, rb.velocity.y);
                    }
                }
			}
		}
        if (collision.gameObject.CompareTag("Spike"))
		{
            isInSpike = true;
            if (!isFading)
            {
                if (StaticData.isSound) audioHurt.Play();
                isHurt = true;
                canMove = false;
                if (collision.gameObject.transform.position.x > transform.position.x)
                {
                    rb.velocity = new Vector2(-hurtForceX, hurtForceY);
                }
                else
                {
                    rb.velocity = new Vector2(hurtForceX, hurtForceY);
                }
            }
        }

    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Enemies"))
		{
            if (anim.GetInteger("state") == (int)MovementState.falling && collision.gameObject.GetComponent<Animator>().GetInteger("state") != 3)
            {
                if (StaticData.isSound) audioDestroyEnemy.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                collision.gameObject.GetComponent<Animator>().SetInteger("state", 3);
                Destroy(collision.gameObject, 1f);
            }
            else
            {
                if (collision.gameObject.GetComponent<Animator>().GetInteger("state") != 3 && !isFading)
				{
                    if (StaticData.isSound) audioHurt.Play();
                    playerLife.decreasePlayerLife();
                    isHurt = true;
                    canMove = false;
                    if (collision.transform.position.x > transform.position.x)
                    {
                        rb.velocity = new Vector2(-hurtForceX, hurtForceY);
                    }
                    else
                    {
                        rb.velocity = new Vector2(hurtForceX, hurtForceY);
                    }
                }
            }
        }
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Spike"))
		{
            isInSpike = false;
            if (!isFading) playerLife.decreasePlayerLife();
		}
	}

	private void setIsHurtFalse()
	{
        isHurt = false;
		if (!isFading)
		{
            StartCoroutine(fade());
        }
    }

    IEnumerator fade()
	{
        isFading = true;
        StartCoroutine(fadeOut());
        yield return new WaitForSeconds(timeFade);
        Color c = sprite.material.color;
        c.a = 1f;
        sprite.material.color = c;
        isFading = false;
    }

    IEnumerator fadeOut()
	{
		if (isFading)
		{
            for (float f = 1f; f >= .5f; f -= .05f)
            {
                Color c = sprite.material.color;
                c.a = f;
                sprite.material.color = c;
            }
            yield return new WaitForSeconds(timeFadeInOut);
            StartCoroutine(fadeIn());
        }
    }
    IEnumerator fadeIn()
	{
		if (isFading)
		{
            for (float f = .5f; f <= 1f; f += .05f)
            {
                Color c = sprite.material.color;
                c.a = f;
                sprite.material.color = c;
            }
            yield return new WaitForSeconds(timeFadeInOut);
            StartCoroutine(fadeOut());
        }
    }
}
