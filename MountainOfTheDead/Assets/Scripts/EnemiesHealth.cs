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
    public GameObject hP;
    public int randomNumber;
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
        randomNumber = Random.Range(1, 10);
    }



    public void TakeDamage(float damage)
    {

        StartCoroutine("StopAttack");
        currentHealth -= damage;
        rangerAnim.SetTrigger("takeDamage");
        Debug.Log("TakeDamage");
        if (currentHealth <= 0 && isDead == false) 
        {
            isDead = true;
            StartCoroutine("DropPotion");
            rangerAnim.SetTrigger("Dead");
            Destroy(gameObject, 1.5f);
            
        }

    }
    IEnumerator StopAttack()
    {
        takingDamage = true;
        yield return new WaitForSeconds(1f);
        takingDamage = false;
    }
    IEnumerator DropPotion()
    {
        yield return new WaitForSeconds(1.2f);
        if(randomNumber >= 9 )
        {
            Instantiate(hP, transform.position, Quaternion.identity);
        }
        
    }

}
