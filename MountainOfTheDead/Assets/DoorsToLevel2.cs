using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorsToLevel2 : MonoBehaviour
{

    public bool isInRange;
    public KeyCode interactKey;
    public float Keys;
    public GameObject doors;

    // Start is called before the first frame update
    void Start()
    {
        Keys = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange == true && Keys == 3)
        {
            if (Input.GetKey(interactKey))
            {
                Destroy(doors);
            }
        }
    }




    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("InRange");

        }
    }
}
