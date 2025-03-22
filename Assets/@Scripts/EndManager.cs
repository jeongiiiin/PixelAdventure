using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndManager : MonoBehaviour
{
    // public
    public Button RestartButton;
    public TMP_Text FinalScore;
    public TMP_Text BestScore;

    void Start()
    {
        RestartButton.onClick.AddListener(RestartButtonClick);
        FinalScore.text = $"{GameManager.Instance.Score}";
        //BestScore.text = $"{GameManager.Instance.BestScore}";
    }

    void RestartButtonClick()
    {
        SceneManager.LoadScene("01_Stage");
    }
}
