using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    BoxCollider2D lineCollider;
    bool[] types = new bool[4];
    GameObject[] notes = new GameObject[4];

    void Start()
    {
        lineCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            CheckTouch(1);
        }
    }

    void CheckTouch(int type)
    {
        //Debug.Log("Check");
        if (types[type])  //Фиксация попадания
        {
            Debug.Log("GoodCheck");
            types[type] = false;
            notes[type].GetComponent<Note>().SetMiss(false);
            notes[type].GetComponent<Note>().Destroy();
            return;
        }
        if (!types[type]) //Фиксация неверного нажатия
        {
            Debug.Log("BadCheck");
            return;
        }
    }

    public void NowState(int type, bool state, GameObject obj) //Хранение конкретной ноты в менеджере
    {
        types[type] = state;
        notes[type] = obj;
    }
}
