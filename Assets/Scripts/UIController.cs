using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Image blackScreen;
    public GameObject button;
    public GameObject AboutPanel;
    bool endscene;
    Color color;
    int nextscene;
    void Start()
    {
        color = blackScreen.color;        
    }


    void Update()
    {
        if (endscene)
        {
            color.a += Time.deltaTime;
            blackScreen.color = color;
            if (color.a >= 1)
            {
                endscene = false;
                NextScene();
            }
        }
    }

    public void NextScene()
    {
        SceneManager.LoadSceneAsync(nextscene);
    }
    public void EndScene(int scene)
    {
        nextscene = scene;
        endscene = true;
    }

    public void SetButtonActive()
    {
        button.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void OpenAbout()
    {
        AboutPanel.SetActive(true);
    }
    public void CloseAbout()
    {
        AboutPanel.SetActive(false);
    }
}
