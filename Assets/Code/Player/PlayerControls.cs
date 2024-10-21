using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed
    private Rigidbody2D rb;
    private Vector2 movementInput;
    private Vector2 aimInput;

    public enum Classes { Ranged, Melee};
    public Classes pClass;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Called when the movement input changes
    public void OnMove(InputValue value)
    {
        //print("Left Stick Moved");
        movementInput = value.Get<Vector2>();
    }

    // Called when the aiming input changes
    public void OnLook(InputValue value)
    {
        //print("Right Stick Moved");
        aimInput = value.Get<Vector2>();
    }

    public void OnAttack()
    {
        //print("Right Bumper Pressed");
        if (pClass == Classes.Ranged)
        {
            GetComponent<RangedAttack>().Fire();
        }
        else if (pClass == Classes.Melee)
        {
            GetComponent<MeleeAttack>().Swing();
        }
    }

    void Update()
    {
        // Move the player
        rb.velocity = movementInput.normalized * moveSpeed;

        // Aim the player
        if (aimInput != Vector2.zero)
        {
            float angle = Mathf.Atan2(aimInput.y, aimInput.x) * Mathf.Rad2Deg - 90f; // Adjust for sprite orientation
            rb.rotation = angle; // Rotate the player towards the aim direction
        }
    }
}
