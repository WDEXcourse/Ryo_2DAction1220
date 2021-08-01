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

    public void OnclickMusic1(string bgmname)
    {

        switch (bgmname)
        {
            case "LetsGo":
                audioSource.PlayOneShot(bgm[0]);
                Debug.Log("押された");
                break;
        }
    }
}
