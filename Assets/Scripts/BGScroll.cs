using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public float spawnY;
    public float yMin;
    public float speed;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
        
        if (transform.position.y < yMin)
        {
            transform.position = new Vector3(
                transform.position.x,
                spawnY,
                transform.position.z);
        }
    }
}
