using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SecondPlayerManager : MonoBehaviour
{
  PlayerInputManager inputManager;

  private List<PlayerInput> players = new List<PlayerInput>();
  [SerializeField]
  private GameObject playerOne, playerTwo;

  private List<Transform> spawnPoints = new List<Transform>();

  private void Start()
  {
    foreach (Transform child in transform)
    {
      spawnPoints.Add(child);
    }
    
    inputManager = GetComponent<PlayerInputManager>();
    PlayerInput inputOne = playerOne.GetComponent<PlayerInput>();
    PlayerInput inputTwo = playerTwo.GetComponent<PlayerInput>();
    PlayerInput playerOneInput = PlayerInput.Instantiate(inputOne,spawnPoints[0].position, spawnPoints[0].rotation);
    PlayerInput playerTwoInput = PlayerInput.Instantiate(inputTwo, spawnPoints[1].position, spawnPoints[1].rotation);

    AddPlayer(inputOne);
    AddPlayer(inputTwo);
    
  }


  void AddPlayer(PlayerInput player)
  {
    print("player added");
    if(players.Count < 2)
      players.Add(player);
  }
}
