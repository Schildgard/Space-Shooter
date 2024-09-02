using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public bool GameOver;

    void Update()
    {
        if (GameOver == true)
        {
            StartCoroutine(ReturnToTitleScreen());
            GameOver = false;
        }
    }

    public void LoadMission(int _index)
    {
        SceneManager.LoadScene(_index);
        AudioManager.instance.Music[0].Source.Stop();
        if (_index == 2) // Load Mission01
        {
            AudioManager.instance.Music[1].Source.Play();
        }
        else if (_index == 1) // Load Tutorial Mision
        {
            AudioManager.instance.Music[2].Source.Play();
        }
    }

    public void LoadTitleScreen()
    {
        AudioManager.instance.Music[1].Source.Stop();
        AudioManager.instance.Music[2].Source.Stop();
        AudioManager.instance.Music[0].Source.Play();
        SceneManager.LoadScene(0);
    }


    public void EndGame()
    {
        GameOver = true;
    }



    IEnumerator ReturnToTitleScreen()
    {
        yield return new WaitForSeconds(5);
        LoadTitleScreen();
    }
}
