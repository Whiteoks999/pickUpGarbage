using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_in_Rule : MonoBehaviour
{
    public GameObject plane_menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void exitRul() {
        plane_menu.active = false;
    }
}
