using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Audio : MonoBehaviour
{
    AudioSource aud;
    [Header("Object")]
    public AudioClip sound;

    [Header("Button")]
    public AudioClip clip1;
    public AudioClip clip2;

    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void object_Sound()
    {
        aud.PlayOneShot(sound);
    }
    public void clip_Sound1()
    {
        // Play clip1
        aud.PlayOneShot(clip1);
    }

    public void clip_Sound2()
    {
        // Play clip2
        aud.PlayOneShot(clip2);
    }
}