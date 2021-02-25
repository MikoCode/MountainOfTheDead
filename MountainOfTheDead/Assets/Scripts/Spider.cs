using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    private Transform playerPos;
    private PowerUps powerUps;
    public  ParticleSystem particle1;
    public  EnemiesHealth eH;
    public  Animator animator;
  
    
    public  float Distance;
    private float stoppingDistance;
    public  float  speed;
    public  float letAlone;
    public  float currentHealth;
    private float startHealth;
    
    public  float startTimeBtwAttack;
    private bool didAttack;
    private bool rotated;
    public  float TimeBtwAttack;
    private PlayerHealthManager pH;
    // Start is called before the first frame update
    void Start()
    {
        Distance = 4;
        powerUps = GameObject.Find("Player").GetComponent<PowerUps>();
        didAttack = false;
        TimeBtwAttack = startTimeBtwAttack;
        playerPos = GameObject.Find("Player").GetComponent<Transform>();
        pH = GameObject.Find("Player").GetComponent<PlayerHealthManager>();
        speed = 5;
        stoppingDistance = 2;
        
        startHealth = 100;
        currentHealth = startHealth;

    }

    // Update is called once per frame
    void Update()
    {

        if (powerUps.slowingTime == false)
        {
            animator.speed = 1f;

        }
        else if (powerUps.slowingTime == true)
        {
            animator.speed = 0.5f;
            
        }
        if ( gameObject.GetComponent<EnemiesHealth>().currentHealth <=0)
        {
            gameObject.GetComponent<Spider>().enabled = false;
        }

        
        Attack();
        
        RotateToPlayer();
        Distance = Vector3.Distance(playerPos.position, transform.position);
        Moving();
    }





    void Rotate()
    {
        transform.Rotate(Vector3.up, 180);
    }



    void RotateToPlayer() // Rotates if Spider is Behind Player

    {
        if (playerPos.position.x > transform.position.x && rotated == false)
        {
            rotated = true;
            Rotate();
        }
        else if (playerPos.position.x < transform.position.x && rotated == true)
        {
            rotated = false;
            Rotate();
        }

    }

    void Moving() // Moving the Spider to be closer to a Player, if initially he is closer than LetAlone value -> 20
    {
        if (Distance > letAlone)
        {

            speed = 0;

            animator.enabled = false;
        }




       else if (Vector3.Distance(transform.position, playerPos.position) > stoppingDistance)
        {
            animator.enabled = true;
            if (powerUps.slowingTime == false)
            {
                animator.speed = 1f;
                speed = 10;
            }
            else if(powerUps.slowingTime == true)
            {
                animator.speed = 0.5f;
                speed = 5f;
            }
            
           
            
            
            animator.SetBool("Run", true);
            transform.position = Vector3.MoveTowards(transform.position,new Vector3 ( playerPos.position.x,transform.position.y,transform.position.z), speed * Time.deltaTime);

        }
       
    }

    void Attack() // if Close Enough,attack the player

    {
        if(Distance <= 3.5f)
        {
            if( didAttack== false  )
            {
                Instantiate(particle1, new Vector3 (transform.position.x,transform.position.y+ 3f,transform.position.z) , Quaternion.identity);
                didAttack = true;
                pH.currentHealth -= 20;
                Destroy(gameObject);
                
            }
            



           
        }
        
    }
    


}
