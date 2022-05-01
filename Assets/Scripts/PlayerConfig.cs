using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "ScriptableObject/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    [SerializeField] private float _speedOnGround;
    [SerializeField] private float _speedInAir;
    [SerializeField] private Vector2 _gravity;

    public float SpeedOnGround => _speedOnGround;
    public float SpeedInAir => _speedInAir;
    public Vector2 Gravity => _gravity;
}
