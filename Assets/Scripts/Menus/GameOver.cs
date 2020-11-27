using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//script to handle game over menu
public class GameOver : MonoBehaviour
{
    //change scene based on scene index number
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);     
    }
    //quit game, if in unity editor quit play mode
    public void ExitToDesktop()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
