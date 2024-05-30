using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapManager : Singleton<SceneSwapManager>
{
    public SceneField scene;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("Transition scene");
            StartCoroutine(FadeOutThenChangeScene(scene));
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public IEnumerator FadeOutThenChangeScene(SceneField myScene)
    {
        Debug.Log("Start Fade Out");
        SceneFadeManager.Instance.StartFadeOut();

        while(SceneFadeManager.Instance.IsFadingOut)
        {
            yield return null;
        }

        SceneManager.LoadScene(myScene);
    }



    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneFadeManager.Instance.StartFadeIn();
    }

}
