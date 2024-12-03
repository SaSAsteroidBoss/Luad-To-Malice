using UnityEngine;

public class pauseMenu : MonoBehaviour
{
   [SerializeField]
   private GameObject menu;


   public void setMenu()
   {
      if(menu.activeInHierarchy)
         menu.SetActive(false);
      else
         menu.SetActive(true);
      
   }
   
}
