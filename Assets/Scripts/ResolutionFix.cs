using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionFix : MonoBehaviour
{
    float scalefactor;
    public GameObject[] objects;
    void Start()
    {
        scalefactor = 0.9f;
        Resolution resolution;
        resolution = Screen.currentResolution;
        if (resolution.height % 9 == 0 && resolution.width % 16 == 0)
        {
            return;
        }
        for (int i = 0; i < objects.Length; i++)
        {
            Vector3 vector = new Vector3(objects[i].transform.localScale.x * scalefactor, objects[i].transform.localScale.y, objects[i].transform.localScale.z);
            
            objects[i].transform.localScale = new Vector3(objects[i].transform.localScale.x * scalefactor, objects[i].transform.localScale.y, objects[i].transform.localScale.z);
        }     
    }
}
