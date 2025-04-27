using UnityEngine;
using UnityEngine.InputSystem;
using Baracuda.Monitoring;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] InputActionReference moveAction;
    [SerializeField] InputActionReference jumpAction;
    CharacterController cc;
    float velocity_y = 0;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();
        VerticalMove();

        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y).normalized;
        moveDirection.y = velocity_y;
        cc.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void VerticalMove()
    {
        if (cc.isGrounded) velocity_y = -2f;
        else velocity_y += gravity * Time.deltaTime;

        if (jumpAction.action.triggered && cc.isGrounded) velocity_y = jumpSpeed;
    }
}
