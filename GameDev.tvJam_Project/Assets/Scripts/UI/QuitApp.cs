using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class QuitApp : MonoBehaviour
{
    public void QuitGame()
    {
        AudioManager.Instance.Play("ClickButton");

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();   
#endif
    }
}
