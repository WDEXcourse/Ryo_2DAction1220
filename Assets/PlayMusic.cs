using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] bgm;
    public bool DontDestroyEnabled = true;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (DontDestroyEnabled)
        {
            DontDestroyOnLoad(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnclickPlayMusic(string bgmname)
    {

        switch (bgmname)
        {
            case "LetsGo":
                audioSource.PlayOneShot(bgm[0]);
                break;
            case "Popsicle":
                audioSource.PlayOneShot(bgm[1]);
                break;
            case "Harpuia":
                audioSource.PlayOneShot(bgm[2]);
                break;
            case "High":
                audioSource.PlayOneShot(bgm[3]);
                break;
        }
    }

    public void OnClickStop()
    {
        audioSource.Stop();
    }
}
