using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void ChangeScene()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(1);
    }
}
