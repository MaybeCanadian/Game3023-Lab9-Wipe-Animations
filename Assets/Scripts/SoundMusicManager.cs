using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMusicManager : MonoBehaviour
{
    public static SoundMusicManager instance;

    public AudioSource audSource;

    public List<AudioClip> SoundTracks;
    private void Awake()
    {
        if(instance != this && instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }
    private void Start()
    {
        audSource = GetComponent<AudioSource>();

        InitSoundTracks();
    }

    private void InitSoundTracks()
    {
        SoundTracks = new List<AudioClip>();

        SoundTracks.Add(Resources.Load<AudioClip>("Audio/SoundTracks/LOOP_A Creature in the Wild!"));
        SoundTracks.Add(Resources.Load<AudioClip>("Audio/SoundTracks/LOOP_Exploring the Depths"));
        SoundTracks.Add(Resources.Load<AudioClip>("Audio/SoundTracks/LOOP_Mysterious Cave"));
        SoundTracks.Add(Resources.Load<AudioClip>("Audio/SoundTracks/LOOP_New Destinations"));
        SoundTracks.Add(Resources.Load<AudioClip>("Audio/SoundTracks/LOOP_Together We Fight"));
        SoundTracks.Add(Resources.Load<AudioClip>("Audio/SoundTracks/LOOP_Trouble Afoot"));
    }

    public void PlayMusic(e_SoundTrack track, bool loop)
    {
        audSource.clip = SoundTracks[(int)track];
        audSource.loop = loop;
        audSource.Play();
    }
}

public enum e_SoundTrack 
{ 
    CreatureInTheWild,
    ExploringTheDepths,
    MysteriousCave,
    NewDestinations,
    TogetherWeFight,
    TroubleAfoot
}
