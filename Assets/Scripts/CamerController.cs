using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.InputSystem;

public class CamerController : MonoBehaviour
{

    public Transform PlayerTransform;
    private float speed = 0.001f;
    private Vector3 forward;
    private float rot;
    public Transform camera;
    //public Vector3 offset;
     

    public void Update(){


        // Vector3 mouse = Input.mousePosition;
        // float x = mouse.x * 0.05f;
        // float y = mouse.y * 0.05f;
        // float z = mouse.z * 0.05f;
        // PlayerTransform.rotation = Quaternion.Euler(-y, x, z);


        if(Input.GetKey(KeyCode.LeftShift)){
            speed = 0.010f;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 0.001f;
        }
        if(Input.GetKey("a")){
            PlayerTransform.position -= new Vector3(1,0,0)* speed;
        }
        if(Input.GetKey("d")){
            PlayerTransform.position += new Vector3(1,0,0)* speed;
            // rot += 0.05f;

            // Debug.Log(rot);
            // PlayerTransform.rotation = Quaternion.Euler(0,rot,0);
        }
        if(Input.GetKey("s")){
            PlayerTransform.position -= new Vector3(0,0,1)* speed;
        }
        if(Input.GetKey("w")){
            PlayerTransform.position += new Vector3(0,0,1)* speed;
        }
    }
}
