using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "ScriptableObject/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    [Header("Landing Settings")]
    [SerializeField] private float _speedOnGround;
    [Header("In Air Settings")]
    [SerializeField] private float _speedInAir;
    [SerializeField] private float _risingForce;
    [SerializeField] private Vector2 _gravity;

    public float SpeedOnGround => _speedOnGround;
    public float SpeedInAir => _speedInAir;

    public float RisingForce => _risingForce;
    public Vector2 Gravity => _gravity;
}
