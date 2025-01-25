using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour // Add MonoBehaviour to attach it to a GameObject
{
    InputSystem_Actions inputActions;
    InputAction moveAction;

    [SerializeField] float speed=6;
    Vector2 direction;

    void Start()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Player.Enable();
        inputActions.Player.Move.performed += SetInput;
        inputActions.Player.Move.canceled += SetInput;
    }

    private void SetInput(InputAction.CallbackContext ctx)
    {
        direction = ctx.ReadValue<Vector2>();
        print(direction);
    }

    void Update()
    {
        MovePlayer();
    }


    void MovePlayer()
    {    
            transform.position += new Vector3(direction.x, 0, direction.y) * speed*Time.deltaTime; // Apply movement
       
    }

    private void OnDisable()
    {
        inputActions.Player.Move.performed -= SetInput;
        inputActions.Player.Move.canceled -= SetInput;
    }
}