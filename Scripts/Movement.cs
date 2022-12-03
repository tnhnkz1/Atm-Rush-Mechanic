using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float forwardSpeed;
    public float horizontalSpeed;
    public float limitX; 

    void Start()
    {
        
    }

    
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime;
        this.transform.Translate(horizontalAxis, 0, forwardSpeed * Time.deltaTime);

        float newX = 0;
        float touchXDelta = 0;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0))
        {
            touchXDelta = Input.GetAxis("Mouse X");
        }

        newX = transform.position.x + horizontalSpeed * touchXDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limitX, limitX);


        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + forwardSpeed * Time.deltaTime);
        transform.position = newPosition;
    }
}
