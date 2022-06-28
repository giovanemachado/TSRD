using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    AudioSource audioMain;
    public AudioClip[] soundtrack;

    Queue<AudioClip> musics;

    private void Awake()
    {
        musics = new Queue<AudioClip>();
        RestartMusics();
        audioMain = GetComponent<AudioSource>();
    }

    void Start()
    {
        audioMain.clip = musics.Dequeue();
        audioMain.Play();
    }

    void Update()
    {
        if (!audioMain.isPlaying)
        {
            if (musics.Count == 0)
            {
                RestartMusics();
                return;
            }

            audioMain.clip = musics.Dequeue();
            audioMain.Play();
        }
    }

    void RestartMusics()
    {
        Shuffle(soundtrack);

        musics.Clear();

        foreach (AudioClip music in soundtrack)
        {
            musics.Enqueue(music);
        }
    }

    void Shuffle<T>(T[] array)
    {
        System.Random rng = new System.Random();
        int n = array.Length;
        while (n > 1)
        {
            int k = rng.Next(n--);
            T temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
    }
}
