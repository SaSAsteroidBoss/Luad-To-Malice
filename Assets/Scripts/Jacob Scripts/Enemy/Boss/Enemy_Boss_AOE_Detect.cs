using System.Collections.Generic;
using UnityEngine;

public class Enemy_Boss_AOE_Detect : MonoBehaviour
{

    public List<GameObject> playersVulnurable = new List<GameObject>(); 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playersVulnurable.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playersVulnurable.Remove(collision.gameObject);
        }
    }
}
