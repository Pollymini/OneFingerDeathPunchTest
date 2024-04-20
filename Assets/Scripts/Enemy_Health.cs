using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public Animator anim;
    public BoxCollider2D bc;
    public bool dead;

    void Start()
    {
        dead = false;
    }

    
    void FixedUpdate()
    {
        if(dead == true)
        {
            Destroy(gameObject, 0.5f);
        }
    }
    public void TakeHit()
    {
        dead = true;
        bc.enabled = false;
        anim.SetBool("hit", true);
        
        
    }
}
        
       


       



