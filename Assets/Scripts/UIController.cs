using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Image blackScreen;
    public GameObject button;
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
                NextScene(nextscene);
            }
        }
    }

    public void NextScene(int scene)
    {
        SceneManager.LoadScene(nextscene);
    }
    public void EndScene()
    {
        endscene = true;
    }

    public void SetButtonActive()
    {
        button.SetActive(true);
    }
}
