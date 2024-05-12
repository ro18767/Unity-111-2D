using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayScript : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI clock;
    [SerializeField]
    private GameObject pauseMenu;

    // public - автоматично сер≥ал≥зован≥ (доступн≥ у редактор≥)
    public TMPro.TextMeshProUGUI messageText;

    float time;

    void Start()
    {
        time = 0f;
        SetPause(pauseMenu.activeInHierarchy);
    }

    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            messageText.text = "√ра на пауз≥";
            SetPause(!pauseMenu.activeInHierarchy);
        }
    }

    void LateUpdate()
    {
        int t = (int)time;                   // 3800.123
        int hour = t / 3600;                  // 1
        int minute = (t % 3600) / 60;         // (200) / 60 -> 3
        int second = t % 60;                  // 20
        int ds = (int)((time - t) * 10);   // (0.123)*10 -> 1.23 -> 1
        clock.text = $"{hour:D2}:{minute:D2}:{second:D2}.{ds}"; // 01:03:20.1
    }

    public void OnContinueButtonClick()
    {
        SetPause(false);
    }

    public void SetPause(bool isPaused)
    {
        pauseMenu.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
    }
}
