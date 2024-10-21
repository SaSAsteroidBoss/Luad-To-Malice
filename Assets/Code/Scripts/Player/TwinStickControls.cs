using UnityEngine;
using UnityEngine.InputSystem;

public class TwinStickControls : MonoBehaviour
{
    CharacterController _controller;

    Vector2 _moveInput;

    Vector2 _lookInput;

    public float speed;

    private void Start()
    {

    }

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }


    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }

    private void MoveCharacter()
    {
        var movement = transform.right * _moveInput.x + transform.up * _moveInput.y;
        _controller.Move(movement * (speed * Time.deltaTime));
    }
}
