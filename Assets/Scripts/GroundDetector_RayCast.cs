using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GroundDetector_RayCast : MonoBehaviour
{
    public bool grounded;
    public float  length = 1;
    public LayerMask mask;

    public List<Vector3> OriginPoints; 

     void Update()
    {
        grounded = false;
        for (int i = 0; i < OriginPoints.Count; i++)
        {
            Debug.DrawRay(transform.position + OriginPoints[i], Vector3.down * length, Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position + OriginPoints[i], Vector3.down, length, mask); ;
            if (hit.collider != null)
            {
                if(hit.collider.tag =="Plataformamovil")
                {
                    transform.parent = hit.transform;
                }
                Debug.DrawRay(transform.position + OriginPoints[i], Vector3.down * hit.distance, Color.green);
                grounded = true;
            }
            if (!grounded)
            {
                transform.parent = null;
            }
            
        }
        

        //RaycastHit2D hit = Physics2D.Raycast(OriginPoints, Vector3.down, length, mask);
        //if (hit.collider != null)
        //{ 
        //    Debug.DrawRay(OriginPoints, Vector3.down, Color.green);
        //    grounded = true;
        //}
        //else
        //{
        //    grounded = false;
        //}

    }
}
