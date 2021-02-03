using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{

    [SerializeField] private float maxLeft = 4.43f;
    [SerializeField] private float maxRight = 8.26f;
    [SerializeField] private float jumpLenght = 10f;
    [SerializeField] private float jumpHeight = 10f;
    [SerializeField] private LayerMask ground;

    //public bool isFrogMove;
    private bool isFacingLeft;

    private Collider2D frogCollider;
    private Rigidbody2D rBFrog;
    public Animator animatorFrog;

   
    private void Start()
    {
        frogCollider = GetComponent<Collider2D>();
        rBFrog = GetComponent<Rigidbody2D>();
        animatorFrog.SetBool("IfStarCollected", false);
    }
    
    //called from frog idle animation event
    private void Move()
    {    
            if (isFacingLeft)
            {
                if (transform.position.x > maxLeft)
                {
                    if (transform.localScale.x != 2.337425f)
                    {
                        transform.localScale = new Vector3(2.337425f, 2.337425f, 2.337425f);
                    }

                    if (frogCollider.IsTouchingLayers(ground))
                    {
                        rBFrog.velocity = new Vector2(-jumpLenght, jumpHeight);
                        animatorFrog.SetBool("JumpUp", true);
                    }
                }

                else
                {
                    isFacingLeft = false;
                }
            }

            else
            {
                if (transform.position.x < maxRight)
                {
                    if (transform.localScale.x != -2.337425f)
                    {
                        transform.localScale = new Vector3(-2.337425f, 2.337425f, 2.337425f);
                    }

                    if (frogCollider.IsTouchingLayers(ground))
                    {
                        rBFrog.velocity = new Vector2(jumpLenght, jumpHeight);
                        animatorFrog.SetBool("JumpUp", true);
                    }
                }

                else
                {
                    isFacingLeft = true;
                }
            }
       
    }

    private void Update()
    {
        if (animatorFrog.GetBool("JumpUp"))
        {
            if (rBFrog.velocity.y < 0.1f)
            {
                animatorFrog.SetBool("JumpDown", true);
                animatorFrog.SetBool("JumpUp", false);
            }
        }
        if (frogCollider.IsTouchingLayers(ground) && animatorFrog.GetBool("JumpDown"))
        {
            animatorFrog.SetBool("JumpDown", false);
        }
    }

    // called by Frog Dead Animation
    private void Destroy()
    {
        Destroy(gameObject);
    }
}

  