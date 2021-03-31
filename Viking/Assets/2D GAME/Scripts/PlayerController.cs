using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRB;

    Animator playerAnimator;
    
    public float moveSpeed = 1f;

    public float jumpSpeed = 1f;
    public float jumpFrequency=1f, nextjumpTime;

    bool facingRight = true;

    public  bool IsGrounded = false;

    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;

    void Start()
    {
        playerRB = this.GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

   
    void Update()
    {
        HorizontalMove();
        OnGroundCheck();

        if (playerRB.velocity.x < 0 && facingRight)
        {
            FlipFace();
        }
    
        else if (playerRB.velocity.x > 0 && !facingRight)
        {
            FlipFace();
        }
    
       if (Input.GetAxis("Vertical") > 0 && IsGrounded && (nextjumpTime < Time.timeSinceLevelLoad))
        {
            nextjumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            Jump();
        }
    
    
    }

    private void FixedUpdate()
    {
        
    }

    void HorizontalMove()
    {
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed , playerRB.velocity.y);
        playerAnimator.SetFloat("playerSpeed", Mathf.Abs(playerRB.velocity.x));
    }

    void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }

    void Jump()
    {
        playerRB.AddForce(new Vector2(0f, jumpSpeed));
    }

    void OnGroundCheck()
    {
        IsGrounded = Physics2D.OverlapCircle(groundCheckPosition.position,groundCheckRadius,groundCheckLayer);
        playerAnimator.SetBool("isGroundedAnim", IsGrounded);
    }




}
