using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float xSpeed = 0f;
    [SerializeField] public float ySpeed = 0.1f;
    [SerializeField] public float zSpeed = 0f;
    [SerializeField] public float steerSpeed = 0.5f;

    float steerAmount;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        float moveAmount = Input.GetAxis("Vertical") * ySpeed * Time.deltaTime;
        if (moveAmount < 0 || moveAmount > 0) {
            steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        } else {
            steerAmount = 0;
        }
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(xSpeed,moveAmount,zSpeed);

        // if (Input.GetKeyDown("Jump")) {
        //     ResetPosition();
        // }

    }

    void ResetPosition() {
        Debug.Log("Pressing Space Bar");
        transform.position = new Vector3(0,0,0);
    }
}
