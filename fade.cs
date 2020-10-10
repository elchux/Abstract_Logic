using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class fade : MonoBehaviour
{
    public Image black;
    public string[] scenes;

    void Start()
    {
        black.CrossFadeAlpha(0, 0.5f, false);
    }
    public void FadeToBlack(int i) 
    {
        black.CrossFadeAlpha(1, 0.5f, false);
        StartCoroutine(LoadScene(scenes[i]));
    }
    IEnumerator LoadScene(string scene) 
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
    }
}
