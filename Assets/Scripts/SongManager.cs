using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SongManager : MonoBehaviour
{
    BoxCollider2D lineCollider;
    bool[] types = new bool[4];
    GameObject[] notes = new GameObject[4];
    public SpriteRenderer[] catchers;
    public GameObject[] effects;
    public Sprite[] images;
    public Spawner spawner;
    int hit = 0, miss = 0, harvestlvl=0, scemenumber = 0;
    bool lose;
    [Header("IntParams")]
    [Space(10)]
    public int EndGameMiss = 1;
    public int EndGameHit = 1;
    public int updatetolvl2harvest = 5;
    public int updatetolvl3harvest = 10;
    [Header("UI")]
    [Space(10)]
    public UIController ui;
    public Image[] lives;
    public Sprite loseLiveImage;
    ParticleSystem[] ps;
    [Header("Music")]
    [Space(10)]
    public AudioClip badMusicEffect;
    public AudioSource sideAudioSource;
    public AudioClip loseMusicEffect;
    public AudioSource mainAudioSource;
    [Header("Harvest")]
    [Space(10)]
    public GameObject[] harvest;

    void Start()
    {
        Time.timeScale = 1;
        scemenumber = SceneManager.GetActiveScene().buildIndex;
        lineCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            catchers[1].sprite = images[1];
            CheckTouch(1);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            catchers[1].sprite = images[0];
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            catchers[2].sprite = images[1];
            CheckTouch(2);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            catchers[2].sprite = images[0];
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            catchers[0].sprite = images[1];
            CheckTouch(0);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            catchers[0].sprite = images[0];
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            catchers[3].sprite = images[1];
            CheckTouch(3);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            catchers[3].sprite = images[0];
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene(scemenumber);
        }
    }

    void CheckTouch(int type)
    {
        //Debug.Log("Check");
        if (types[type])  //Фиксация попадания
        {
            hit++;
            ui.Slidernewvalue(hit);
            if (hit == updatetolvl2harvest || hit == updatetolvl3harvest)
            {
                harvest[harvestlvl].SetActive(false);
                harvestlvl++;
                harvest[harvestlvl].SetActive(true);
            }
            ps = effects[type].GetComponentsInChildren<ParticleSystem>();
            for (int i=0; i< ps.Length;i++)
            {
                ps[i].Play();
            }
            Debug.Log("GoodCheck: " + hit);
            types[type] = false;
            notes[type].GetComponent<Note>().SetMiss(false);
            notes[type].GetComponent<Note>().Destroy();
            if (hit >= EndGameHit)
            {
                EndGameMenu(true);
            }

            return;
        }
        if (!types[type]) //Фиксация неверного нажатия
        {
            if (sideAudioSource != null)
            {
                sideAudioSource.clip = badMusicEffect;
                sideAudioSource.Play();
            }
            Debug.Log("BadCheck");
            return;
        }
    }

    public void NowState(int type, bool state, GameObject obj) //Хранение конкретной ноты в менеджере
    {
        types[type] = state;
        notes[type] = obj;
    }

    public void AddMiss()
    {
        if (!lose)
        {
            lives[miss].sprite = loseLiveImage;
            miss++;
            if (miss >= EndGameMiss)
            {
                lose = true;
                EndGameMenu(false);
            }
        }
    }

    void EndGameMenu(bool win)
    {
        if (win)
        {
            Debug.Log("win");
            if (scemenumber == 4)
            {

            }
            else
            {
                ui.SetButtonActive();
            }
            //Show win image
        }
        if (!win)
        {
            if (mainAudioSource != null)
            {
                for (int i = 0; i < spawner.lines.Length; i++)
                    spawner.lines[i].gameObject.SetActive(false);
                mainAudioSource.clip = loseMusicEffect;
                mainAudioSource.Play();
                mainAudioSource.loop = false;
                ui.StartAnimationForRestartButton();
            }
            Debug.Log("lose");
            //Show lose image
        }
    }
}
