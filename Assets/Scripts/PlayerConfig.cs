using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "ScriptableObject/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    [SerializeField] private float _speedOnGround;
    [SerializeField] private float _speedInAir;

    public float SpeedOnGround => _speedOnGround;
    public float SpeedInAir => _speedInAir;
}
