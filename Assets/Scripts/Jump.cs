using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Jump : MonoBehaviour
{
    Rigidbody2D rb;
    public float force = 20;
    GroundDetector_RayCast ground;
    public int jumps_max = 2;
    public float JumpForce = 10;
    int jumps;
    public Transform keyFollowpoint;

    public Key followingkey;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ground = GetComponent<GroundDetector_RayCast>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ground.grounded)
        {
            jumps = jumps_max;
        }
        if (Input.GetButtonDown("Jump") && jumps > 0)
        {
            
            jumps--;
            if(ground.grounded)
            {
                rb.AddForce(new Vector2(0, force));
            }
            else
            {
                rb.AddForce(new Vector2(0, JumpForce));
            }
        }
    }
}

