using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mediaPlayer : MonoBehaviour
{
    public AudioSource [] myAudioS= new AudioSource[3];
    public AudioClip[] myMedia = new AudioClip[32];
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void MyAudioS1(int posSound1) 
    {
        myAudioS[1].clip = myMedia[posSound1];
        myAudioS[1].Play();
    }
    public void MyAudioS2(int posSound2) 
    {
        myAudioS[2].clip = myMedia[posSound2];
        myAudioS[2].Play();
    }

    void Start()
    {
        myAudioS[0].clip=myMedia[0];
        myAudioS[0].Play();
        SceneManager.LoadScene("1Start");
    }

    void Update()
    {
        
    }
}
