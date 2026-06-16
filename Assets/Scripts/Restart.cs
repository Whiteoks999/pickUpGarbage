using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public bool flag = false;
    void Update()
    {
        if (flag)
        Time.timeScale = 1f;
    }
        public void RestartLevel() {
        flag = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+0);
        
    }
}
