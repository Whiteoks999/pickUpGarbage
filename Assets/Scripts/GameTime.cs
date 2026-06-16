using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{
    public Text timer;
    public float lifeTime = 10f;
    private float gameTime;
    public GameObject image;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {


        if (lifeTime != 0)
        {
            timer.text = "Осталось: " + lifeTime + " секунд";
            gameTime += 1 * Time.deltaTime;


            if (gameTime >= 1)
            {
                lifeTime -= 1;
                gameTime = 0;
            }
        }
        else {
            timer.text = "Время";
            image.active = true;
            Time.timeScale = 0f;
        }
       
    }
}
