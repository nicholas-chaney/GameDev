using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;
    bool canMove = true;

    public GameObject HitboxUp;
    public GameObject HitboxDown;
    public GameObject HitboxRight;
    public GameObject HitboxLeft;

    Collider2D hitboxColliderUP;
    Collider2D hitboxColliderDOWN;
    Collider2D hitboxColliderLEFT;
    Collider2D hitboxColliderRIGHT;

    [SerializeField] private int speed = 15;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        hitboxColliderUP = HitboxUp.GetComponent<Collider2D>();
        hitboxColliderDOWN = HitboxDown.GetComponent<Collider2D>();
        hitboxColliderLEFT = HitboxLeft.GetComponent<Collider2D>();
        hitboxColliderRIGHT = HitboxRight.GetComponent<Collider2D>();

    }
    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);

            animator.SetBool("IsWalking", true);

        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }
    public void Fishing(bool isfishing)
    {
        animator.SetBool("IsFishing", isfishing);
    }
    private void FixedUpdate()
    {

        //rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);


        //if (movement.x != 0 || movement.y != 0)
        //{
        //    rb.velocity = movement * speed;
        //}
        if (canMove == true)
        {
            rb.AddForce(movement * speed);
        }
    }

    void OnFire()
    {
        animator.SetTrigger("Attack");
    }
    void LockMovement()
    {
        canMove = false;
    }

    void UnlockMovement()
    {
        canMove = true;
    }
}
