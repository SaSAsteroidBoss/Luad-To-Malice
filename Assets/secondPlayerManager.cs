using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;

public class SecondPlayerManager : MonoBehaviour
{
  PlayerInputManager inputManager;

  
  private List<PlayerInput> players = new List<PlayerInput>();
  [SerializeField] private GameObject player;


  private List<Transform> spawnPoints = new List<Transform>();

  private void Start()
  {
    foreach (Transform child in transform)
    {
      spawnPoints.Add(child);
    }
    
    inputManager = GetComponent<PlayerInputManager>();
    
    var inputOne = player.GetComponent<PlayerInput>();
    
    //Instantiate(inputOne,spawnPoints[0].position, spawnPoints[0].rotation);
    //Instantiate(inputTwo, spawnPoints[1].position, spawnPoints[1].rotation);

    foreach (var device in InputSystem.devices)
    {
      if (device is Gamepad || device is Keyboard)
      {
        AddPlayer(inputOne);
      }
    }
    
  }


  private void AddPlayer(PlayerInput playerInput)
  {
    
    print("player added");

    if (players.Count < 2)
    {
      Instantiate(playerInput, spawnPoints[players.Count].position, spawnPoints[players.Count].rotation);
      players.Add(playerInput);
    }
   

  }
}
