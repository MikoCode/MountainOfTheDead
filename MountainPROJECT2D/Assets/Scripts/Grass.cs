using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    public ParticleSystem grassParticle;
    public GameObject leaf;
    public bool spawnedleaf;
    private float chances;

    private Vector2 leafPos;
    private Vector2 leafPos2;
    // Start is called before the first frame update
    void Start()
    {
        chances = Random.Range(1, 10);
        spawnedleaf = false;
    }

    // Update is called once per frame
    void Update()
    {
        leafPos = new Vector2(transform.position.x + Random.Range(0.1f,0.98f), transform.position.y + 2);
        leafPos2 = new Vector2(transform.position.x - Random.Range(0.1f,0.98f), transform.position.y + 2);
    }



   public void Destruction( float time)
    {
      
        
            Instantiate(leaf, leafPos, Quaternion.identity);
            Instantiate(leaf, leafPos2, Quaternion.identity);
        

           




        Instantiate(grassParticle, transform.position, Quaternion.identity);
       
        Destroy(gameObject, time);
       
       
    }
}
