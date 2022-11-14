using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;
    public Rigidbody2D rb;
    bool isWalking = false;

    public Animator anim;
    public UnityEngine.Vector2 movementInputs;

    void Start()
    {
        transform.position = SaveController.instance.GetStartPosition();
        anim = GetComponent<Animator>();
        isWalking = false;
        rb = GetComponent<Rigidbody2D>();
        movementInputs = new UnityEngine.Vector2(0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        UnityEngine.Vector3 input = new UnityEngine.Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

        rb.MovePosition(transform.position + input * speed * Time.fixedDeltaTime);

        movementInputs = input;

        if(input.magnitude > 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }

    private void LateUpdate()
    {
        PlayerAnimations();
    }

    public bool GetIsWalking()
    {
        return isWalking;
    }


    private void PlayerAnimations()
    {
        ResetAnimBools();

        if (movementInputs.x != 0)
        {
            if (movementInputs.x > 0)
            {
                anim.SetBool("WalkRight", true);
            }
            else
            {
                anim.SetBool("WalkLeft", true);
            }
        }
        else
        {
            if (movementInputs.y != 0)
            {
                if (movementInputs.y > 0)
                {
                    anim.SetBool("WalkBack", true);
                }
                else
                {
                    anim.SetBool("WalkFront", true);
                }
            }
        }
    }

    private void ResetAnimBools()
    {
        anim.SetBool("WalkFront", false);
        anim.SetBool("WalkBack", false);
        anim.SetBool("WalkRight", false);
        anim.SetBool("WalkLeft", false);
    }
}
