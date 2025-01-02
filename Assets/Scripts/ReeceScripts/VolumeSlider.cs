using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public AudioMixerGroup masterMixer, musicMixer, sfxMixer, ambientMixer;
    //public AudioMixer audioMixer;
    public Slider masterVolumeSlider, musicVolumeSlider, sfxVolumeSlider, ambientVolumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        /*
        masterVolumeSlider.value = masterMixer.audioMixer.GetFloat("MasterVolume", out var masterVolume) ? masterVolume : 0;
        musicVolumeSlider.value = musicMixer.audioMixer.GetFloat("MusicVolume", out var musicVolume) ? musicVolume : 0;
        sfxVolumeSlider.value = sfxMixer.audioMixer.GetFloat("SFXVolume", out var sfxVolume) ? sfxVolume : 0;
        ambientVolumeSlider.value = ambientMixer.audioMixer.GetFloat("AmbientVolume", out var ambientVolume) ? ambientVolume : 0;
        */
    }

    public void SetMasterVolume()
    {
        masterMixer.audioMixer.SetFloat("MasterVolume", Mathf.Log10(masterVolumeSlider.value) * 20);
    }

    public void SetMusicVolume()
    {
        musicMixer.audioMixer.SetFloat("MusicVolume", Mathf.Log10(musicVolumeSlider.value) * 20);
    }

    public void SetSFXVolume()
    {
        sfxMixer.audioMixer.SetFloat("SFXVolume", Mathf.Log10(sfxVolumeSlider.value) * 20);
    }

    public void SetAmbientVolume()
    {
        ambientMixer.audioMixer.SetFloat("AmbientVolume", Mathf.Log10(ambientVolumeSlider.value) * 20);
    }
}
