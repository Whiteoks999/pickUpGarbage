using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColaCanScript : MonoBehaviour
{
    public GameObject coca;
    public Material material_activ;
    public Material material_desactiv;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActateBonus() {
        coca.GetComponent<Renderer>().material=material_activ;
    }


    public void DecreaseBonus()
    {
       coca.GetComponent<Renderer>().material=material_desactiv;
    }



}
