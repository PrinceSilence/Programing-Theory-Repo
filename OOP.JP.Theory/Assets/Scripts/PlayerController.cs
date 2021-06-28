using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int moveSpeed;
    private float mouseSensitivity;
    private int jumpForce;

    private float xRotation = 0f;

    private Camera playerCam;

    private void Start()
    {
        playerCam = GameObject.Find("playerCam").GetComponent<Camera>();
        moveSpeed = 7;
        jumpForce = 200;
        mouseSensitivity = 150f;
        Cursor.visible = false;
    }

    void Update()
    {
        Move();   

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Move()
    {
        //===========Inputs=========//
        float moveRL = Input.GetAxis("Horizontal");
        float moveFB = Input.GetAxis("Vertical");
        float rotateRL = Input.GetAxis("Mouse X");
        float rotateUD = Input.GetAxis("Mouse Y");

        //==========Keyboard Movment=========//
        transform.Translate(Vector3.right * Time.deltaTime * moveRL * moveSpeed);                   //Move Right/Left
        transform.Translate(Vector3.forward * Time.deltaTime * moveFB * moveSpeed);                 //Move Foward/Back

        //=========Mouse Movement=========//
        transform.Rotate(Vector3.up * Time.deltaTime * rotateRL * mouseSensitivity);                    //Rotate Right/Left
        
        xRotation -= rotateUD * Time.deltaTime * mouseSensitivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        playerCam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);                          //Rotate cam Up/Down

    }
    void Jump()
    {
      Rigidbody playerRB = gameObject.GetComponent<Rigidbody>();

        playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}