using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToStart()
    {
        SceneManager.LoadScene("Start");
        Debug.Log("ToStart");
    }


    public void ToTheme()
    {
        SceneManager.LoadScene("Theme");
        Debug.Log("ToTheme");
    }

    public void ToMain()
    {
        //SceneManager.LoadScene("Shika_Main");
        Debug.Log("ToMain");
    }

    public void ToResult()
    {
        //SceneManager.LoadScene("Shika_Result");
        Debug.Log("ToResult");
    }
}
