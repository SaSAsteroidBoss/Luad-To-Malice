using System;
using System.Collections.Generic;
using System.ComponentModel;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class SecondPlayerManager : MonoBehaviour
{
  PlayerInputManager inputManager;

  
  private List<PlayerInput> players = new List<PlayerInput>();
  
  [SerializeField] private GameObject player;

  [SerializeField] private GameObject[] playerPointer;
  
  [SerializeField] private CinemachineVirtualCamera virtualCamera;
  [SerializeField] private GameObject cam;

  private GameObject[] newPlayer = new GameObject[2];
  
  private List<Transform> spawnPoints = new List<Transform>();

  private void Awake()
  {
    foreach (Transform child in transform)
    {
      spawnPoints.Add(child);
    }

    foreach (GameObject pointer in playerPointer)
    {
      pointer.SetActive(false);
    }
    
    inputManager = GetComponent<PlayerInputManager>();
    
    var inputOne = player.GetComponent<PlayerInput>();

    
    foreach (var device in InputSystem.devices)
    {
     
      
      if (device is Gamepad || device is Keyboard)
      {
        AddPlayer(device, newPlayer);
        
      }
    
     
    }
    print(newPlayer);
    
  }

  private void Start()
  {
    cam.GetComponent<multiplayerCamAdjustment>().setTargetGroup(newPlayer);
  }
  private void start()
  {
    
    
    
    
    
    /*
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
      if (device is Gamepad /*|| device is Keyboard*//*)
      {
       AddPlayer(inputOne);
      }

    }
    */
  }


  private void AddPlayer(InputDevice device, GameObject[] newPlayer)
  {
    
    print("player added");

    
    if (players.Count < 2)// current foreseeable bug, the spawn locations are directly linked to the player count
    {
      //Instantiate(playerInput, spawnPoints[players.Count].position, spawnPoints[players.Count].rotation);
      print(players.Count);
      newPlayer[players.Count] = Instantiate(player, spawnPoints[players.Count].position,  spawnPoints[players.Count].rotation);
      //newPlayer.GetComponent<setCamera>().cam = virtualCamera;
      PlayerInput playerInput = newPlayer[players.Count].GetComponent<PlayerInput>();

      playerPointer[players.Count].SetActive(true);
      players.Add(playerInput);
    }
    
    //virtualCamera.gameObject.GetComponent<multiplayerCamAdjustment>().setTargetGroup(newPlayer[1].transform, newPlayer[2].transform);
    //cam.GetComponent<multiplayerCamAdjustment>().setTargetGroup(newPlayer[0].transform ,newPlayer[1].transform);

  }
}
