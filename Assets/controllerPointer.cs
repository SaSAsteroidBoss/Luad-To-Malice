using UnityEngine;
using UnityEngine.InputSystem;

public class controllerPointer : MonoBehaviour
{
    private Vector3 inputVec;
    //private Vector3 playerPos = Vector3.zero;

    [SerializeField]
    private float sensitivity;
    
    [SerializeField]
    private Transform pointer;
   void OnStickDelta(InputValue value)
   {
        Vector2 mov = value.Get<Vector2>();
        inputVec = new Vector3(mov.x, mov.y,0);

   }


   void Update()
   {
        //var transVec =  Vector3.one + inputVec * (sensitivity * Time.deltaTime);
        var vec = inputVec * sensitivity * Time.deltaTime;
        print(inputVec);
        pointer.position += vec;


   }
}
