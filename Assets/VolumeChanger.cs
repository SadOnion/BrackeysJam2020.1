using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour
{
    public Slider slider;
    public void UpdateVolume()
    {
        AudioManager.instance.ChangeVolume(slider.value);
    }
}
