using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "ZombieStats", menuName = "MyScriptableObjects/ZombieStats", order = 1)]

public class ZombieSO : ScriptableObject
{
    [field: Header("Zombie Base Stats")]
    [field: SerializeField]
    public float _speed { get; private set; } = 25f;
    [field: SerializeField] public int _maxHealth { get; private set; } = 3;
    [field: SerializeField] public int _maxCoin { get; private set; } = 3;


}
