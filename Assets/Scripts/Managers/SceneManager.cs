using UnityEngine;

public class MenuSceneManager : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneTransitionManager.Instance
            .ChangeScene("MainMenu");
    }

    public void LoadLevelSelection()
    {
        SceneTransitionManager.Instance
            .ChangeScene("LevelSelection");
    }

    public void LoadLevelEasy()
    {
        SceneTransitionManager.Instance
            .ChangeScene("LevelEasy");
    }

    public void LoadLevelMedium()
    {
        SceneTransitionManager.Instance
            .ChangeScene("LevelMedium");
    }

    public void LoadLevelHard()
    {
        SceneTransitionManager.Instance
            .ChangeScene("LevelHard");
    }

    public void LoadOptions()
    {
        SceneTransitionManager.Instance
            .ChangeScene("Options");
    }

    public void LoadCredits()
    {
        SceneTransitionManager.Instance
            .ChangeScene("Credits");
    }

    public void LoadTutorial()
    {
        SceneTransitionManager.Instance
            .ChangeScene("Tutorial");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}