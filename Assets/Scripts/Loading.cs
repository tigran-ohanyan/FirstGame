using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public GameObject LoadingScreen;
    public GameObject Menu;

    public Slider scale;
    public void LoadingProgress(){
        LoadingScreen.SetActive(true);
        Menu.SetActive(false);
        StartCoroutine(LoadAsync());
    }
    

    IEnumerator LoadAsync(){
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(1);

        loadAsync.allowSceneActivation = false;

        while(!loadAsync.isDone){

            scale.value = loadAsync.progress;

            if(loadAsync.progress >= .9f && !loadAsync.allowSceneActivation){
                yield return new WaitForSeconds(2.2f);
                loadAsync.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
