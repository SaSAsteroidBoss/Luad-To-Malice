using UnityEngine;
using UnityEngine.InputSystem;

public class TwinStickControls : MonoBehaviour
{
    
    private CharacterController _controller;

    private Vector2 _moveInput;
    
    public float speed;
    
    ItemInventory _inventory;
    
    public Item _item;
    
   private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _inventory = GetComponent<ItemInventory>();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

  
    // ReSharper disable Unity.PerformanceAnalysis
    
    public void AddItemToInventory()
   {
       Debug.Log("Add Item To Inventory");
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

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Pick Up")) return;
       
        _inventory.AddItem(other.GetComponent<Pickup>().heldItem);
        Destroy(other.gameObject);
        Debug.Log("Add Item To Inventory");
    }
}

