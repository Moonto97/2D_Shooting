using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class HighScoreManager : MonoBehaviour
{
    // 목표 : 최고점수 변수가
    // 만약 현재점수보다 낮다면 유지.
    // 아니면 만약 현재점수보다 높다면 최고점수 = 현재점수
    [SerializeField] private Text _highScoreTextUI;
    private int _highScore;
    private int _comapareScore;
    ScoreManager _scoreManager;
    private int _savedScore;
    private const string HighScoreKey = "HighScore";
    private RectTransform _highScoreRectTransform;
    private void Start()
    {
        _scoreManager = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>();
        _highScoreRectTransform = GameObject.FindGameObjectWithTag("HighScoreText").GetComponent<RectTransform>();
        Load();
        Refresh();

    }
    private void Update()
    {
        _comapareScore = _scoreManager.CurrentScore;
        if (_highScore >= _comapareScore)
        {

            return;
        }
        else
        {
            _highScore = _comapareScore;
        }
        // 비교 후
        ScalConverter();
        Save();
        Refresh();
    }
    private void Refresh()
    {
        _highScoreTextUI.text = $"최고 점수 : {_highScore}";
    }
    private void Save()
    {
        PlayerPrefs.SetInt(HighScoreKey, _highScore);
    }
    private void Load()
    {
        _highScore = PlayerPrefs.GetInt(HighScoreKey, 0);
    }
    private void ScalConverter()
    {
        StartCoroutine(WaitSeconds());
    }
    private IEnumerator WaitSeconds()
    {
        _highScoreRectTransform.localScale = new Vector3(1.3f, 1.3f, 1);
        yield return new WaitForSeconds(0.2f);
        _highScoreRectTransform.localScale = new Vector3(1f, 1f, 1);
    }
}
