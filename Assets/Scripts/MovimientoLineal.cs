using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoLineal : MonoBehaviour
{
    public List<Transform> puntos;
    int puntoactual;
    public float speed;
    public bool activado;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = puntos[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, puntos[puntoactual].position)<0.1f)
        {
            puntoactual++;
            if(puntoactual >= puntos.Count)
            {
                puntoactual = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, puntos[puntoactual].position, speed * Time.deltaTime);
    }
}
