using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contin_Script : MonoBehaviour
{
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void contin() {
        menu.active = false;
        Time.timeScale = 1.0f;
    }
}
