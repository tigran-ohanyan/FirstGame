using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public GameObject LoadingScreen;
    public GameObject Btn;
    //public GameObject Menu;
    private int SceneNumber;
    public bool OnStart;

    public Slider scale;

    void Start()
    {
        if (OnStart == true)
            LoadingProgress(1);
    }

    public void LoadingProgress(int SceneID){
        LoadingScreen.SetActive(true);
        //Menu.SetActive(false);
        SceneNumber = SceneID;
        StartCoroutine(LoadAsync());
    }
    

    IEnumerator LoadAsync(){
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(SceneNumber);

        loadAsync.allowSceneActivation = false;
        Debug.Log("1");
        while (!loadAsync.isDone){
            
            scale.value = loadAsync.progress;

            if(loadAsync.progress >= .9f && !loadAsync.allowSceneActivation){
                yield return new WaitForSeconds(2.2f);
                loadAsync.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
