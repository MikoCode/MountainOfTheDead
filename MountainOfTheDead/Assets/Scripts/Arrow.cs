using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private Transform player;
    private Vector2 target;

    private PowerUps powerUps;
    private PlayerHealthManager playerHealth;
    private PlayerController playerCon;
   
    // Start is called before the first frame update
    void Start()
    {
        powerUps = GameObject.Find("Player").GetComponent<PowerUps>();
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealthManager>();
        playerCon = GameObject.Find("Player").GetComponent<PlayerController>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y + 1.5f);
        
        
    }

    // Update is called once per frame
    void Update()
    {


        if(powerUps.slowingTime == true)
        {
            speed = 7.5f;
        }
        else if(powerUps.slowingTime == false)
        {
            speed = 15;
        }

        if (transform.position.x == target.x && transform.position.y == target.y)
        
        
        {
            Destroy(gameObject);
        }








        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(playerCon.isImmortal == false)
            {
                playerHealth.currentHealth -= 25;
                Debug.Log("PlayerHit");

            }

        }
        
    }




    public void Destruction()
    {

        Destroy(gameObject);
       







        

        


    }
}
