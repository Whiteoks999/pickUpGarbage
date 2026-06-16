using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObserverScript : MonoBehaviour
{
    public HomelessManController player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bonus")) {
            player.isBonusFound = true;
            other.GetComponent<ColaCanScript>().ActateBonus();
            player.TakeBonus(other.gameObject);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bonus"))
        {
            player.isBonusFound = false;
            other.GetComponent<ColaCanScript>().DecreaseBonus();
        }
    }

}
