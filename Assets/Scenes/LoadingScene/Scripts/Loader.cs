using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    private class LoadingMonoBehaviour : MonoBehaviour { }

    private static Action onLoaderRecall;
    private static AsyncOperation loadingAsyncOperation;

    public static void Load(int scene)
    {
        enumList.Scene value = (enumList.Scene)scene;
        onLoaderRecall = () =>
        {
            GameObject loadingGameObject = new GameObject("Loading Game Object");
            loadingGameObject.AddComponent<LoadingMonoBehaviour>().StartCoroutine(LoadSceneAsync(value));
            //SceneManager.LoadScene(value.ToString());
        };

        SceneManager.LoadScene(enumList.Scene.Loading.ToString());
    }
    
    private static IEnumerator LoadSceneAsync(enumList.Scene scene)
    {
        yield return null;

        loadingAsyncOperation = SceneManager.LoadSceneAsync(scene.ToString());

        while (!loadingAsyncOperation.isDone)
        {
            yield return null;
        }
    }

    public static float GetLoadingProgress()
    {
        if(loadingAsyncOperation != null)
        {
            return loadingAsyncOperation.progress;
        } else
        {
            return 0f;
        }
       
    }

    public static void LoaderRecall()
    {
        if(onLoaderRecall != null)
        {
            onLoaderRecall();
            onLoaderRecall = null;
        }
    }
}