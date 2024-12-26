using UnityEngine;
using UnityEngine.Events;


public class TempHealth : MonoBehaviour
{
    private Stats _stats;
    
    public UnityAction<float> UpdateHp;
    
    private void Start()
    {
        _stats = GetComponent<Stats>();
    }
    
    public void TakeDamage(float damage)
    {
        
    }
}
