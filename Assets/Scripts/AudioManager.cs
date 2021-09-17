using System;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   [SerializeField] public Sound[] sounds;
   
   public static AudioManager instance;

   private void Awake()
   {
    // if (instance == null)
    //     instance = this;
    // else
    // {
    //     Destroy(gameObject);
    //     return;
    // }
    // DontDestroyOnLoad(gameObject);
      
       foreach (Sound s in sounds)
       {
           s.source = gameObject.AddComponent<AudioSource>();
         
           s.source.clip = s.clip;
           s.source.loop = s.loop;
           s.source.volume = s.volume;
           s.source.pitch = s.pitch;
       }
   }

   public void PlaySound(string name)
   {
       foreach (Sound s in sounds)
       {
           if (s.name == name)
           {
               s.source.Play();
           }
       }

   }
}
