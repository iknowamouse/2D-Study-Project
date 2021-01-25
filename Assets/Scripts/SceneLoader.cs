using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour


{

    public static SceneLoader instance;
    
    public void Awake()
    {
        SceneLoader.instance = this;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Reload()
    {
        //1
       string currentSceneName = SceneManager.GetActiveScene().name;
       SceneManager.LoadScene(currentSceneName);
        
        //2
        //int currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        // SceneManager.LoadScene(currentSceneBuildIndex);

        //3
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextScene()
    {
        //1

        int currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneBuildIndex + 1);

        //2

        //bool isCurrentScene = SceneManager.GetActiveScene().isLoaded;
        //if (isCurrentScene == true)
        //{
        //    int countScenes = SceneManager.sceneCount;
        //    SceneManager.LoadScene(Coountscenes++);
        //}
    }
}
