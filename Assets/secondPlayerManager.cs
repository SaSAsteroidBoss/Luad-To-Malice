using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class secondPlayerManager : MonoBehaviour
{
  PlayerInputManager inputManager;

  List<PlayerInput> players = new List<PlayerInput>();

  private void Start()
  {
    inputManager = GetComponent<PlayerInputManager>();
  }


  void AddPlayer(PlayerInput player)
  {
    players.Add(player);
  }
}
