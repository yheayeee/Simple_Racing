using System;
using UnityEngine;
using UnityEngine.UI; // Legacy Text를 사용하기 위해 이 네임스페이스로 변경했다.

public class Timer : MonoBehaviour
{
    // 1. Inspector에서 UI Text 요소를 연결하기 위한 변수
    // Legacy Text 타입인 'Text'로 변경했다.
    public Text timerText; 

    // 2. 현재 시간을 저장할 변수
    private float currentTime = 0f;
    
    // 3. 타이머 작동 상태를 제어할 변수 (선택 사항)
    private bool isRunning = true; 

    public static Action EndGame;
    public static Action RestartGame;

    void Awake()
    {
        EndGame+=StopTimer;
        EndGame+=ifEnd;
    }

    // 매 프레임마다 호출되는 Update 함수에서 시간을 갱신한다.
    void Update()
    {
        if (isRunning)
        {
            // Time.deltaTime을 이용해 시간을 증가시킨다.
            currentTime += Time.deltaTime;
            
            // 시간을 포맷하여 텍스트를 업데이트한다.
            UpdateTimerDisplay(currentTime);
        }
    }

    // 시간을 포맷하여 UI에 표시하는 함수
    void UpdateTimerDisplay(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        // string.Format을 사용하여 "00:00" 형태로 포맷하고 Text 컴포넌트에 할당했다.
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
    // 타이머 제어 함수 (Stop/Start)
    public void StopTimer()
    {
        isRunning = false;
    }
    
    public void StartTimer()
    {
        isRunning = true;
    }

    public void ResetTimer()
    {
        // 1. currentTime 변수를 0으로 초기화합니다.
        currentTime = 0f;
        
        // 2. 초기화와 동시에 타이머 표시를 즉시 00:00으로 업데이트합니다.
        UpdateTimerDisplay(currentTime);
        
        Debug.Log("타이머가 00:00으로 초기화되었습니다.");
    }

    public void ifEnd()
    {
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        //Debug.Log(string.Format("{0:00}:{1:00}", minutes, seconds));
        
    }
}