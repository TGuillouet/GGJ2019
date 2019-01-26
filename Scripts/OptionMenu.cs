using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{

    public Slider mySlider;
    public Toggle myToggle;

    public void Start()
    {
        myToggle.isOn = true;
        mySlider.value = AudioListener.volume = 1;
    }

    public void ToggleClick()
    {
        print("prev vol: " + AudioListener.volume);
        if(!myToggle.isOn)
        {
            mySlider.value = AudioListener.volume = 0;
        }
        print("next vol: " + AudioListener.volume);
    }

    public void SliderSound()
    {
        Debug.Log(mySlider.value);
        AudioListener.volume = mySlider.value;
        if (mySlider.value != 0)
        {
            myToggle.isOn = true;
        }
        else
        {
            myToggle.isOn = false;
        }
    }
}
