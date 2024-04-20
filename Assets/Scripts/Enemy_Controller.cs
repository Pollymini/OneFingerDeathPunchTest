using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Enemy_Controller : MonoBehaviour
{
    public Animator anim;

    public Transform playerTransform;

    public GameObject player;

    public Player_Controller pc;

    public Rigidbody2D rb;

    public Enemy_Health eH;
    

    public float speed = 2f;
    private float minDistance = 1.2f;
    private float range;


    private void Start()
    {
        anim = GetComponent<Animator>();
        pc = GetComponent<Player_Controller>();
        player = GameObject.Find("Player");
        playerTransform = player.GetComponent<Transform>();
    }

       



       
    void Update()
    {
        Move();
        Flip();
        Attack();
        
    }

    void Move()
    {
        range = Vector2.Distance(transform.position, playerTransform.position);

        if (range > minDistance && eH.dead == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        }
        
    }
    

    void Flip()
    {
        if (playerTransform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-4, 4, 4);
        }
    }

        
        
         
          
    void Attack()
    {
        if (range < minDistance && eH.dead == false)
        {
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
        }
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player_Controller>().TakeHit();
            
        }
    }
}

        



    
    
    

   
   

   
        



       

        
    



        
