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
    // Start is called before the first frame update
    void Start()
    {
        transform.position = SaveController.instance.GetStartPosition();
        isWalking = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        UnityEngine.Vector3 input = new UnityEngine.Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

        rb.MovePosition(transform.position + input * speed * Time.fixedDeltaTime);

        if(input.magnitude > 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }

    public bool GetIsWalking()
    {
        return isWalking;
    }
}
