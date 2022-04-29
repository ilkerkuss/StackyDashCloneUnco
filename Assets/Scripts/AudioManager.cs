using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Audio[] Audios;

    private AudioSource _audioSource;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        Init();
    }

    public void Init()
    {

        foreach (Audio au in Audios)
        {
            au.AudioSource = gameObject.AddComponent<AudioSource>();
            au.AudioSource.clip = au.AudioClip;
            au.AudioSource.volume = au.Volume;
            au.AudioSource.loop = au.SoundLoop;
            au.AudioSource.pitch = au.Pitch;


        }

    }

    public void PlaySound(string name)
    {
        foreach (Audio au in Audios)
        {
            if (au.AudioName == name)
                au.AudioSource.Play();
        }
    }
    public void StopSound(string name)
    {
        foreach (Audio au in Audios)
        {
            if (au.AudioName == name)
                au.AudioSource.Stop();
        }
    }

    public void PlaySoundAtPoint(string name,Vector3 playPoint)
    {
        foreach (Audio au in Audios)
        {
            if (au.AudioName == name)

                AudioSource.PlayClipAtPoint(au.AudioClip,playPoint);
        }
    }


}
