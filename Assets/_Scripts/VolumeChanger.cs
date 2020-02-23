using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour
{
    public Slider slider;
    private void Start()
    {
        slider.value = AudioManager.instance.volu;
    }
    public void UpdateVolume()
    {
        AudioManager.instance.ChangeVolume(slider.value);
    }
}
