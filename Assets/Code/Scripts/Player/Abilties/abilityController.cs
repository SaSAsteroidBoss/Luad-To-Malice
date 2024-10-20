using System.Collections.Generic;
using UnityEngine;


public class abilityController : MonoBehaviour
{
    
    [Header("Ability One")]
    [Tooltip("Asign a scriptable Object")]
    [SerializeField] private SO_abilities abilityDataOne;

    [Header("Ability Two")]
    [Tooltip("Asign a scriptable Object")]
    [SerializeField] private SO_abilities abilityDataTwo;


    public float rotatePos;
    public float circleRadius;
    public float offsetY;
    private Dictionary<int, GameObject> wave = new Dictionary<int, GameObject>();

    void OnCastOne()
    {
        switch (abilityDataOne.abilityType) 
        {
            case abilityType.Wave:
                waveType(abilityDataOne.abilityElement, abilityDataOne.waveAttackWidth, abilityDataOne.waveAttackCount);
                break;

            case abilityType.SingeShot:
                break;

            case abilityType.AoeSplash: 
                break;
            
        }
    }

    void OnCastTwo() {
        switch (abilityDataTwo.abilityType)
        {
            case abilityType.Wave:
                break;

            case abilityType.SingeShot:
                break;

            case abilityType.AoeSplash:
                break;
        }
    }
    
    private void waveType(abilityElement element, int width, int count)
    {
        for(int i =  0; i < count; i++) 
        {
            Vector3 pos = calPos(i, width, count);
            float angle = Mathf.DeltaAngle(i + calAngle(i, width, count), transform.eulerAngles.y);
        }

    }
    Vector3 calPos(int index, int width, int count)
    {

        float angle = calAngle(index, width, count);
        float angleRad = Mathf.Deg2Rad * angle;// rotatePos

        float x = Mathf.Cos(angleRad) * circleRadius;
        float y = Mathf.Sin(angleRad) * circleRadius;
        return gameObject.transform.position + new Vector3(x, y + offsetY, 0);
    }

    float calAngle(int index, int width, int count)
    {
        float direction = playerClass.gunAngle - 180;
        float angle1 = direction + width;
        float angle2 = direction - width;
        float calAng = (angle1 - angle2) / count;
        return angle1 - (index * calAng);
    }






    private void singleShotType(abilityElement element)
    {

    }

    private void AoeSplashType(abilityElement element)
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for(int i = 0; i < 10;i++) 
        {
            Vector3 pos = calPos(i);

            Matrix4x4 prevMatrix = Gizmos.matrix;
            Gizmos.matrix = Matrix4x4.TRS(pos, Quaternion.Euler(0, 0, i), Vector3.one);
            //Gizmos.DrawWireCube(Vector3.zero, new Vector3(35, 3, 0));
            Gizmos.DrawSphere(Vector3.zero, 0.2f);
            Gizmos.matrix = prevMatrix;
        }
        
    }

}


