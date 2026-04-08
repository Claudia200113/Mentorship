using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   [Header("Audio Source")]
   [SerializeField] private AudioSource musicSource;
   [SerializeField] private AudioSource SFXSource;

   [Header("Audio Clip")] public AudioClip background;
   public AudioClip death, jump, gem, damage, warrior, bat;

   public static AudioManager Instance
   {
      get;
      private set;
   }
   private void Awake()
   {
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
