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


public sealed class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private SceneLoader _sceneLoader;

    public void ChangeActivity()
    {
        if (Time.timeScale == 1)
            Open();
        else
            Close();
    }

    public void GoToMain()
    {
        Close();
        //ToDo: Change Main menu index here
        _sceneLoader.LoadScene(0);
    }

    private void Close()
    {
        _menuPanel.SetActive(false);
        Time.timeScale = 1;
    }

    private void Open()
    {
        _menuPanel.SetActive(true);
        Time.timeScale = 0;
    }
}