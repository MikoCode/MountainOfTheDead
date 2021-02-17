using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranger : MonoBehaviour
{



    // Some Overall notes for future
    // I should let Ranger run away from player if he is too close, or make it punch the player in the same situation.


    public  PlayerController playerCon;
    private PowerUps powerUps;
    public  Transform playerPos;
    private Transform currentTransform;
    private Transform newTransform;
    public  Animator animator;
    public Transform arrowPos;
    public GameObject arrow;
    private float Distance;
    private float followDistance;
    public float speed;
    private float shootDistance;
    private float distanceToFollow;
    private float positiveDistanceToFollow;
    private float times;
    private float seconds;
    public float timeBtwShots;
    private float startTimeBtwShots;
    public bool didShot;
    private float random1;
    private float random2;
    private float random3;
    private float random4;
   
    
    private bool rotated;
    private bool secondRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        random1 = Random.Range(10, 14);
        random2 = Random.Range(22, 23);
             random3 = Random.Range(3, 7);
        random4 = Random.Range(21, 28);
        powerUps = GameObject.Find("Player").GetComponent<PowerUps>();
        didShot = false;
        times = 0f;
        
        speed = 2;
        timeBtwShots = startTimeBtwShots;
        

        playerCon = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (powerUps.slowingTime == false)
        {
            animator.speed = 1f;
        }
        if (powerUps.slowingTime == true)
        {
            animator.speed = 0.5f;
        }
        if (gameObject.GetComponent<EnemiesHealth>().currentHealth <= 0)
        {
            gameObject.GetComponent<Ranger>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

        currentTransform = transform;
        playerPos = GameObject.Find("Player").transform;
        
        FirstRotation();
        shootDistance =  13; // Making some distances random,to make it less predictable

        Moving();
        distanceToFollow = -4;

        Attack();

        positiveDistanceToFollow = 4;




    }


    private void Attack()
    {

        Distance = Mathf.Abs(playerPos.position.x - currentTransform.position.x);
        if(Distance <= shootDistance && Distance > 3 && animator.GetBool("Run") == false)
        {
            startTimeBtwShots = 1;
            animator.SetBool("Shoot", true);
            if (timeBtwShots <= 0 && didShot == false)
            {
                Instantiate(arrow, arrowPos.position , Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
                didShot = true;
            }
           else 
            {
                didShot = false;
                timeBtwShots -= Time.deltaTime;
            }

        }
        else if( Distance <= 3)
        {
            startTimeBtwShots = 3;
            animator.SetBool("Shoot", true);
            if (timeBtwShots <= 0 && didShot == false)
            {
                Instantiate(arrow, arrowPos.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
                didShot = true;
            }
            else
            {
                didShot = false;
                timeBtwShots -= Time.deltaTime;
            }

        }


    }




  

    private void Moving() // Moving Ranger to a Player,if the distance to shoot is to far.
    {
        if (Distance >= random1 && Distance <= random2) // If Ranger notice player,Run to him to save distance
        {
            if (rotated == true)
            {
                followDistance = positiveDistanceToFollow;
            }
            else if (rotated == false)
            {
                followDistance = distanceToFollow;
            }
            animator.SetBool("Run",true);
            animator.SetBool("Shoot", false);


            if (powerUps.slowingTime == false)
            {
                speed = 2;
            }
            if(powerUps.slowingTime == true){
                speed = 1;
            }
           

            if(animator.GetBool("Run") == true)
            {
                StartCoroutine(Execute(times));
            }
           
            
        }
        else if(Distance >= random3) // Stop at the save  distance
        {
            animator.SetBool("Run", false);
            speed = 0;
            animator.SetTrigger("Idle");
        }


        


        else if( Distance >= random4) // Ranger loses Player from his sight
        {
            animator.SetBool("Run", false);
            animator.SetTrigger("Idle");
            speed = 0;
        }
    }



    private void RotateToPlayer()
    {
        currentTransform.transform.Rotate(Vector3.up, 180);

    }
    private void FirstRotation()
    {
        if (playerPos.position.x > currentTransform.position.x && rotated == false)
        {
            RotateToPlayer();
           
            rotated = true;
            

        }
        else if (playerPos.position.x < currentTransform.position.x && rotated == true)
        {
            RotateToPlayer();
            rotated = false;
           
           
            
        }
        
    }


   



    IEnumerator Execute(float times) // Actuall Moving,but delayed to fit the animation
    {
        yield return new WaitForSeconds(times);
        transform.position += new Vector3(followDistance, 0, 0) * Time.deltaTime * speed;
    }



    
}
    
