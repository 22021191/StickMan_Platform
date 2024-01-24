using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingController : MonoBehaviour
{
    public Slider musicSlider, sfxSlider;
    public Button musicButton,sfxButton;
    public Sprite musicOn,musicOff;
    public Sprite sfxOn,sfxOff;
    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
        if(!AudioManager.Instance.musicSource.mute)
        {
            musicButton.image.overrideSprite=musicOn;
        }
        else
        {
            musicButton.image.overrideSprite= musicOff;
        }
    }
    public void ToggleSfx()
    {
        AudioManager.Instance.ToggleSfx();
        if(!AudioManager.Instance.sfxSource.mute)
        {
            sfxButton.image.overrideSprite = sfxOn;
        }
        else
        {
            sfxButton.image.overrideSprite = sfxOff;
        }
    }
    public void SfxVolume()
    {
        AudioManager.Instance.SfxVolume(sfxSlider.value);
    }
    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(musicSlider.value);
    }
    void OnEnable()
    {
        // Code trong phương thức này sẽ được thực thi mỗi khi đối tượng được kích hoạt.
        musicSlider.value=AudioManager.Instance.musicSource.volume;
        sfxSlider.value = AudioManager.Instance.sfxSource.volume;
        if (!AudioManager.Instance.sfxSource.mute)
        {
            sfxButton.image.overrideSprite = sfxOn;
        }
        else
        {
            sfxButton.image.overrideSprite = sfxOff;
        }
        if (!AudioManager.Instance.musicSource.mute)
        {
            musicButton.image.overrideSprite = musicOn;
        }
        else
        {
            musicButton.image.overrideSprite = musicOff;
        }
    }
}
