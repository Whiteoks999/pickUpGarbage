using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_Level : MonoBehaviour
{
    public bool flag = false;
    void Update()
    {
        if (flag)
            Time.timeScale = 1f;
    }
    public void NextLevel()
    {
        flag = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}

