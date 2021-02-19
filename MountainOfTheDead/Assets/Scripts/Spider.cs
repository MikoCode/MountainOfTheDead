using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    private Transform playerPos;
    private Spider spider;
    public Animator animator;
    private PowerUps powerUps;
    private bool rotated;
    private float Distance;
    private float stoppingDistance;
    public float  speed;
    private float letAlone;
    public float currentHealth;
    private float startHealth;
    public EnemiesHealth eH;
    public float startTimeBtwAttack;
    private bool didAttack;
        public float TimeBtwAttack;
    private PlayerHealthManager pH;
    // Start is called before the first frame update
    void Start()
    {
        powerUps = GameObject.Find("Player").GetComponent<PowerUps>();
        didAttack = false;
        TimeBtwAttack = startTimeBtwAttack;
       
        pH = GameObject.Find("Player").GetComponent<PlayerHealthManager>();
        speed = 5;
        stoppingDistance = 2;
        letAlone = 20;
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
        playerPos = GameObject.Find("Player").GetComponent<Transform>();
        RotateToPlayer();
        Distance = Mathf.Abs(playerPos.position.x - transform.position.x);
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
                speed = 5;
            }
            else if(powerUps.slowingTime == true)
            {
                animator.speed = 0.5f;
                speed = 2.5f;
            }
            
           
            
            
            animator.SetBool("Run", true);
            transform.position = Vector3.MoveTowards(transform.position,new Vector3 ( playerPos.position.x,transform.position.y,transform.position.z), speed * Time.deltaTime);

        }
       
    }

    void Attack() // if Close Enough,attack the player

    {
        if(Distance <= 2.33f)
        {
            if(TimeBtwAttack <= 0 && didAttack== false && powerUps.slowingTime == false)
            {
                didAttack = true;
                pH.currentHealth -= 10;
                TimeBtwAttack = startTimeBtwAttack;
            }
            else
            {
                didAttack = false;
                TimeBtwAttack -= Time.deltaTime;
            }



            animator.SetBool("Attack", true);
        }
        else if ( Distance > 2.33f)
        {
            animator.SetBool("Attack", false);
        }
    }
    


}
