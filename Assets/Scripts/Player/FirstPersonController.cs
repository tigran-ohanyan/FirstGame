using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public Transform cameraTransform;
    public CharacterController characterController;
    public Transform Player;
    public float cameraSensitivity, moveSpeed;
    Vector2 lookInput;
    private float cameraPitch, moveInputDeadZone;
    int leftFingerId, rightFingerId;
    float halfScreenWidth;
    Vector2 moveTouchStartPosition;
    Vector2 moveInput;

    [SerializeField] private bool isGrounded;

    private float verticalVelocity;
    [SerializeField] private float stickToGroundForce = 10.0F;

    private float dirX, dirY, cameraY, cameraX, xRotation = 0f;
    [SerializeField] Joystick joystickMove, joystickCamera;

    void Start(){

        leftFingerId = -1;
        rightFingerId = -1;
        
        halfScreenWidth = Screen.width/2;
        //moveInputDeadZone = Mathf.Pow(Screen.height / moveInputDeadZone, 2);
        moveInputDeadZone = Screen.height / 2;
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
    void PlayerMovement()
    {
        dirX = joystickMove.Horizontal * moveSpeed * Time.deltaTime;
        dirY = joystickMove.Vertical * moveSpeed * Time.deltaTime;

        Vector3 moveVector = new Vector3(dirX, 0, dirY);
        //characterController.Move(moveVector * Time.deltaTime);
        characterController.Move(transform.right * moveVector.x + transform.forward * moveVector.z);
    }
    void PlayerCamera()
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

    void LookAround(){
        cameraPitch = Mathf.Clamp(cameraPitch - lookInput.y, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(cameraPitch, 0, 0);

        transform.Rotate(transform.up, lookInput.x);
    }

    void Move(){
       // Debug.Log(moveInput.sqrMagnitude);
        if(moveInput.sqrMagnitude <= moveInputDeadZone) return;
        Vector2 movementDirection = moveInput.normalized * moveSpeed * Time.deltaTime;
       // transform.position = new Vector2(movementDirection.x, movementDirection.y);
        characterController.Move(transform.right *  movementDirection.x + transform.forward * movementDirection.y);
    }

    void UseGravity()
    {
        /*float y = gameObject.GetComponent<Transform>().position.y;
        if(y >= 1)
        {
            y -= y * Time.deltaTime;

        }

        transform.position = new Vector3(transform.position.x, y, transform.position.z);
        Debug.Log(y);*/
        /*
        y = gameObject.GetComponent<Transform>().position.y;
        isGrounded = characterController.isGrounded;
        

        if(isGrounded == false && y >= 1f)
        {
            gravity = y - 2f;
            transform.position.y = gravity;
           // Debug.Log(isGrounded);
            //Debug.Log("Gravity - " + gravity);
            //transform.position = new Vector3(transform.position.x, gravity, transform.position.z);
            
        }
        else
        {
            gravity = 1f;
            //gravity = 0.5f;
            //Debug.Log(isGrounded);

            // transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        }
        Debug.Log(gravity);
      //  transform.position = new Vector3(transform.position.x, gravity * Time.deltaTime, transform.position.z);
        Debug.Log(characterController.isGrounded);*/

       //isGrounded = controller.isGrounded;

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
