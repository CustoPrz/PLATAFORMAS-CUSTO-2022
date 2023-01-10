using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private Jump theplayer;
    public SpriteRenderer thesr;
    public Sprite dooropened;

    public bool doorOpen, waitingtoopen;
    public string scenename;
    
    // Start is called before the first frame update
    void Start()
    {
        theplayer = FindObjectOfType<Jump>();
    }

    // Update is called once per frame
    void Update()
    {
        if(waitingtoopen)
        {
            if(Vector3.Distance(theplayer.followingkey.transform.position,transform.position)<0.1f)
            {
                waitingtoopen = false;
                doorOpen = true;

                thesr.sprite = dooropened;

                theplayer.followingkey.gameObject.SetActive(false);
                theplayer.followingkey = null;

            }
        }
        if(doorOpen && Vector3.Distance(theplayer.transform.position,transform.position) < 1f && Input.GetAxis("Vertical") > 0.1f)
        {
            SceneManager.LoadScene(scenename);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag =="Player")
        {
            if (theplayer.followingkey != null)
            {
                theplayer.followingkey.followtarget = transform;
                waitingtoopen = true;
            }
        }
    }
}
