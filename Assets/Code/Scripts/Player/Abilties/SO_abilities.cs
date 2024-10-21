using UnityEngine;
public enum abilityType { Wave, SingeShot, AoeSplash }
public enum abilityElement { Fire, Frost }
[CreateAssetMenu(fileName = "SO_abilities", menuName = "Scriptable Objects/Create New Ability")]
public class SO_abilities : ScriptableObject
{
    [Header("Design Your Ability")]

    [Tooltip("How the weapon shoots")]
    public abilityType abilityType;

    [Tooltip("The damage type")]
    public abilityElement abilityElement;

    [Range(1, 10)]
    public int damage = 0;

    [Range(1, 20)]
    public int castDelay = 0;

    [Header("Wave type weapon parameters only")]
    [Tooltip("The width angle of the wave")]
    [Range(0, 180)]
    public int waveAttackWidth = 0;

    [Tooltip("The amount of waves within the fire angle")]
    [Range(0, 20)]
    public int waveAttackCount = 0;

    [Tooltip("How far away the ability starts from the player")]
    [Range(0, 10)]
    public float waveRadius = 0;

    public float waveDuration = 0;

    public float waveCoolDown = 0;
    [Range(0, 1)]
    public float wavePrefabSize = 0;
    [Range(0, 1)]
    public float waveMinGap = 0;
    public GameObject wavePrefab;
}

