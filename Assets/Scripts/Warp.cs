using UnityEngine;

public class Warp : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private SceneLoader _loader;

    private SaveZone _zone;

    private void OnEnable()
    {
        _player.EnterInSaveZone += OnEnterInSaveZone;
        _player.Warped += OnWarped;
    }

    private void OnDisable()
    {
        _player.EnterInSaveZone -= OnEnterInSaveZone;
        _player.Warped -= OnWarped;
    }

    private void OnWarped()
    {
        if (_zone == null)
        {
            _loader.Restart();
            return;
        }

        _player.transform.position = _zone.transform.position;
    }

    //private void OnExitFromSaveZone()
    //{
    //    //throw new System.NotImplementedException();
    //}

    private void OnEnterInSaveZone(SaveZone saveZone)
    {
        _zone = saveZone;
    }
}
