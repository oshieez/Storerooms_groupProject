using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uiScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void instructionScene()
    {
        SceneManager.LoadScene("InstructionScene");
    }

    public void backBtn()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void restartBtn()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
