using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchingAgain : MonoBehaviour
{
    public static string beforeSceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickGetScene()
    {
        beforeSceneName = SceneManager.GetActiveScene().name;
    }

    public void OnClickSwitchingScene()
    {
        SceneManager.LoadScene(beforeSceneName);
    }
}
