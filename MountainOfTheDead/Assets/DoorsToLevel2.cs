using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

public class DoorsToLevel2 : MonoBehaviour
{

    public bool isInRange;
    public KeyCode interactKey;
    public float Keys;
    public GameObject doors;
    private int numberInDoors;
    public TextMeshProUGUI findKeysText;
    public TextMeshProUGUI keysNumber;
    public TextMeshProUGUI useEText;
    public TextMeshProUGUI thankYouText;

    // Start is called before the first frame update
    void Start()
    {
        numberInDoors = 0;
        Keys = 0;
    }

    // Update is called once per frame
    void Update()
    {
        keysNumber.text = "" + Keys;
        if(isInRange == true && Keys == 3)
        {
            
            if (Input.GetKey(interactKey))
            {
                useEText.gameObject.SetActive(false);
                thankYouText.gameObject.SetActive(true);
                Destroy(doors);
               
            }
        }
       if(isInRange == true && numberInDoors == 0)
        {
            numberInDoors += 1;
            StartCoroutine("showObjective");
        }
    }




    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("InRange");

        }
        else
        {
            isInRange = false;
        }
    }


   IEnumerator showObjective()
    {
        findKeysText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        findKeysText.gameObject.SetActive(false);
        keysNumber.gameObject.SetActive(true);
    }
}
