using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public class PlayModeSceneLoader 
{
    private const string StartSceneName = "GameLoad";

    static PlayModeSceneLoader()
    {
        EditorApplication.playModeStateChanged += OnPlayModeChanged;
    }

    private static void OnPlayModeChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingEditMode) 
        {
            string scenePath = "Assets/Scenes/" + StartSceneName + ".unity";

            if (SceneManager.GetActiveScene().name != StartSceneName)
            {
                EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
                EditorSceneManager.OpenScene(scenePath); 
            }
        }
    }
}
