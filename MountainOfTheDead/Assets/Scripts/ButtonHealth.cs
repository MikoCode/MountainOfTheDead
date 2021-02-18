using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHealth : MonoBehaviour
{
    private PlayerController playerController;
    private PlayerHealthManager playerHealth;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManger").GetComponent<GameManager>();

        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void Health()
    {
        playerHealth.startHealth = playerHealth.startHealth * 1.1f;
        gameManager.buttonHealth.enabled = false;
        gameManager.buttonHealth.enabled = false;
    }

   public void Damage()
    {
        playerController.damage = playerController.damage * 1.1f;
        gameManager.buttonHealth.enabled = false;
        gameManager.buttonHealth.enabled = false;
    }
}
