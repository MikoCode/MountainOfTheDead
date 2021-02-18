using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    private PlayerController playerController;
    private PlayerHealthManager playerHealth;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealthManager>();
        gameManager = GameObject.Find("GameManger").GetComponent<GameManager>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            
        {
            gameManager.buttonDamage.enabled = true;
            gameManager.buttonHealth.enabled = true;
        }
    }
}
