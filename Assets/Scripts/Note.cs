using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    Transform spawnLine, removeLine; //Точки в которых происходит создание и удаление
    Vector2 spawnPos, removePos;
    int type = 1; // Линия по которой идет нота
    bool miss = true; // Индикатор промаха
    float speed = 0;
    void Start()
    {
        spawnPos = spawnLine.position;
        removePos = removeLine.position;
        removePos.y = spawnPos.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, removePos, speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<SongManager>().NowState(type, true, this.gameObject);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (miss)
        {
            Debug.Log("Missed");
            collision.GetComponent<SongManager>().NowState(type, false, this.gameObject);
            collision.GetComponent<SongManager>().AddMiss();
            Destroy();
        }
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }

    public void SetMiss(bool missState)
    {
        miss = missState;
    }

    public void SetType(int newtype)
    {
        type = newtype;
    }
    public void SetLines(Transform spawn, Transform remove)
    {
        spawnLine = spawn;
        removeLine = remove;
    }
    public void SetSpeed(float newspeed)
    {
        speed = newspeed;
    }
}
