using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMusicManager : MonoBehaviour
{
    public static SoundMusicManager instance;

    public AudioSource[] audSource;
    public int currentActiveSource = 0;

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
            audSource = GetComponents<AudioSource>();
            currentActiveSource = 0;
            instance = this;
        }
    }

    private void Start()
    {
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

    public void PlayMusic(e_SoundTrack track, bool loop, float fadeDuration)
    {
        if (audSource[currentActiveSource].isPlaying == false)
        {
            audSource[currentActiveSource].clip = SoundTracks[(int)track];
            audSource[currentActiveSource].loop = loop;
            audSource[currentActiveSource].Play();
            return;
        } //nothing is already playing in the active source

        StartCoroutine(FadeSourceOut(audSource[currentActiveSource], fadeDuration)); //fades old out
        currentActiveSource++;
        if(currentActiveSource >= audSource.Length)
        {
            currentActiveSource = 0;
        }

        StartCoroutine(FadeSourceIn(audSource[currentActiveSource], SoundTracks[(int)track], fadeDuration, loop)); //fades new in
    }

    private IEnumerator FadeSourceOut(AudioSource source, float duration)
    {
        float timer = 0;
        float reduceRate = 1.0f / duration;

        while(timer <= duration)
        {
            source.volume -= reduceRate * Time.deltaTime;

            timer += Time.deltaTime;

            yield return null;
        }

        source.loop = false;
        source.Stop();
        yield break;
    }

    private IEnumerator FadeSourceIn(AudioSource source, AudioClip clip, float duration, bool loop)
    {
        source.loop = loop;
        source.clip = clip;
        source.Play();
        source.volume = 0.0f;

        float timer = 0;
        float gainRate = 1.0f / duration;

        while (timer <= duration)
        {
            source.volume += gainRate;
            timer += Time.deltaTime;

            yield return null;
        }

        yield return null;
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
