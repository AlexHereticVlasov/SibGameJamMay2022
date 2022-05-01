using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    [SerializeField] private Player _player;

    private SaveZone _zone;

    private void OnEnable()
    {
        _player.EnterInSaveZone += OnEnterInSaveZone;
        _player.ExitFromSaveZone += OnExitFromSaveZone;
        _player.Warped += OnWarped;
    }

    private void OnWarped()
    {
        _player.transform.position = _zone.transform.position;
    }

    private void OnExitFromSaveZone()
    {
        //throw new System.NotImplementedException();
    }

    private void OnEnterInSaveZone(SaveZone saveZone)
    {
        _zone = saveZone;
    }
}
