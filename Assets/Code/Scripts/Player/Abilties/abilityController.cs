using System.Collections;
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


    private float offsetY;
    private Dictionary<int, GameObject> wave = new Dictionary<int, GameObject>();


    private bool abilityOneCanRun = true;
    private bool abilityTwoCanRun = true;
    [Header("Debugging")]
    [SerializeField] private bool ViewAbilityOne = false;
    [SerializeField] private bool ViewAbilityTwo = false;

    private void Start()
    {
        if (abilityDataOne == null)
        {
            Debug.LogError("AbilityDataOne is Null. View abilityController.cs on player to Debug");
            GetComponent<abilityController>().enabled = false;
        }

        if (abilityDataTwo == null)
        {
            Debug.LogError("AbilityDataTwo is Null. View abilityController.cs on player to Debug");
            //GetComponent<abilityController>().enabled = false;
        }
    }
    void OnCastOne()
    {
        if (abilityOneCanRun)
        {
            switch (abilityDataOne.abilityType)
            {
                case abilityType.Wave:
                    //waveType(abilityDataOne.abilityElement, abilityDataOne.waveAttackWidth, abilityDataOne.waveAttackCount, abilityDataOne.waveRadius);

                    StartCoroutine(waveCorutine(abilityDataOne.abilityElement, abilityDataOne.waveAttackWidth, abilityDataOne.waveAttackCount, abilityDataOne.waveRadius, abilityDataOne.wavePrefab, abilityDataOne.waveDuration, abilityDataOne.waveCoolDown, abilityDataOne.wavePrefabSize, abilityDataOne.waveMinGap));
                    break;

                case abilityType.SingeShot:
                    StartCoroutine(singleShotCorutine(abilityDataOne.singleShotPrefab, abilityDataOne.singleShotSpeed, abilityDataOne.singleShotCoolDown));
                    break;

                case abilityType.AoeSplash:
                    break;

            }
        }
    }

    void OnCastTwo()
    {
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

    /* private void waveType(abilityElement element, int width, int count, float radius)
     {
         Transform playerPos = transform;
         Debug.Log("waveType Playing");

         for (int i = 0; i < count; i++)
         {
             Vector3 pos = calPos(i, width, count, radius, playerPos.position);
             float angle = Mathf.DeltaAngle(i + calAngle(i, width, count), transform.eulerAngles.y);
             Quaternion direction = Quaternion.Euler(0f, 0f, -angle);

             //Debug.DrawLine(pos, transform.forward* 10, Color.yellow);
         }


     }*/
    private IEnumerator waveCorutine(abilityElement element, int width, int count, float radius, GameObject prefrab, float duration, float cooldown, float scale, float minGap)
    {
        List<GameObject> prefabList = new List<GameObject>();
        abilityOneCanRun = false;
        Vector3 playerPos = transform.position;
        float angleY = transform.eulerAngles.y;
        float tempGunAngle = playerClass.gunAngle;
        float elapsedTime = 0;
        float maxRadius = radius;
        minGap /= 5;
        float lastGap = 0f;
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            radius = Mathf.Lerp(1, maxRadius, t);

            float tempScale = Vector3.one.magnitude / scale * radius;
            float gap = tempScale * minGap;

            if (radius - lastGap >= gap)
            {
                // different affect 
                //StartCoroutine(destroyWave(prefabList));
                

                for (int i = 0; i < count; i++)
                {

                    Vector3 pos = calPos(i, width, count, radius, playerPos, tempGunAngle);
                    float angle = Mathf.DeltaAngle(i + calAngle(i, width, count, tempGunAngle), angleY);
                    Quaternion direction = Quaternion.Euler(0f, 0f, -angle);
                    GameObject iceBlock = Instantiate(prefrab, pos, direction);
                    iceBlock.transform.localScale = Vector3.one * radius * (-scale / 2);
                    prefabList.Add(iceBlock);

                }

                
                lastGap = radius;
            }
           
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(cooldown);

        foreach (GameObject iceBlock in prefabList)
        {
            Destroy(iceBlock);
        }
        radius = maxRadius;
        abilityOneCanRun = true;
    }
    IEnumerator destroyWave(List<GameObject> prefabList)
    {
        
        foreach (GameObject iceBlock in prefabList)
        {
            Destroy(iceBlock);
        }
        yield return new WaitForSeconds(0.1f);
    }

    Vector3 calPos(int index, int width, int count, float radius, Vector3 playerPos, float gunAngle)
    {

        float angle = calAngle(index, width, count, gunAngle);
        float angleRad = Mathf.Deg2Rad * angle; // angle = rotate pos

        float x = Mathf.Cos(angleRad) * radius;
        float y = Mathf.Sin(angleRad) * radius;

        return playerPos + new Vector3(x, y + offsetY, 0);
    }

    float calAngle(int index, int width, int count, float gunAngle)
    {
        float direction = gunAngle - 180;
        float angle1 = direction + width;
        float angle2 = direction - width;
        float calAng = (angle1 - angle2) / (count - 1);
        return angle1 - (index * calAng);
    }


    
    IEnumerator singleShotCorutine(GameObject prefab, float speed, float delay)
    {
        abilityOneCanRun = false;
         var rot = Quaternion.AngleAxis(playerClass.gunAngle + 90, Vector3.forward);

        Vector3 gunPos =  transform.position + Vector3.forward * playerClass.gunOffSet;
        GameObject obj = Instantiate(prefab, gunPos, rot);
        yield return new WaitForSeconds(delay);
        abilityOneCanRun = true;
    }

    private void AoeSplashType(abilityElement element)
    {

    }

    private void OnDrawGizmos()
    {
        if (ViewAbilityOne)
        {

            switch (abilityDataOne.abilityType)
            {
                case abilityType.Wave:
                    for (int i = 0; i < abilityDataOne.waveAttackCount; i++)
                    {
                        Vector3 pos = calPos(i, abilityDataOne.waveAttackWidth, abilityDataOne.waveAttackCount, abilityDataOne.waveRadius, transform.position, playerClass.gunAngle);

                        Gizmos.color = Color.black;
                        Gizmos.DrawLine(gameObject.transform.position, pos);
                        Gizmos.color = Color.yellow;
                        Matrix4x4 prevMatrix = Gizmos.matrix;
                        Gizmos.matrix = Matrix4x4.TRS(pos, Quaternion.Euler(0, 0, i), Vector3.one);
                        //Gizmos.DrawWireCube(Vector3.zero, new Vector3(35, 3, 0));
                        Gizmos.DrawSphere(Vector3.zero, 0.05f * abilityDataOne.waveRadius);
                        Gizmos.matrix = prevMatrix;

                    }

                    break;

                case abilityType.SingeShot:
                    break;

                case abilityType.AoeSplash:
                    break;
            }
        }

        if (ViewAbilityTwo)
        {
            switch (abilityDataOne.abilityType)
            {
                case abilityType.Wave:

                    break;

                case abilityType.SingeShot:
                    break;

                case abilityType.AoeSplash:
                    break;
            }
        }
    }

}


