using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 2;
    [SerializeField] private float dashSpeed = 5;
    public float jumpSpeed = 3;

    Rigidbody2D rb2D;
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    public bool betterJump = true;
    public float fallMultiplier = 0.5f;
    private bool canJumpAgain = true;

    private MeleeCombat meleeCombat;
    public float attackDuration = 0.3f;
    private float attackTimer = 0.0f;
    private bool isAttacking = false;

    

    

    // Start is called before the first frame update
    void Start()
    {
        this.rb2D = GetComponent<Rigidbody2D>();
        //this.normalAtack = GetComponentInChildren<EdgeCollider2D>;
        meleeCombat = GetComponent<MeleeCombat>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Walking
        if (Input.GetKey("d") || Input.GetKey("right")) 
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = false;
            if (!isAttacking)
            {
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }

        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = true;
            if (!isAttacking)
            {
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("isRunning", false);
        }

        //Jumping
        if(CheckGround.isGrounded && (Input.GetKeyDown("space") || Input.GetKey("space")) && canJumpAgain) {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
            if (canJumpAgain)
            {
                canJumpAgain = false;
            }
        }
        if((Input.GetKeyUp("space") || !Input.GetKey("space")) && rb2D.velocity.y > 0f) {
            rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * fallMultiplier);
            
        }
        if ((Input.GetKeyUp("space") || !Input.GetKey("space")) && !canJumpAgain)
        {
            canJumpAgain = true;
        }
        
        if(!CheckGround.isGrounded && !isAttacking)
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isRunning", false) ;
        }
        else
        {
            animator.SetBool("isJumping", false);
        }

        //Atack

        if (!isAttacking && Input.GetKey("x"))
        {
            meleeCombat.NormalHit();

            animator.SetBool("isAtackingNml", true);
            animator.SetBool("isJumping", false);
            animator.SetBool("isRunning", false);
            isAttacking = true;
        }
        if (isAttacking)
        {
            attackTimer += Time.deltaTime;
            //Debug.Log(attackTimer);

            // Si el tiempo de ataque ha terminado
            if (attackTimer >= attackDuration)
            {
                meleeCombat.EndNormalHit();
                //Debug.Log("Acabe de atacar");
                attackTimer = 0;
                isAttacking = false;
                animator.SetBool("isAtackingNml", false);
            }
        }

        //Dash
        if (Input.GetKeyDown("left shift"))
        {
            if (spriteRenderer.flipX)
            {
                rb2D.velocity = new Vector2(-dashSpeed, 0);
            }
            else
            {
                rb2D.velocity = new Vector2(dashSpeed, 0);
            }
        }

    }
}
