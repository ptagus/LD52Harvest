using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int notesCount = 20;
    public GameObject notePrefab; //������ ����
    public Transform[] lines; // ������ ����� �� ������� ���� ����
    public Transform removeLine; // ������ � �������� ��������� ����
    public float speed = 0; // �������� ���
    int nowline;
    public bool creationTypeButton;
    public float[] generationTime;
    int genTime;
    // Start is called before the first frame update
    void Start()
    {
        if (!creationTypeButton)
        {
            CreateNote();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (creationTypeButton)
        {
            if (Input.GetKeyDown(KeyCode.C)) //�������� ��� �� ������
            {
                CreateNote();
            }
        }
    }

    void CreateNote()
    {
        notesCount--;
        nowline = Random.Range(0, 4);
        GameObject note = Instantiate(notePrefab, lines[nowline]);
        note.GetComponent<Note>().SetType(nowline);
        note.GetComponent<Note>().SetLines(lines[nowline], removeLine);
        note.GetComponent<Note>().SetSpeed(speed);
        if (notesCount > 0)
        {
            genTime = Random.Range(0, generationTime.Length);
            Invoke("CreateNote", generationTime[genTime]);
        }
    }
}
