using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LvlManager : MonoBehaviour
{
    public Button button;
    public GameObject prefab;
    public Transform trfm;
    public void Pause() 
    {
        Time.timeScale = 0;
    }

    public void Continue()
    {
        Time.timeScale = 1;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PreviousLVL()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


    public void NextLVL()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void Start()
    {
        StartCoroutine(StartGame());
        
    }

    IEnumerator StartGame() 
    {
        yield return new WaitForSeconds(2);
        Instantiate(prefab, trfm.position, Quaternion.identity);
    }
    public void Quit() 
    {
        Application.Quit();
    }
    private void Update()
    {
        if (Time.timeScale == 0)
        {
            button.interactable = false;
        }
        else
            button.interactable = true;
    }

}
