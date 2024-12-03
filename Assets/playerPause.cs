using UnityEngine;

public class playerPause : MonoBehaviour
{
   private pauseMenu menu;
   void Start()
   {
      var menuVar = FindObjectOfType<pauseMenu>();
     menu = menuVar;
   }
   void OnPause()
   {
      menu.setMenu();
   }
}
