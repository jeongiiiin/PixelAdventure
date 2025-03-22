using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    // public
    public Button StartButton;

    void Start()
    {
        StartButton.onClick.AddListener(StartButtonClick);
    }

    void StartButtonClick()
    {
        SceneManager.LoadScene("01_Stage");
    }
}
