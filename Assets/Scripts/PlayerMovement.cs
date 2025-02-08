using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool isMoving = false;
    public float limit;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            float currentMouseX =  Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            transform.position = new Vector3(currentMouseX, transform.position.y, transform.position.z);

            if (transform.position.x < -limit)
            {
                transform.position = new Vector3(-limit, transform.position.y, transform.position.z);
            }
            else if (transform.position.x > limit)
            {
                transform.position = new Vector3(limit, transform.position.y, transform.position.z);
            }
        }
    }

    private void OnMouseDown()
    {
        isMoving = true;
    }

    private void OnMouseUp()
    {
        isMoving = false;
    }
}
