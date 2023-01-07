using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject notePrefab; //Префаб ноты
    public Transform[] lines; // Массив линий по которым идут ноты
    public Transform removeLine; // Объект к которому стремятся ноты
    public float speed = 0; // Скорость нот
    int nowline;
    public bool creationTypeButton;
    public float generationTime;
    // Start is called before the first frame update
    void Start()
    {
        if (!creationTypeButton)
        {
            InvokeRepeating("CreateNote", generationTime, generationTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (creationTypeButton)
        {
            if (Input.GetKeyDown(KeyCode.C)) //Создание нот по кнопке
            {
                CreateNote();
            }
        }
    }

    void CreateNote()
    {
        nowline = Random.Range(0, 4);
        GameObject note = Instantiate(notePrefab, lines[nowline]);
        note.GetComponent<Note>().SetType(nowline);
        note.GetComponent<Note>().SetLines(lines[nowline], removeLine);
        note.GetComponent<Note>().SetSpeed(speed);
    }
}
