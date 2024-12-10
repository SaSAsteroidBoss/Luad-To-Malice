using UnityEngine;

public class playerPause : MonoBehaviour
{
   private pauseMenu menu;
   void Start()
   {
      var menuVar = FindFirstObjectByType<pauseMenu>(); // replaced findObjectsOfType
     menu = menuVar;
   }
   void OnPause()
   {
      menu.setMenu();
   }
}
