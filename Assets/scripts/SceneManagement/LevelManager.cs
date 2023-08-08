using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private void NextLevel()
    {
        SceneManager.LoadScene(3);
    }
    private void Win()
    {
        SceneManager.LoadScene(5);
    }
    private void OnEnable()
    {
        nextLVL.level1event += NextLevel;
        winScript.winevent += Win;
    }
    private void OnDisable()
    {
        nextLVL.level1event -= NextLevel;
        winScript.winevent -= Win;
    }
}

