using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public Animator anim;
    public GameObject player;
  
    public Collider2D col;

    public GameObject enemy;
    
    private Enemy_Health ec;

    public Ui_InGame ui;
    
    public GameOver go;

    public Enemy_Spawn eS;
    
    
    
    public float dirr;
    public bool flipX;

    public bool dead;
    

    void Start()
    {
        col = GetComponent<Collider2D>();
       
        anim = GetComponent<Animator>();

        dead = false;
        
    }


        


    void Update()
    {
        Attack();


        enemy = GameObject.FindWithTag("Enemy");
        if(enemy != null)
        {
            ec = enemy.GetComponent<Enemy_Health>();
        }
            
        
        
    }


        

       
    public void Attack()
    {
       

        if (Input.GetMouseButtonDown(0))
        {
            gameObject.transform.parent.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("attack", true);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            gameObject.transform.parent.localScale = new Vector3(1,1,1);   
            anim.SetBool("attack", true);
        }
        else
        {
            anim.SetBool("attack", false);
        }

        
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (ec != null)
        {
            if (col.gameObject.tag == "Enemy")
            {
                col.gameObject.GetComponent<Enemy_Health>().TakeHit();
                
                ui.highScore += 1;

                eS.spawned.RemoveAt(0);
            }
        }

    }


    public void TakeHit()
    {
        anim.SetBool("hit", true);
        go.Pause();
    }

   
    
}










