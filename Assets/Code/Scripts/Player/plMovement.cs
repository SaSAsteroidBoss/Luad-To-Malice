using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

//[RequireComponent(typeof(Rigidbody2D))]
public class plMovement : MonoBehaviour
{
    private Vector2 movVec;

    
    [SerializeField]
    private float speed;

    [Range(0, 1)]
    [SerializeField]
    private float inertia = 0.1f;
    private Vector2 vec =Vector2.zero;


    //private Rigidbody2D rb;
    private void Awake()
    {
        //rb = GetComponent<Rigidbody2D>();
        QualitySettings.vSyncCount = 1;
       
    }
    void OnMove(InputValue input)
    {
        movVec = input.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector2 targPos = (Vector2)transform.position + (movVec * speed);
        transform.position = Vector2.SmoothDamp(transform.position, targPos, ref vec, inertia);
    }
    private void Update()
    {
        //Vector2 targPos = (Vector2)transform.position + (movVec * speed * Time.deltaTime);
        //transform.position = Vector2.SmoothDamp(transform.position, targPos, ref vec, inertia);
    }

    // not frame regulated 
    /*IEnumerator lerpMovement(Vector2 mov)
    {
        float elapsedTime = 0;
        float duration = 1f;
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;

            float x = Mathf.Lerp(movVec.x, mov.x, t);
            float y = Mathf.Lerp(movVec.y, mov.y, t);

            movVec = new Vector2(x, y);
          
            rb.velocity = movVec * speed;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();

        }
    }*/

}