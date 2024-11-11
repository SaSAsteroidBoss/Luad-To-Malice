using UnityEngine;

public class bulletForce : MonoBehaviour
{
    private void Start()
    {
        Invoke("Death", 2);
    }
    private void Update()
    {
        transform.position += transform.up * Time.deltaTime;
    }
    private void Death()
    {
        Destroy(gameObject);
    }
}
