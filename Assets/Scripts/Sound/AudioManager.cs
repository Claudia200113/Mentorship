using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Singleton type, persists on changing scenes. Takes all the audio clips, plays background music on start and has a
//PlaySFX method to play a oneshot of a given audio clip. 
public class AudioManager : MonoBehaviour
{
   [Header("Audio Source")]
   [SerializeField] private AudioSource musicSource;
   [SerializeField] private AudioSource SFXSource;

   [Header("Audio Clip")] public AudioClip background;
   public AudioClip death, jump, gem, damage, landing;

   public static AudioManager Instance
   {
      get;
      private set;
   }
   private void Awake()
   {
      DontDestroyOnLoad(gameObject);
      if (Instance != null)
      {
         Destroy(gameObject);
      }
      else
      {
         Instance = this;
      }
   }
   private void Start()
   {
      musicSource.clip = background;
      musicSource.Play();
   }

   public void PlaySFX(AudioClip clip)
   {
      SFXSource.PlayOneShot(clip);
   }
   
}
