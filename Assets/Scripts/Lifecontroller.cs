using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifecontroller : MonoBehaviour
{
    public int lifes_current;
    public int lifes_max;
    public float invencibletime;
    bool invencible;

    public enum DeathMode { Teleport, ReloadScene, Destroy }
    public DeathMode death_mode;
    public Transform respawn;

    Rigidbody2D rb;
        
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lifes_current = lifes_max;
        
    }

    // Update is called once per frame
    public void Damage(int damage = 1, bool ignoreinvencibletime = false)
    {
        if (!invencible || ignoreinvencibletime) 
        {
            lifes_current -= damage;
            StartCoroutine(invencible_Corutine());
            if(lifes_current <= 0)
            {
                death();
            }

        }
    }
    public void death()
    {
        Debug.Log("Estoy muerto");
        switch (death_mode)
        {
            case DeathMode.Teleport:
                rb.velocity = new Vector2(0, 0);
                transform.position = respawn.position;
                lifes_current = lifes_max;

                break;
            case DeathMode.ReloadScene:

                break;
            case DeathMode.Destroy:
                Destroy(gameObject);
                break;
            default:
                break;
        }

    }

    IEnumerator invencible_Corutine()
    {
        invencible = true;
        yield return new WaitForSeconds(invencibletime);
        invencible = false;

    }
}
