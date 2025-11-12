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
        Refresh();
    }

    private void Refresh()
    {
        _currentScoreTextUI.text = $"현재 점수 : {_currentScore}";
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha9))
        {
            TestSave();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            TestLoad();
        }
    }

    private void TestSave()
    {
        // 유니티에서는 값을 저장할 때 'PlayerPrefs' 모듈을 쓴다.
        // 저장 가능한 자료형 : int, float, string
        // 저장할 때 저장할 이름(key)과 값 (value) 이 두 형태로 저장한다.
        // 저장 : Set
        // 로드 : Get

        PlayerPrefs.SetInt("age", 19);
        PlayerPrefs.SetString("name", "김홍일");
        Debug.Log("저장됐습니다.");
    }

    private void TestLoad()
    {
        int age = PlayerPrefs.GetInt("age");

        //------------------------------------
        if (PlayerPrefs.HasKey("age"))
        {
            age = PlayerPrefs.GetInt("age");
        }
        
        //------------------------------------
        string name = PlayerPrefs.GetString("name");

        Debug.Log($"{name}: {age}");
    }
}

