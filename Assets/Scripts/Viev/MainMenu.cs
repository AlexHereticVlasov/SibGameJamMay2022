using UnityEngine;

public sealed class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] _windows;

    //ToDo:Amimate windows
    public void ShowWindow(GameObject windowToShow)
    {
        foreach (var window in _windows)
            window.SetActive(window == windowToShow);
    }

    public void Quit() => Application.Quit();
}

