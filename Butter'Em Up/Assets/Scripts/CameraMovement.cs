using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 max;
    public Vector2 min;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(
                Mathf.Clamp(target.position.x, min.x, max.x),
                Mathf.Clamp(target.position.y, min.y, max.y), 
                transform.position.z
                );



            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
        
    }
}
