using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    private PlayerInput input;

    [Header("Movement")] 
    [SerializeField] private float movementSpeed;
    [SerializeField] private float movementCrouchedSpeed;
    [SerializeField] private float gravityScale;
    [SerializeField] private float movementSmoothFactor;

    [Header("Ground Detection")] 
    [SerializeField] private Transform feet;
    [SerializeField] private float detectionRadius;
    [SerializeField] private LayerMask whatIsGround;

    private CharacterController controller;

    private bool isGrounded;

    private Vector2 inputVector;
    private Vector3 horizontalMovement;
    private Vector3 verticalMovement;
    private Vector3 totalMovement;
    
    
    private float targetSpeed;
    private float currentSpeed;
    private float speedVelocity;

    private Camera cam;
    private float rotationVelocity;
    private float rotationSmoothFactor;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        input = GetComponent<PlayerInput>();
        
        cam = Camera.main;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable()
    {
        input.actions["Move"].performed += UpdateMovement;
        input.actions["Move"].canceled += UpdateMovement;

        input.actions["Crouch"].started += PlayerCrouch;
    }

    private void OnDisable()
    {
        input.actions["Move"].performed -= UpdateMovement;
        input.actions["Move"].canceled -= UpdateMovement;

        input.actions["Crouch"].started -= PlayerCrouch;
    }

    private void PlayerCrouch(InputAction.CallbackContext obj)
    {
        Debug.Log("Crouching");
        // animacion
        // cambiar la velocidad
        //cambiar la collision de la capsula (el centro y el height)
    }
    

    private void UpdateMovement(InputAction.CallbackContext obj)
    {
        inputVector = obj.ReadValue<Vector2>();
    }


    private void Update()
    {
        GroundCheck();
        ApplyGravity();
        
        MoveAndRotate();
    }

    private void MoveAndRotate()
    {
        targetSpeed = movementSpeed * inputVector.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedVelocity, movementSmoothFactor);

        if (inputVector.sqrMagnitude > 0)
        {
            float angleToRotate = Mathf.Atan2(inputVector.x, inputVector.y) * Mathf.Rad2Deg +
                                  cam.transform.eulerAngles.y;

            horizontalMovement = (Quaternion.Euler(0, angleToRotate, 0) * Vector3.forward) * movementSpeed;

            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angleToRotate, ref rotationVelocity,
                rotationSmoothFactor);

            transform.rotation = Quaternion.Euler(0, smoothAngle, 0);
        }
        else
        {
            horizontalMovement = Vector3.zero;
        }
        
        anim.SetFloat("Speed", currentSpeed/movementSpeed);
        totalMovement = horizontalMovement + verticalMovement;

        controller.Move(totalMovement * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        if (isGrounded && verticalMovement.y < 0)
        {
            verticalMovement.y = -2f;
        }
        else
        {
            verticalMovement.y += gravityScale * Time.deltaTime;
        }
    }

    private void GroundCheck()
    {
        if (Physics.CheckSphere(feet.position, detectionRadius, whatIsGround))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(feet.position, detectionRadius);
    }
}
