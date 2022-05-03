using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private AudioMixer _volumeMixer;
    [SerializeField] private AudioMixer _musicMixer;
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private Slider _musicSlider;

    private void Awake()
    {
        _volumeSlider.value = PlayerPrefs.GetFloat("Volume", -10);
        _musicSlider.value = PlayerPrefs.GetFloat("Music", -10);
    }

    public void SetVolume(float volume)
    {
        _volumeMixer.SetFloat("Volume", volume);
    }

    public void SetMusic(float music)
    {
        _musicMixer.SetFloat("Volume", music);
    }

    public void Close()
    {
        _panel.SetActive(false);
        SaveOnClose();
    }

    public void Open()
    {
        _panel.SetActive(true);
    }

    public void SaveOnClose()
    {
        PlayerPrefs.SetFloat("Volume", _volumeSlider.value);
        PlayerPrefs.SetFloat("Music", _musicSlider.value);
    }
}