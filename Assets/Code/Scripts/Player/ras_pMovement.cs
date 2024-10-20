using UnityEngine;
using UnityEngine.InputSystem;

public class ras_pMovement : MonoBehaviour
{
    [Header("Stopping speed")]
    [Range(1f, 50f)]
    [SerializeField] private float inertia = 0.1f;

    [Header("acceleration")]
    [Range(1f, 100f)]
    [SerializeField] private float speed = 1.0f;

    [SerializeField] private int maxSpeed = 20;

    private Vector3 inputVec = Vector3.zero;
    private Vector3 playerPos = Vector3.zero;

    void OnMove(InputValue Vec)
    {
        print("On Move");
        Vector2 mov = Vec.Get<Vector2>();
        inputVec = new Vector3(mov.x, mov.y, 0);
    }
   
    private void transformMovement()
    {
        if(inputVec.magnitude > 0)
        {
            var transVec = transform.rotation * (inputVec * speed * Time.deltaTime);
            playerPos += transVec;
        }
        else
        {
            playerPos = Vector3.Lerp(playerPos, Vector3.zero, inertia * Time.deltaTime);
        }

        playerPos = Vector3.ClampMagnitude(playerPos, maxSpeed);

        transform.position += playerPos * Time.deltaTime;
    }

    private void Update()
    {
        transformMovement();
    }
}
