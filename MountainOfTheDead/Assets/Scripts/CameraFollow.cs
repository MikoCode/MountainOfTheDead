using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.05f;
    [Range(1, 10)]
   
    public float smoothFactor;
  
  

    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        
        Follow();
    }



    void Follow()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothedPosition;
        transform.LookAt(target);
        gameObject.transform.rotation = Quaternion.Euler(0, 3f, 0);
    }
}
