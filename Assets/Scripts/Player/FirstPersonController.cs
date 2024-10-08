using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    private Transform cameraTransform;
    private CharacterController characterController;
    private Transform Player;
    private float cameraSensitivity = 60.0f, moveSpeed = 5.0f;
    Vector2 lookInput;
    private float cameraPitch, moveInputDeadZone;
    int leftFingerId, rightFingerId;
    float halfScreenWidth;
    Vector2 moveTouchStartPosition;
    Vector2 moveInput;

    private bool isGrounded;

    private float verticalVelocity;
    private float stickToGroundForce = 10.0F;

    private float dirX, dirY, cameraY, cameraX, xRotation = 0f;
    [SerializeField] Joystick joystickMove, joystickCamera;

    void Start(){

        leftFingerId = -1;
        rightFingerId = -1;
        
        halfScreenWidth = Screen.width/2;
        //moveInputDeadZone = Mathf.Pow(Screen.height / moveInputDeadZone, 2);
        moveInputDeadZone = Screen.height / 2;


		cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
		Player = GameObject.FindGameObjectWithTag("Player").transform;
		characterController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
    }

    void Update(){
        /*GetTouchInput();

        if(rightFingerId != -1){
            LookAround();
        }

        if(leftFingerId != -1){
            Move();
        }*/

        PlayerMovement();
        PlayerCamera();
        UseGravity();
    }
    public void PlayerMovement()
    {
        dirX = joystickMove.Horizontal * moveSpeed * Time.deltaTime;
        dirY = joystickMove.Vertical * moveSpeed * Time.deltaTime;

        Vector3 moveVector = new Vector3(dirX, 0, dirY);
        //characterController.Move(moveVector * Time.deltaTime);
        characterController.Move(Player.transform.right * moveVector.x + Player.transform.forward * moveVector.z);
    }
    public void PlayerCamera()
    {
        cameraX = joystickCamera.Horizontal * cameraSensitivity * Time.deltaTime;
        cameraY = joystickCamera.Vertical * cameraSensitivity * Time.deltaTime;
        //Debug.Log("joystickCamera.Horizontal - " + cameraY);
        Player.Rotate(Vector3.up * -cameraX);
        xRotation += cameraY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);
        
        //Player.Rotate(Vector3.right * cameraY);
        //Player.Rotate(Vector3.right * xRotation);
        //characterController.Move(transform.rotation * xy);
        
        //.Rotate(0, cameraX, 0);
        //transform.Rotate(0,cameraY, 0); 
        //transform.Rotate(xy.x, xy.y, 0, Space.Self);

    }
    void GetTouchInput(){
        for(int i = 0; i < Input.touchCount; i++){
            Touch t = Input.GetTouch(i);

            switch(t.phase){
                case TouchPhase.Began:
                    if(t.position.x < halfScreenWidth && leftFingerId == -1){
                        leftFingerId = t.fingerId;
                        moveTouchStartPosition = t.position;
                    }
                    else if(t.position.x > halfScreenWidth && rightFingerId == -1){
                        rightFingerId = t.fingerId;
                    }

                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    if(t.fingerId == leftFingerId){
                        leftFingerId = -1;
                    }
                    else if(t.fingerId == rightFingerId){
                        rightFingerId = -1;
                    }
                    break;
                case TouchPhase.Moved:
                    if(t.fingerId == rightFingerId){
                        lookInput = t.deltaPosition * cameraSensitivity * Time.deltaTime;
                    }
                    else if(t.fingerId == leftFingerId){
                        moveInput = t.position - moveTouchStartPosition;
                    }

                    break;
                case TouchPhase.Stationary:
                    if(t.fingerId == rightFingerId){
                        lookInput = Vector2.zero;
                    }
                    break;
            }
        }
    }
/*
    void LookAround(){
        cameraPitch = Mathf.Clamp(cameraPitch - lookInput.y, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(cameraPitch, 0, 0);

        transform.Rotate(transform.up, lookInput.x);
    }
	
    void Move(){
        if(moveInput.sqrMagnitude <= moveInputDeadZone) return;
        Vector2 movementDirection = moveInput.normalized * moveSpeed * Time.deltaTime;
        characterController.Move(transform.right *  movementDirection.x + transform.forward * movementDirection.y);
    }
*/
    void UseGravity()
    {
        if (characterController.isGrounded)
        {
            verticalVelocity = -stickToGroundForce * Time.deltaTime;
        }
        else
        {
            verticalVelocity -= stickToGroundForce * Time.deltaTime;
        }

        Vector3 moveVector = new Vector3(0, verticalVelocity, 0);
        characterController.Move(moveVector * Time.deltaTime);
    }
  
}
