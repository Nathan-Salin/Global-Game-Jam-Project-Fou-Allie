using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public Sound[] laughingSounds;
    public Sound[] booSounds;

    public static AudioManager instance;
    // Start is called before the first frame update
    void Awake()
    {

        foreach (Sound s in sounds){
            s.source=gameObject.AddComponent<AudioSource>();
            s.source.clip=s.clip;
            s.source.volume=s.volume;
            s.source.pitch=s.pitch;
            s.source.loop=s.loop;
        }
        foreach (Sound s in laughingSounds){
            s.source=gameObject.AddComponent<AudioSource>();
            s.source.clip=s.clip;
            s.source.volume=s.volume;
            s.source.pitch=s.pitch;
            s.source.loop=s.loop;
        }
        foreach (Sound s in booSounds){
            s.source=gameObject.AddComponent<AudioSource>();
            s.source.clip=s.clip;
            s.source.volume=s.volume;
            s.source.pitch=s.pitch;
            s.source.loop=s.loop;
        }
    }

    void Start(){
        Play("BackgroundMusic");
    }

    public void PlayRandomLaughing(){
        int index = UnityEngine.Random.Range(0, laughingSounds.Length);
        Sound s=laughingSounds[index];
        s.source.Play();
    }

    public void PlayRandomBoo(){
        int index = UnityEngine.Random.Range(0, booSounds.Length);
        Sound s=booSounds[index];
        s.source.Play();
    }

    public void Play (string name){
        Sound s=Array.Find(sounds, sound => sound.name == name);
        if(s==null){
            return;
        }
        s.source.Play();
    }

}
