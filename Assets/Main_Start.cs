using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Start : MonoBehaviour
{
    public GameObject start;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play() {
        start.active = false;
        Time.timeScale = 1f;
    }
}
