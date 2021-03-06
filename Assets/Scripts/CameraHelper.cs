using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHelper : MonoBehaviour
{
    public Transform playerTransform;

    public float followingSpeed = 2f;

    public float rotationSpeed = 90f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform != null){
            this.transform.position = Vector3.Lerp(this.transform.position, playerTransform.position, followingSpeed * Time.deltaTime);
        }
        int border = Screen.width / 6;
        
        if(Input.GetKey(KeyCode.E) || Input.mousePosition.x > Screen.width - border){
            this.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0, Space.Self);
        }
        if(Input.GetKey(KeyCode.Q) || Input.mousePosition.x < border){
            this.transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0, Space.Self);
        }
    }
}
