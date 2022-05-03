using UnityEngine;

public sealed class WinCondition : MonoBehaviour
{
    [SerializeField] private Door _door;
    [SerializeField] private SceneLoader _loader;
    [SerializeField] private Counter _counter;

    bool _isWin;

    private void OnEnable()
    {
        _door.Victory += OnVictory;
    }

    private void OnDisable()
    {
        _door.Victory -= OnVictory;
    }

    private void OnVictory()
    {
        if (_isWin == false)
        {
            _counter.enabled = false;
            _loader.LoadNextLevel();
        }
    }
}
