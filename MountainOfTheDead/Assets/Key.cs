using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private DoorsToLevel2 keysNumber;
    // Start is called before the first frame update
    void Start()
    {
        keysNumber = GameObject.Find("Door").GetComponent<DoorsToLevel2>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 90f * Time.deltaTime, 0f);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            keysNumber.Keys += 1;
            Destroy(gameObject);
        }
    }
}
