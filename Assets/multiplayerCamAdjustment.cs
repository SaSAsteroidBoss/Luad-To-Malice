using System;
using Cinemachine;
using UnityEngine;

public class multiplayerCamAdjustment : MonoBehaviour
{
   private CinemachineVirtualCamera cam;

   
   private CinemachineTargetGroup targetGroup;

   private void Awake()
   {
      cam = GetComponent<CinemachineVirtualCamera>();
      targetGroup = GetComponent<CinemachineTargetGroup>();
   }

   void Start()
   {
     
      
      //targetGroup.AddMember(player1, 1f,0f);
      //targetGroup.AddMember(player2, 1f,0f);
      
      //cam.Follow = targetGroup.transform;
   }
   
   
   public void setTargetGroup(GameObject[] targets)
   {
      for (int i = 0; i < targets.Length; i++)
      { 
         if(targets[i] != null)
            targetGroup.AddMember(targets[i].transform, 1f ,4f);
      }
    
      
      cam.Follow = targetGroup.transform;
   }
}
