using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField]
    private float sensX;
    [SerializeField]
    private float sensY;

    Camera cam;

    float multiplier = 0.01f;

    float xRotation;
    float yRotation;

    void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        getInput();

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);

    }

    void getInput(){
        float mouseX = Input.GetAxisRaw("Mouse X");        
        float mouseY = Input.GetAxisRaw("Mouse Y");

        yRotation += mouseX * sensX;
        xRotation -= mouseY * sensY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }
}
