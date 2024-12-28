using UnityEngine;
using UnityEngine.Events;

public class EnemyArmour : MonoBehaviour, IArmour
{
    private Stats _stats;

    private ItemInventory inventory;

    public UnityAction OnArmour;
   
    public void Start()
    {
        _stats = GetComponent<Stats>();
        
        OnArmour += HandleArmour;
    } 
    
    public void HandleArmour()
    {
        _stats.OnIncreaseArmour?.Invoke(1);
    }
}
