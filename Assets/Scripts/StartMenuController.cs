using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[DefaultExecutionOrder(1000)]
public class StartMenuController : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TMP_Text bestScoreText;
    // Start is called before the first frame update

    private void Start()
    {
        GameManager.Singleton.LoadData();
        inputField.text = GameManager.Singleton.gameData.playerName;
        bestScoreText.text = $"{GameManager.Singleton.gameData.bestPlayer} : BestScore : {GameManager.Singleton.gameData.bestScore}";
    }

    public void StartGame()
    {
        GameManager.Singleton.gameData.playerName = inputField.text;
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        GameManager.Singleton.SaveData();
        UnityEditor.EditorApplication.ExitPlaymode();

#else
Application.Quit();
 GameManager.Singleton.SaveData();
#endif
    }
}
