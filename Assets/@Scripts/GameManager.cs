using UnityEngine;
using TMPro;

// 스코어 관리 (지속 시간으로 계산)

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // public
    public TMP_Text scoreText;
    public float Score
    {
        get { return _score; }
        set { _score = value; }
    }
    public float PlayerStartTime
    {
        get { return _playerStartTime; }
        set { _playerStartTime = value; }
    }
    //public float BestScore
    //{
    //    get { return _bestScore; }
    //    set { _bestScore = value; }
    //}

    // private
    float _score;
    float _playerStartTime;
    //float _bestScore;

    private void Start()
    {
        //_score = 0;
        //_playerStartTime = Time.time;

        //_bestScore = PlayerPrefs.GetFloat("BestScore", 0f);
    }


    private void Update()
    {
        _score = Mathf.FloorToInt(ScoreCheck());
        scoreText.text = $"{_score}";

        //if (_score < _bestScore)
        //{
        //    _bestScore = _score;
        //    PlayerPrefs.SetFloat("BestScore", _bestScore);
        //}
    }
    float ScoreCheck()
    {
        return Time.time - _playerStartTime;
    }
}
