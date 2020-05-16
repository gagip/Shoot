using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextScene(string sceneName)
    {
        // 다음 씬으로 넘어갈 수 있게끔 
        SceneManager.LoadScene(sceneName);
    }
}
