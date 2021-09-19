using System;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   [SerializeField] private Sound[] sounds;
   
   private static AudioManager instance;

   private void Awake()
   {
         if (instance == null)
             instance = this;
         else
         {
             Destroy(gameObject);
             return;
         }
         DontDestroyOnLoad(gameObject);
      
       foreach (Sound s in sounds)
       {
           s.source = gameObject.AddComponent<AudioSource>();
         
           s.source.clip = s.clip;
           s.source.loop = s.loop;
           s.source.volume = s.volume;
           s.source.pitch = s.pitch;
       }
   }

   public static void PlaySound(string name)
   {
       foreach (Sound s in instance.sounds)
       {
           if (s.name == name)
           {
               if (s.loop && s.source.isPlaying)
               {
                   continue;
               }
               s.source.Play();
           }
       }
   }
   public static void StopSound(string name)
   {
       foreach (Sound s in instance.sounds)
       {
           if (s.name == name)
           {
               s.source.Stop();
           }
       }
   }
   
}
