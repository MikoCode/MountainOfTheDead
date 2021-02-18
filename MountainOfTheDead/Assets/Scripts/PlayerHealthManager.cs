using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public float currentHealth;
    public float startHealth;
    private GameManager gameManager;
    public Animator animator;
    private float times = 1.2f;
    private PlayerController playerCon;




    // Start is called before the first frame update
    void Start()
    {
        playerCon = GameObject.Find("Player").GetComponent<PlayerController>();
        
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        currentHealth = startHealth;
    }

    // Update is called once per frame
    void Update()
    {


        if(currentHealth >= startHealth)
        {
            currentHealth = startHealth;
        }
        usePotion();
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }



    void usePotion()
    {
        if (Input.GetKeyDown("1") && gameManager.potionsNumber > 0)
        {

            StartCoroutine(Potion(times));
        }  
            

        
    }


    IEnumerator Potion(float times)
    {
        playerCon.enabled = false;
        gameManager.potionsNumber -= 1;
        animator.SetTrigger("Consume");
        yield return new WaitForSeconds(times);
        playerCon.enabled = true;
        animator.SetTrigger("Idle");
        currentHealth += 50;
      

    }



    
}
