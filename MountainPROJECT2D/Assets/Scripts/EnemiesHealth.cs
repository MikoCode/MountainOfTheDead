using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesHealth : MonoBehaviour
{
    public float currentHealth;
    public float startingHealth;
    public Animator rangerAnim;
    public bool isDead;
    public bool takingDamage;
   
    // Start is called before the first frame update
    void Start()
    {
        takingDamage = false;

        currentHealth = startingHealth; 
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void TakeDamage(int damage)
    {
        
        currentHealth -= damage;
        rangerAnim.SetTrigger("takeDamage");
        Debug.Log("TakeDamage");
        if (currentHealth <= 0 && isDead == false) 
        {
            isDead = true;

            rangerAnim.SetTrigger("Dead");
            Destroy(gameObject, 2f);
            
        }

    }

}
