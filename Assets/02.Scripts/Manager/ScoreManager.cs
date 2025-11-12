using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // 목표 : 적을 죽을 때마다 점수를 올리고, 현재 점수를 UI에 표시하고 싶다.
    // 필요 속성
    // - 현재 점수 UI (Text 컴포넌트) (UI요소는 항상 변수명 뒤에 UI를 붙인다.)
    [SerializeField] private Text _currentScoreTextUI;
    // - 현재 점수를 기억할 변수
    private int _currentScore = 0;
    
    
    private void Start()
    {
        Refresh();
    }

    public void AddScore(int score)
    {
        if (score <= 0) return;
        _currentScore += score;
    }

    private void Refresh()
    {
        
        _currentScoreTextUI.text = $"현재 점수 : {_currentScore}";
    }
}

