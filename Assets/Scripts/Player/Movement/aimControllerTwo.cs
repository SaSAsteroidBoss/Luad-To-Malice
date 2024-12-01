using System;
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
    
    //private float radius;
    //private Transform orb;
    //private Transform pivot;
    
    private bool canRun = false;
    [HideInInspector]
    public float angle, offset;
    //private Transform pointer;
    private Vector3 inputVec;

    [SerializeField]
    public RectTransform pointer;
    [SerializeField]
    private float sensitivity;
    
 
    
    private void awake()
    {
        AimData.radius = 0.5f;
        Transform[] children = transform.GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            if (child.name == "Gun")
            {
                AimData.orb = child;
                AimData.pivot = child.parent;
                AimData.orb.position += Vector3.up * AimData.radius;
                canRun = true;
                PlayerClass.gunOffSet = AimData.radius;
                offset = AimData.radius;
            } 
            

            var can = FindFirstObjectByType<Canvas>();
            RectTransform[] recTran = can.GetComponentsInChildren<RectTransform>();
            foreach (RectTransform p in recTran)
            {
                if (p.name == "P1 Pointer")
                {
                    pointer = p;    
                }
                else if (p.name == "P2 Pointer")
                {
                    pointer = p;
                }
            }
        }
        if (canRun == false)
        {
            Debug.LogWarning("Could not find child object named Gun for AimControllerTwo.cs please Check Script Descripton for correct setup ");
        }
    }

    private void Awake()
    {
        AimData.radius = 0.5f;
       // radius = 0.5f;
        
    }

    void Start()
    {
        initAimData();
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
              
                //orb = child;
                //pivot = child.parent;
                //orb.position += Vector3.up * radius;
                
                canRun = true;
                //playerClass.gunOffSet = AimData.radius;
                offset = AimData.radius;
                //offset = radius;
            } 
            
            var can = FindFirstObjectByType<Canvas>();
            RectTransform[] recTran = can.GetComponentsInChildren<RectTransform>();
            foreach (RectTransform p in recTran)
            {
                //print(gameObject.name + " : " + p.name);
                if (p.name == "P1 Pointer" && gameObject.name == "player 1")
                {
                    //print("P1 Pointer");
                    pointer = p;    
                }
                else if (p.name == "P2 Pointer" && gameObject.name == "player 2")
                {
                   // print("P2 Pointer");
                    pointer = p;
                }
                
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
    
    private void start()
    {
        AimData.radius = 0.5f;
        Transform[] children = transform.GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            if (child.name == "Gun")
            {
                AimData.orb = child;
                AimData.pivot = child.parent;
                AimData.orb.position += Vector3.up * AimData.radius;
                canRun = true;
                PlayerClass.gunOffSet = AimData.radius;
                offset = AimData.radius;
            } 
            
            var can = FindFirstObjectByType<Canvas>();
            RectTransform[] recTran = can.GetComponentsInChildren<RectTransform>();
            foreach (RectTransform p in recTran)
            {
                if (p.name == "P1 Pointer")
                {
                    pointer = p;    
                }
                else if (p.name == "P2 Pointer")
                {
                    pointer = p;
                }
            }
        }
        if (canRun == false)
        {
            Debug.LogWarning("Could not find child object named Gun for AimControllerTwo.cs please Check Script Descripton for correct setup ");
        }
        
        
        /*
        AimData.radius = 0.5f;
        Transform[] children = transform.GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            if (child.name == "Gun")
            {
                AimData.orb = child;
                AimData.pivot = child.parent;
                AimData.orb.position += Vector3.up * AimData.radius;
                canRun = true;
                playerClass.gunOffSet = AimData.radius;
                offset = AimData.radius;
            }
            if( child.name == "pointer")
            {
               
                //pointer = child;

                //var can = FindFirstObjectByType<Canvas>();
                //pointer.parent = can.transform;
                //pointer.position = Vector2.zero;
            }
        }
        if (canRun == false)
        {
            Debug.LogWarning("Could not find child object named Gun for AimControllerTwo.cs please Check Script Descripton for correct setup ");
        }*/
    }

    private void Update()
    {
        if (canRun)
        {
            CalAngle();
            
           MovePointer();   
        }
    }

    private void CalAngle()
    {
       // Vector3 orbitVector = Camera.main.WorldToScreenPoint(AimData.pivot.position);
        //Vector3 orbitVector = Camera.main.WorldToScreenPoint(AimData.pivot.position);

        //orbitVector = Input.mousePosition - orbitVector;
        
        //var vec = pointer.position - AimData.pivot.position;
       // Vector3 pointerPos = Camera.main.WorldToViewportPoint(pointer.anchoredPosition.position);
       //var vec =  - AimData.pivot.position;
            
       //AimData.pivot.position = pointer.position - AimData.pivot.position;

       //angle = Mathf.Atan2(-orbitVector.y, -orbitVector.x) * Mathf.Rad2Deg;
       
        Vector3 pointerWorldPos = Camera.main.ScreenToWorldPoint(pointer.position);
        var vec = pointerWorldPos - AimData.pivot.position;
        //var vec = pointerWorldPos - pivot.position;
       
        angle = Mathf.Atan2(-vec.y, -vec.x) * Mathf.Rad2Deg;
            
        AimData.pivot.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        //pivot.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        PlayerClass.gunAngle = angle;
    }
    
    private void MovePointer()
    {
       // var vec = inputVec * (sensitivity * Time.deltaTime);
        var vec = pointer.anchoredPosition + (Vector2)inputVec * (sensitivity * Time.deltaTime);
        
        var canvas = pointer.GetComponentInParent<Canvas>();
        var recCanvas = canvas.GetComponent<RectTransform>();
        vec.x = Mathf.Clamp(vec.x,-recCanvas.sizeDelta.x /2 ,recCanvas.sizeDelta.x /2);
        vec.y = Mathf.Clamp(vec.y,-recCanvas.sizeDelta.y /2 ,recCanvas.sizeDelta.y /2);
        pointer.anchoredPosition = vec;
    }

    

}


