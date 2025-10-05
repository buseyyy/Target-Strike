using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sounds : MonoBehaviour
{
    [SerializeField] Slider slider;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        audioSource.volume = slider.value;
    }

    public void MusicVolume()
    {
        float vol = slider.value;
    }
}
