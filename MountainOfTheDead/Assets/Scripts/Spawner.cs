using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject Ranger;
    public GameObject Spider;
    public float enemiesSpawned;
    public Transform Player;
    public BoxCollider2D box2d;
    private float distanceFromPlayer;
    private float chances;

    // Start is called before the first frame update
    void Start()
    {
       
        enemiesSpawned = 0;
    }

    // Update is called once per frame
    void Update()
    {

        chances = Random.Range(1, 3);
        if(chances == 1)
        {
            distanceFromPlayer = 25;
        }
        else
        {
            distanceFromPlayer = -25;
        }
        if(enemiesSpawned >= 10)
        {
            CancelInvoke();
        }
    }





    void SpawnRanger()
    {
        Instantiate(Ranger, new Vector3(Player.position.x - 20, Player.position.y, Player.position.z), Quaternion.Euler(0f,-75f,0f));
        enemiesSpawned += 1;
    }

    void SpawnSpider()
    {
        Instantiate(Spider, new Vector3(Player.position.x + distanceFromPlayer, Player.position.y, Player.position.z), Quaternion.Euler(0f, -75f, 0f));
            enemiesSpawned += 1;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InvokeRepeating("SpawnRanger", 1f, 5f);
            InvokeRepeating("SpawnSpider", 1f, 5f);
            box2d.enabled = false;

        }
    }
}
