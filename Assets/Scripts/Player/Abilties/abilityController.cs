using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class abilityController : MonoBehaviour
{

    [Header("Ability One")]
    [Tooltip("Asign a scriptable Object")]
    [SerializeField] private SO_abilities dataOne;

    [Header("Ability Two")]
    [Tooltip("Asign a scriptable Object")]
    [SerializeField] private SO_abilities dataTwo;

    [SerializeField] private GameObject waveCol;

    [ReadOnly(true)]
    private float offsetY;
    //private Dictionary<int, GameObject> wave = new Dictionary<int, GameObject>();


    private bool abilityOneCanRun = true;
    private bool abilityTwoCanRun = true;
    [Header("Debugging")]
    [SerializeField] private bool ViewAbilityOne = false;
    [SerializeField] private bool ViewAbilityTwo = false;



    private void Start()
    {
        waveCol.SetActive(false);
        if (dataOne == null)
        {
            Debug.LogError("AbilityDataOne is Null. View abilityController.cs on player to Debug");
            GetComponent<abilityController>().enabled = false;
        }

        if (dataTwo == null)
        {
            Debug.LogError("AbilityDataTwo is Null. View abilityController.cs on player to Debug");
            //GetComponent<abilityController>().enabled = false;
        }
    }
    void OnCastOne()
    {
        if (abilityOneCanRun)
        {
            switch (dataOne.abilityType)
            {
                case abilityType.Wave:
                    

                    StartCoroutine(waveCorutine(dataOne.abilityElement, dataOne.waveAttackWidth, dataOne.waveAttackCount, dataOne.waveRadius, dataOne.wavePrefab, dataOne.waveDuration, dataOne.waveCoolDown, dataOne.wavePrefabSize, dataOne.waveCount,dataOne.waveParticleEffect, 1));
                    break;

                case abilityType.SingeShot:
                    StartCoroutine(singleShotCorutine(dataOne.singleShotPrefab, dataOne.singleShotSpeed, dataOne.singleShotCoolDown, dataOne.singleShotParticalEffect, 1));
                    break;

                case abilityType.AoeSplash:
                    StartCoroutine(splashCoroutine(dataOne.splashPrefab, dataOne.splashSpeed, dataOne.splashCoolDown, dataOne.splashCurve,dataOne.splashParticalEffect, 1));
                    break;

            }
        }
    }

    void OnCastTwo()
    {
        if (abilityTwoCanRun)
        {
            switch (dataTwo.abilityType)
            {
                case abilityType.Wave:
                    StartCoroutine(waveCorutine(dataTwo.abilityElement, dataTwo.waveAttackWidth, dataTwo.waveAttackCount, dataTwo.waveRadius, dataTwo.wavePrefab, dataTwo.waveDuration, dataTwo.waveCoolDown, dataTwo.wavePrefabSize, dataTwo.waveCount, dataTwo.waveParticleEffect, 0));
                    break;

                case abilityType.SingeShot:
                    StartCoroutine(singleShotCorutine(dataTwo.singleShotPrefab, dataTwo.singleShotSpeed, dataTwo.singleShotCoolDown, dataTwo.singleShotParticalEffect, 0));
                    break;

                case abilityType.AoeSplash:
                    StartCoroutine(splashCoroutine(dataTwo.splashPrefab, dataTwo.splashSpeed, dataTwo.splashCoolDown, dataTwo.splashCurve, dataTwo.splashParticalEffect, 0));
                    break;
            }
        }
    }

    //____Wave Type
    #region 
 
    //Using the unit circle I calculate the min and max for a section of the circle in the direction of the gun.
    //I use the change in the radius to instance the objects out like a wave. 
    private IEnumerator waveCorutine(abilityElement element, int width, int count, float radius, GameObject prefrab, float duration, float cooldown, float scale, float waveCount, GameObject ps,int oneOrTwo)
    {

        if(oneOrTwo == 1) 
        {
            abilityOneCanRun = false;
        }
        else
        {
            abilityTwoCanRun = false;
        }
        Transform prevParent = waveCol.transform.parent;
        waveCol.transform.parent = null;
        waveCol.SetActive(true);
        var prefabList = new List<GameObject>();
        Vector3 playerPos = transform.position;
        float angleY = transform.eulerAngles.y;
        float tempGunAngle = playerClass.gunAngle;
        float elapsedTime = 0;
        float maxRadius = radius;
        float psDuration = ps.GetComponent<ParticleSystem>().main.duration;
        int currentGap = 1;


        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;

            radius = Mathf.Lerp(1, maxRadius, t);

            //float gapTime = (currentGap * (scale * 0.9f)) * duration / waveCount;
            float gapTime = currentGap  *  duration/ waveCount;

            if (elapsedTime >= gapTime)
            {

                for (int i = 0; i < count; i++)
                {

                    Vector3 pos = calPos(i, width, count, radius, playerPos, tempGunAngle);
                    waveCol.transform.position = calPos(1, 1, count, radius, playerPos, tempGunAngle);
                    //float colAngle = Mathf.DeltaAngle(1 + calAngle(1, 1, count, tempGunAngle), angleY);
                    //waveCol.transform.rotation = Quaternion.Euler(0, 0, colAngle);
                    float angle = Mathf.DeltaAngle(i + calAngle(i, width, count, tempGunAngle), angleY);

                    Quaternion direction = Quaternion.Euler(0f, 0f, -angle);

                    GameObject iceBlock = Instantiate(prefrab, pos, direction);

                    iceBlock.transform.localScale = Vector3.one * radius * (-scale / 3);

                    prefabList.Add(iceBlock);

                }
                currentGap++;
            }
            
        
           
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(1);

        foreach (GameObject iceBlock in prefabList)
        {
            GameObject PS = Instantiate(ps, iceBlock.transform.position, iceBlock.transform.rotation);
            StartCoroutine(destroyPS(PS, psDuration));

        }
            yield return new WaitForSeconds(0.1f);

        foreach (GameObject iceBlock in prefabList)
        {

            Destroy(iceBlock);
        }

        // this was quick I know its really unreadable 
        // this just switches off and on the collider 
        waveCol.SetActive(false);
        waveCol.GetComponent<BoxCollider2D>().size = new Vector2(waveCol.GetComponent<BoxCollider2D>().size.x, 5);
        waveCol.transform.position = calPos(1, 1, count, radius/2, playerPos, tempGunAngle);
        waveCol.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        waveCol.SetActive(false);
        waveCol.GetComponent<BoxCollider2D>().size = new Vector2(waveCol.GetComponent<BoxCollider2D>().size.x, 1);
        waveCol.transform.position = gameObject.transform.position;
        waveCol.transform.SetParent(prevParent);
        waveCol.transform.localRotation = Quaternion.identity;
        yield return new WaitForSeconds(duration);

       
       
        radius = maxRadius;

        if (oneOrTwo == 1)
        {
            abilityOneCanRun = true;
        }
        else
        {
            abilityTwoCanRun = true;
        }
    }
    IEnumerator destroyPS(GameObject ps, float duration)
    {

        yield return new WaitForSeconds(duration + 1f);
        Destroy(ps);

    }
    IEnumerator destroyWave(List<GameObject> prefabList)
    {
        
        foreach (GameObject iceBlock in prefabList)
        {
            Destroy(iceBlock);
        }
        yield return new WaitForSeconds(0.1f);
    }

    // this is where the calculation is made from the unit circle
    Vector3 calPos(int index, int width, int count, float radius, Vector3 playerPos, float gunAngle)
    {

        float angle = calAngle(index, width, count, gunAngle);
        float angleRad = Mathf.Deg2Rad * angle; // angle = rotate pos

        float x = Mathf.Cos(angleRad) * radius;
        float y = Mathf.Sin(angleRad) * radius;

        return playerPos + new Vector3(x, y + offsetY, 0);
    }

    // This is where the min and max angle is calculated
    float calAngle(int index, int width, int count, float gunAngle)
    {
        float direction = gunAngle - 180;
        float angle1 = direction + width;
        float angle2 = direction - width;
        float calAng = (angle1 - angle2) / (count - 1);
        return angle1 - (index * calAng);
    }

    #endregion

    //____Single
    #region
    IEnumerator singleShotCorutine(GameObject prefab, float speed, float delay, GameObject ps,int oneOrTwo)
    {
        if (oneOrTwo == 1)
        {
            abilityOneCanRun = false;
        }
        else
        {
            abilityTwoCanRun = false;
        }
        var rot = Quaternion.AngleAxis(playerClass.gunAngle + 90, Vector3.forward);

        Vector3 gunPos =  transform.position + Vector3.forward * playerClass.gunOffSet;
        GameObject obj = Instantiate(prefab, gunPos, rot);

        
        StartCoroutine(singleShotMovement(obj, speed));
        yield return new WaitForSeconds(delay);

        if (oneOrTwo == 1)
        {
            abilityOneCanRun = true;
        }
        else
        {
            abilityTwoCanRun = true;
        }
    }

    IEnumerator singleShotMovement(GameObject prefab, float speed)
    {

        float elapsedTime = 0;
        GameObject obj = prefab;
        while(elapsedTime < 10)
        {
            // local space baby 
            obj.transform.position += speed * Time.deltaTime * obj.transform.up;

            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        
    }
    #endregion

    //____Splash
    #region
    IEnumerator splashCoroutine(GameObject prefab, float speed, float duration, float curve, GameObject ps, int oneOrTwo)
    {
        if (oneOrTwo == 1)
        {
            abilityOneCanRun = false;
        }
        else
        {
            abilityTwoCanRun = false;
        }
        (var p0, var p1, var p2, var p3) = calPointPos(curve);

        float timeElapsed = 0;
        var rot = Quaternion.AngleAxis(playerClass.gunAngle + 90, Vector3.forward);
        Vector3 gunPos = transform.position + Vector3.forward * playerClass.gunOffSet;
        GameObject obj = Instantiate(prefab, gunPos, rot);
        obj.GetComponent<blastCollision>().SetDamageScript(GetComponent<Damage>());
        float distTime = calCurveLength(p0, p1, p2, p3) / speed;
        //print(distTime);
        
        while (timeElapsed < distTime)
        {
            float t = timeElapsed / distTime;

            float lerp = Mathf.Lerp(0, 1, t);
            obj.transform.position = calBezPoint(lerp, p0, p1, p2, p3);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        //Destroy(obj);
        obj.GetComponent<SpriteRenderer>().enabled = false;
        obj.GetComponent<CircleCollider2D>().radius = 4f;
        obj.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        Destroy(obj);
        yield return new WaitForSeconds(duration);

        if (oneOrTwo == 1)
        {
            abilityOneCanRun = true;
        }
        else
        {
            abilityTwoCanRun = true;
        }
    }
    (Vector3 p0, Vector3 p1,Vector3 p2, Vector3 p3) calPointPos(float curve)
    {
        Vector3 p0, p1, p2, p3;
        float offSet;
 
        p0 = transform.position; 
        p3 = Camera.main.ScreenToWorldPoint(Input.mousePosition); 

        p1 = p0 + (p3 - p0) / 4; // higher devision = close to start point 
        p2 = p0 + (p3 - p0) / 1.5f; // 2 is midpoint so 1.5 is half way between 1-2

        offSet = p0.y + (p3.y - p0.y) / curve; // sweet spot for the arc| defualt = 3

        p2.y = offSet;
        p1.y = transform.position.y;

        p0.z = 0;
        p1.z = 0;
        p2.z = 0;
        p3.z = 0;

        return (p0, p1, p2, p3);
    }
   
    Vector3 calBezPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 p = uuu * p0;
        p += 3 * uu * t * p1;
        p += 3 * u * tt * p2;
        p += ttt * p3;

        return p;
    }

    float calCurveLength(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float sampleRes = 20;
        Vector3 lastPoint = Vector3.zero;
        float dist = 0;
        for(int i = 0; i < sampleRes; i++)
        {
            float t = i / (sampleRes - 1);
            Vector3 point = calBezPoint(t, p0, p1, p2, p3);
            dist += (point - lastPoint).magnitude;
            lastPoint = point;  
        }
        return dist;
    }

    float distFromMouseToPlayer()
    {
        Vector3 locPlayer = transform.position;
        Vector3 locMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        return (locPlayer - locMouse).magnitude;
    }
    #endregion
    private void OnDrawGizmos()
    {
        
        if (ViewAbilityOne)
        {
            switch (dataOne.abilityType)
            {
                case abilityType.Wave:
                    for (int i = 0; i < dataOne.waveAttackCount; i++)
                    {
                        Vector3 pos = calPos(i, dataOne.waveAttackWidth, dataOne.waveAttackCount, dataOne.waveRadius, transform.position, playerClass.gunAngle);

                        Gizmos.color = Color.black;
                        Gizmos.DrawLine(gameObject.transform.position, pos);
                        Gizmos.color = Color.yellow;
                        Matrix4x4 prevMatrix = Gizmos.matrix;
                        Gizmos.matrix = Matrix4x4.TRS(pos, Quaternion.Euler(0, 0, i), Vector3.one);
                        //Gizmos.DrawWireCube(Vector3.zero, new Vector3(35, 3, 0));
                        Gizmos.DrawSphere(Vector3.zero, 0.05f * dataOne.waveRadius);
                        Gizmos.matrix = prevMatrix;

                    }

                    break;
                case abilityType.SingeShot:

                    break;

                case abilityType.AoeSplash:

                    Vector3[] v = new Vector3[4];
                    (v[0], v[1], v[2], v[3]) = calPointPos(dataOne.splashCurve);


                    for (int i = 0; i < v.Length; i++)
                    {
                        switch (i)
                        {
                            case 0: Gizmos.color = Color.yellow; break;
                            case 1: Gizmos.color = Color.green; break;
                            case 2: Gizmos.color = Color.red; break;
                            case 3: Gizmos.color = Color.cyan; break;
                        }

                        Matrix4x4 mat = Gizmos.matrix;
                        Gizmos.matrix = Matrix4x4.TRS(v[i], Quaternion.identity, Vector3.one);
                        Gizmos.DrawSphere(Vector3.zero, 0.2f);
                        Gizmos.matrix = mat;
                    }
                    Gizmos.color = Color.white;
                    
                    float curveRes = distFromMouseToPlayer() * 2;

                    for ( int i = 0; i < curveRes; i++)
                    {
                        Vector3 pos;
                        float t = i / (curveRes - 1);
                        pos = calBezPoint(t,v[0], v[1], v[2], v[3]);

                        Matrix4x4 mat = Gizmos.matrix;
                        Gizmos.matrix = Matrix4x4.TRS(pos, Quaternion.identity, Vector3.one);
                        Gizmos.DrawSphere(Vector3.zero, 0.1f);
                        Gizmos.matrix = mat;
                    }
                    break;
            }
        }

        if (ViewAbilityTwo)
        {
            switch (dataTwo.abilityType)
            {
                case abilityType.Wave:
                    for (int i = 0; i < dataTwo.waveAttackCount; i++)
                    {
                        Vector3 pos = calPos(i, dataTwo.waveAttackWidth, dataTwo.waveAttackCount, dataTwo.waveRadius, transform.position, playerClass.gunAngle);

                        Gizmos.color = Color.black;
                        Gizmos.DrawLine(gameObject.transform.position, pos);
                        Gizmos.color = Color.yellow;
                        Matrix4x4 prevMatrix = Gizmos.matrix;
                        Gizmos.matrix = Matrix4x4.TRS(pos, Quaternion.Euler(0, 0, i), Vector3.one);
                        //Gizmos.DrawWireCube(Vector3.zero, new Vector3(35, 3, 0));
                        Gizmos.DrawSphere(Vector3.zero, 0.05f * dataTwo.waveRadius);
                        Gizmos.matrix = prevMatrix;

                    }
                    break;

                case abilityType.SingeShot:
                    break;

                case abilityType.AoeSplash:
                    Vector3[] v = new Vector3[4];
                    (v[0], v[1], v[2], v[3]) = calPointPos(dataTwo.splashCurve);


                    for (int i = 0; i < v.Length; i++)
                    {
                        switch (i)
                        {
                            case 0: Gizmos.color = Color.yellow; break;
                            case 1: Gizmos.color = Color.green; break;
                            case 2: Gizmos.color = Color.red; break;
                            case 3: Gizmos.color = Color.cyan; break;
                        }

                        Matrix4x4 mat = Gizmos.matrix;
                        Gizmos.matrix = Matrix4x4.TRS(v[i], Quaternion.identity, Vector3.one);
                        Gizmos.DrawSphere(Vector3.zero, 0.2f);
                        Gizmos.matrix = mat;
                    }
                    Gizmos.color = Color.white;

                    float curveRes = distFromMouseToPlayer() * 2;

                    for (int i = 0; i < curveRes; i++)
                    {
                        Vector3 pos;
                        float t = i / (curveRes - 1);
                        pos = calBezPoint(t, v[0], v[1], v[2], v[3]);

                        Matrix4x4 mat = Gizmos.matrix;
                        Gizmos.matrix = Matrix4x4.TRS(pos, Quaternion.identity, Vector3.one);
                        Gizmos.DrawSphere(Vector3.zero, 0.1f);
                        Gizmos.matrix = mat;
                    }
                    break;
            }
        }
    }
}


