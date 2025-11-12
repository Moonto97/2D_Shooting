using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    // 목표 : 적을 죽을 때마다 점수를 올리고, 현재 점수를 UI에 표시하고 싶다.
    // 필요 속성
    // - 현재 점수 UI (Text 컴포넌트) (UI요소는 항상 변수명 뒤에 UI를 붙인다.)
    [SerializeField] private Text _currentScoreTextUI;
    // - 현재 점수를 기억할 변수
    public int CurrentScore = 0;
    private const string ScoreKey = "Score";
    // 텍스트의 Rect Transform 캐싱
    private RectTransform _scoreRectTransform;
    
    private void Start()
    {
        _scoreRectTransform = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<RectTransform>();
        Load();
        CurrentScore = 0;
        Refresh();
    }

    // 하나의 메서드는 한 가지 일만 잘 하면 된다.
    public void AddScore(int score)
    {
        if (score <= 0) return;
        CurrentScore += score;
        Refresh();
        Save();
        ScaleConverter();
    }

    private void Refresh()
    {
        _currentScoreTextUI.text = $"현재 점수 : {CurrentScore:N0}";
    }

    private void Save()
    {
        PlayerPrefs.SetInt("Score", CurrentScore);
    }

    private void Load()
    {
        CurrentScore = PlayerPrefs.GetInt(ScoreKey, 0);
    }

    // 스케일 키우기
    private void ScaleConverter()
    {
        StartCoroutine(WaitSeconds());
    }
    private IEnumerator WaitSeconds()
    {
        _scoreRectTransform.localScale = new Vector3(1.3f, 1.3f, 1);
        yield return new WaitForSeconds(0.2f);
        _scoreRectTransform .localScale = new Vector3(1f, 1f, 1);
    }
}

