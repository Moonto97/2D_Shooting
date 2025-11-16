using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
    // 스코어매니저는 단 하나여야 하고 전역적인 접근점을 제공해야한다. 싱글톤.
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

    private static ScoreManager _instance;  // 다른곳에서 건드리지 못하게 은닉화 private
    public static ScoreManager Instance => _instance;   // Getter 프로퍼티로 접근 전역성을 확보
    private int _bossSpawnScore = 1000;

    private void Awake()
    {
        if(_instance != null)    // 싱글톤. 관리자는 하나여야만 한다.
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
    }

    private void Start()
    {
        // 보스등장조건설정위해 캐싱

        // UI 설정
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
        ActiveScaleConverter();
        if (CurrentScore == _bossSpawnScore) EnemyFactory.Instance.MakeBoss();
    }

    private void Refresh()
    {
        _currentScoreTextUI.text = $"현재 점수 : {CurrentScore}";
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
    private void ActiveScaleConverter()
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

