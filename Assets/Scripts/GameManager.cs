using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int CurrentLevelIndex;
    private const int MaxLevelIndex = 2;

    public void LoadNextLevel()
    {
        CurrentLevelIndex++;
        if (CurrentLevelIndex > MaxLevelIndex) { CurrentLevelIndex = 1; }
        Debug.Log("load level " + CurrentLevelIndex);
        StartCoroutine(LoadYourAsyncScene(CurrentLevelIndex));
    }

    public void LoadGameFieldScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadWinMenu()
    {
        StartCoroutine(LoadYourAsyncScene(SceneNames.Win));
    }

    public void LoadLoseMenu()
    {
        StartCoroutine(LoadYourAsyncScene(SceneNames.Lose));
    }

    public void ReloadLevel()
    {
        StartCoroutine(LoadYourAsyncScene(CurrentLevelIndex));
    }

    IEnumerator LoadYourAsyncScene(string sceneName)
    {
        var currentScene = SceneManager.GetActiveScene();
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        SceneManager.MoveGameObjectToScene(GameObject.FindGameObjectWithTag("EventSystem"), SceneManager.GetSceneByName(sceneName));
        SceneManager.UnloadSceneAsync(currentScene);
    }

    IEnumerator LoadYourAsyncScene(int sceneIndex)
    {
        var currentScene = SceneManager.GetActiveScene();
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        SceneManager.MoveGameObjectToScene(GameObject.FindGameObjectWithTag("EventSystem"), SceneManager.GetSceneByBuildIndex(sceneIndex));
        SceneManager.UnloadSceneAsync(currentScene);
    }
}

