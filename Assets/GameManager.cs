using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject orangeCompleteLevelUI;
    public GameObject greenCompleteLevelUI;

    public void OrangeCompletedLevel()
    {
        orangeCompleteLevelUI.SetActive(true);
        StartCoroutine(Restart());
    }

    public void GreenCompletedLevel()
    {
        greenCompleteLevelUI.SetActive(true);
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(1);
    }
}
