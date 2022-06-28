using RouteTeamStudios.Utilities;
using UnityEngine;

namespace RouteTeamStudios.Audio
{
    public class Audio : PersistentSingleton<Audio>
    {
        AudioSource audioMain;
        public AudioClip[] soundtrack;

        void Start()
        {
            audioMain.clip = soundtrack[Random.Range(0, soundtrack.Length)];
            audioMain.Play();
        }

        void Update()
        {
            if (!audioMain.isPlaying)
            {
                audioMain.clip = soundtrack[Random.Range(0, soundtrack.Length)];
                audioMain.Play();
            }
        }
    }
}
