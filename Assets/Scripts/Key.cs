using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private bool isFollowing;

    public float followspeed;
    public Transform followtarget;

    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        if(isFollowing)
        {
            transform.position = Vector3.Lerp(transform.position, followtarget.position, followspeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag =="Player")
        {
            if(!isFollowing)
            {
                Jump theplayer = FindObjectOfType<Jump>();
                followtarget = theplayer.keyFollowpoint;
                isFollowing = true;

                theplayer.followingkey = this;
                    
            }
        }
    }
}
