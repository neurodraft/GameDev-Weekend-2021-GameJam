using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class volumemixer : MonoBehaviour
{
    public AudioMixer mixer;

    // Update is called once per frame
    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10 (sliderValue) * 20);
    }
}
