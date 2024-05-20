using UnityEngine;
using UnityEngine.Audio;

public class AudioPanel : MonoBehaviour
{
    private const string BackgroundVolume = "BackgroundVolume";
    private const string MasterVolume = "MasterVolume";
    private const string SoundVolume = "SoundVolume";

    [SerializeField] private AudioMixer _mixer;

    private bool _isSoundOn = true;

    public void ToggleSound()
    {
        int minValue = -80;
        int maxValue = 0;
        int value = _isSoundOn == true ? minValue : maxValue;

        ChangeVolume(MasterVolume, value);

        _isSoundOn = !_isSoundOn;
    }

    public void ChangeMasterVolume(float value)
    {
        ChangeVolume(MasterVolume, value);
    }

    public void ChangeBackgroundVolume(float value)
    {
        ChangeVolume(BackgroundVolume, value);
    }

    public void ChangeSoundVolume(float value)
    {
        ChangeVolume(SoundVolume, value);
    }

    private void ChangeVolume(string parameterName, float value)
    {
        int _volumeScalingFactor = 20;

        _mixer.SetFloat(parameterName, Mathf.Log10(value) * _volumeScalingFactor);
    }
}
