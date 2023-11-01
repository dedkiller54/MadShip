using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{
    public void ExitGame()
    {
        SceneManager.LoadScene("level_30");
        Time.timeScale= 1.0f;
        ArrayScript.MaxStereoid = 0;

    }
}
