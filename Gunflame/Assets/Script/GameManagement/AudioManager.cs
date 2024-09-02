using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public List<Sounds> Music, SFX;

    private void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        for (int i = 0; i < Music.Count; i++)
        {
            Music[i].Source = gameObject.AddComponent<AudioSource>();
            Music[i].Source.clip = Music[i].Clip;
            Music[i].Source.playOnAwake = false;
            Music[i].Source.loop = true;

            if (i == 0)
            {
                Music[i].Source.Play(); //Title BGM
            }
        }

        for (int i = 0; i < SFX.Count; i++)
        {
            SFX[i].Source = gameObject.AddComponent<AudioSource>();
            SFX[i].Source.clip = SFX[i].Clip;
            if (i == 5) //Sound when Player uses dash ability
            {
                SFX[i].Source.pitch = 1;
            }
        }
    }


    public void changeMusicVolume(float _volume)
    {
        for (int i = 0; i < Music.Count; i++)
        {
            Music[i].Source.volume = _volume;
        }
    }
    public void changeSFXVolume(float _volume)
    {

        for (int i = 0; i < SFX.Count; i++)
        {
            SFX[i].Source.volume = _volume;
        }
    }

    public void PlaySoundFX(int _index)
    {
        SFX[_index].Source.Play();
    }

}
