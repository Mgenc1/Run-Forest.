using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance=null;

    
    public AudioSource audioSource;
    

    [Header("CLIPS")]
    public AudioClip GoldCollectionClip;
    public AudioClip Steps;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        else if (Instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    
    public void PlayGoldCollection()
    {
        audioSource.clip = GoldCollectionClip;
        audioSource.PlayOneShot(GoldCollectionClip);
    }
    public void PlaySteps()
    {
        audioSource.clip = Steps;
        audioSource.PlayOneShot(Steps);
    }

    public void StopSounds()
    {
        audioSource.Stop();
    }

}
