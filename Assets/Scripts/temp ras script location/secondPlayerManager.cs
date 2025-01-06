using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class SecondPlayerManager : MonoBehaviour
{
  PlayerInputManager inputManager;

  
  private List<PlayerInput> players = new List<PlayerInput>();
  
  [SerializeField] private GameObject player;
  
  [SerializeField] private GameObject cam;

  private GameObject[] newPlayer = new GameObject[2];
  
  private List<Transform> spawnPoints = new List<Transform>();
  
  
  [SerializeField] private GameObject Menu;
  private void Awake()
  {
    Menu.SetActive(false);
    foreach (Transform child in transform)
    {
      spawnPoints.Add(child);
    }

    inputManager = GetComponent<PlayerInputManager>();
    
    var inputOne = player.GetComponent<PlayerInput>();
    
    foreach (var device in InputSystem.devices)
    {
      if (device is Gamepad ) // Comment out the keyboard part, its only there for bug testing the multiplayer 
      {
        AddPlayer(device);
      }
    }
  
  }

  
  private void Update()
  {
    if(newPlayer[0] == null && newPlayer[1] == null)
    {
      Menu.SetActive(true);
    }
  }

  private void Start()
  {
    cam.GetComponent<multiplayerCamAdjustment>().setTargetGroup(newPlayer);
  }

  private void AddPlayer(InputDevice device)
  {
    
    print("player added");

    
    if (players.Count < 2)// current foreseeable bug, the spawn locations are directly linked to the player count
    {
      newPlayer[players.Count] = Instantiate(player, spawnPoints[players.Count].position,  spawnPoints[players.Count].rotation);
      //newPlayer.GetComponent<setCamera>().cam = virtualCamera;
      
      
      switch (players.Count)
      { 
        case 0 : newPlayer[players.Count].name = "player 1"; 
          
          var spriteRends = newPlayer[players.Count].GetComponentsInChildren<SpriteRenderer>();
          foreach (var sprite in spriteRends)
          {
            if (sprite.gameObject.name == "Circle")
            {
              sprite.color = Color.cyan;
            }
            else if (sprite.gameObject.name == "pointer")
            {
              sprite.color = Color.cyan;
            }
            
          }
          break;
        
        case 1: newPlayer[players.Count].name = "player 2"; 
          var spriteRends2 = newPlayer[players.Count].GetComponentsInChildren<SpriteRenderer>();
          foreach (var sprite in spriteRends2)
          {
            if (sprite.gameObject.name == "Circle")
            {
              sprite.color = Color.magenta;
            }
            else if (sprite.gameObject.name == "pointer")
            {
              sprite.color = Color.magenta;
            }
            
          }
          break;
      }
      PlayerInput playerInput = newPlayer[players.Count].GetComponent<PlayerInput>();

 
      players.Add(playerInput);
    }
    
    //virtualCamera.gameObject.GetComponent<multiplayerCamAdjustment>().setTargetGroup(newPlayer[1].transform, newPlayer[2].transform);
    //cam.GetComponent<multiplayerCamAdjustment>().setTargetGroup(newPlayer[0].transform ,newPlayer[1].transform);

  }
}
