using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    private PlayerController playerCon;
    private Spider spider;
    private Arrow arrow;
    private Ranger ranger;
    private float times;
    public GameManager gameManager;
    public bool slowingTime;
    // Start is called before the first frame update
    void Start()
    {

        slowingTime = false;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        times = 5;
        spider = GameObject.FindGameObjectWithTag("Spider").GetComponent<Spider>();
        playerCon = GameObject.Find("Player").GetComponent<PlayerController>();
      
        ranger = GameObject.FindGameObjectWithTag("Ranger").GetComponent<Ranger>();
        

    }

    // Update is called once per frame
    void Update()
    {
        useTimeTea();
    }

    void useTimeTea() 
    
    
    
    {

        if (Input.GetKeyDown("2") && gameManager.TeaNumber > 0)
        {
            gameManager.TeaNumber -= 1;
            StartCoroutine(TimeTea(times));
        }

    }

    IEnumerator TimeTea(float times)
    {
        slowingTime = true;
        Debug.Log("UseTimeTea");

        
        yield return new WaitForSeconds(times);
        Debug.Log("TimeTeaFinished");
        slowingTime = false;
        

    }

}
