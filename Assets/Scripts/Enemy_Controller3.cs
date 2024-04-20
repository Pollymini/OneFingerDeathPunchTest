using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_Controller3 : MonoBehaviour
{
    public Animator anim;

    public Transform playerTransform;

    public GameObject player;

    public Player_Controller pc;

    public Rigidbody2D rb;

    public Enemy_Health eH;



    public float speed ;
    private float minDistance = 1f;
    private float range;


    private void Start()
    {
        pc = GetComponent<Player_Controller>();

        anim = GetComponent<Animator>();

        player = GameObject.Find("Player");

        playerTransform = player.GetComponent<Transform>();

        rb.gravityScale = 0f;
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
        if (range < minDistance)
        {
            anim.SetBool("Attack", true);
        }
    }





    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player_Controller>().TakeHit();
            Debug.Log("Attack");
        }
    }
}
    
    
    

   
   

   
        



       

        
    



        
