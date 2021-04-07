using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip jonas_blue_what_i_like_about_you_clip;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(StartSong());
    }
    IEnumerator StartSong()
    {
        AudioSource mySource = GetComponent<AudioSource>();
        mySource.clip = jonas_blue_what_i_like_about_you_clip;
        mySource.Play();
        //Debug.Log(mySource.GetSpectrumData(jonas_blue_what_i_like_about_you_clip.frequency,));
        while (mySource.isPlaying)
        {
            
        }
        yield return null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
