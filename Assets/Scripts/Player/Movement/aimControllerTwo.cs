using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// script should be attatched to the player Object.
/// Create an empty child object in the centre of the player and add your gun object to that. 
/// It must be named "Gun"
/// Example:
/// |-- Player/
/// |   |-- Pivot/
/// |   |   |-- Gun/
/// </summary>

public class aimControllerTwo : MonoBehaviour
{
    private AimData AimData;
    
    private bool canRun = false;
    
    [HideInInspector]
    public float angle, offset;
   
    private Vector3 inputVec;
    
    [SerializeField]
    private float sensitivity;
    
    public GameObject pointerObj;

    private Canvas canvas;
    

    private void Awake()
    {
        AimData.radius = 0.5f;
    }

    void Start()
    {
        initAimData();
       // lastPos = transform.position;

    }
    void initAimData()
    {
        //AimData.radius = 0.5f;
        Transform[] children = transform.GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            if (child.name == "Gun")
            {
                AimData.orb = child;
                AimData.pivot = child.parent;
                AimData.orb.position += Vector3.up * AimData.radius;
                
                canRun = true;
              
                offset = AimData.radius;
            
            } 
        }
        if (canRun == false)
        {
            Debug.LogWarning("Could not find child object named Gun for AimControllerTwo.cs please Check Script Descripton for correct setup ");
        }
        
    }
    void OnStickDelta(InputValue value)
    {
        Vector2 mov = value.Get<Vector2>();
        inputVec = new Vector3(mov.x, mov.y,0);

    }
    
    private void Update()
    {
        if (canRun)
        {
            CalAngle();
            
           //MovePointer();   
           MovePointerTwo();
        }
    }

    private void CalAngle()
    {
        /*
       // Vector3 orbitVector = Camera.main.WorldToScreenPoint(AimData.pivot.position);
        //Vector3 orbitVector = Camera.main.WorldToScreenPoint(AimData.pivot.position);

        //orbitVector = Input.mousePosition - orbitVector;
        
        //var vec = pointer.position - AimData.pivot.position;
       // Vector3 pointerPos = Camera.main.WorldToViewportPoint(pointer.anchoredPosition.position);
       //var vec =  - AimData.pivot.position;
            
       //AimData.pivot.position = pointer.position - AimData.pivot.position;

       //angle = Mathf.Atan2(-orbitVector.y, -orbitVector.x) * Mathf.Rad2Deg;
       */
        
       //Vector3 pointerWorldPos = Camera.main.ScreenToWorldPoint(pointer.position);
        //var vec = pointerWorldPos - AimData.pivot.position;
        
        //var vec = pointerWorldPos - pivot.position;
        
        var vec = pointerObj.transform.position - AimData.pivot.position;
        angle = Mathf.Atan2(-vec.y, -vec.x) * Mathf.Rad2Deg;
            
        AimData.pivot.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        
        //pivot.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        //PlayerClass.gunAngle = angle;
    }
    
    
    /*
    private void MovePointer()
    {
       // var vec = inputVec * (sensitivity * Time.deltaTime);
       //vec -= (Vector2)gameObject.transform.position;
       var canvas = pointer.GetComponentInParent<Canvas>();
       var recCanvas = canvas.GetComponent<RectTransform>();
       
       lastPos = currentPos;
       currentPos = transform.position;
       Vector2 deltaPos = currentPos - lastPos;
       var canvasOffset = new Vector2(deltaPos.x, deltaPos.y);
       
       var vec = pointer.anchoredPosition + canvasOffset +(Vector2)inputVec * (sensitivity * Time.deltaTime);
       
       vec.x = Mathf.Clamp(vec.x,-recCanvas.sizeDelta.x /2 ,recCanvas.sizeDelta.x /2);
       vec.y = Mathf.Clamp(vec.y,-recCanvas.sizeDelta.y /2 ,recCanvas.sizeDelta.y /2);
       
       pointer.anchoredPosition = vec;
    }
*/
    private void MovePointerTwo()
    {
        var cam = Camera.main;
        var camBottom = cam.ViewportToWorldPoint(new Vector3(0, 0,cam.nearClipPlane));
        var camTop = cam.ViewportToWorldPoint(new Vector3(1, 1,cam.nearClipPlane));
        
        var vec = pointerObj.transform.position + inputVec * (sensitivity * Time.deltaTime);
        vec.x = Mathf.Clamp(vec.x, camBottom.x, camTop.x);
        vec.y = Mathf.Clamp(vec.y, camBottom.y, camTop.y);
        pointerObj.transform.position = vec;
        
    }

}


