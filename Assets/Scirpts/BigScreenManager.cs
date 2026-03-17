using UnityEngine;
using TMPro;

public class BigScreenManager : MonoBehaviour
{
    public static BigScreenManager Instance;

    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI MineCounterText;

    private float timer = 0f;
    private int totalMines;
    private int flagsPlaced = 0;

    void Awake() { Instance = this; }

    // Gọi hàm này khi bắt đầu ván mới
    public void SetupScreen(int mines)
    {
        totalMines = mines;
        flagsPlaced = 0;
        timer = 0f;
        UpdateMineText();
        UpdateTimerText();
    }

    void Update()
    {
        // Thời gian chỉ chạy khi đã click lần đầu và chưa Game Over
        if (GameManager.Instance != null && GameManager.Instance.FirstClick && !GameManager.Instance.GameOver)
        {
            timer += Time.deltaTime;
            UpdateTimerText();
        }
    }

    // Gọi hàm này khi cắm hoặc rút cờ
    public void AddFlag(bool isAdding)
    {
        if (isAdding) flagsPlaced++;
        else flagsPlaced--;
        UpdateMineText();
    }

    void UpdateMineText()
    {
        if (MineCounterText != null)
        {
            int remaining = totalMines - flagsPlaced;
            MineCounterText.text = "Mines: " + remaining.ToString();
        }
    }

    void UpdateTimerText()
    {
        if (TimerText != null)
        {
            int minutes = Mathf.FloorToInt(timer / 60F);
            int seconds = Mathf.FloorToInt(timer - minutes * 60);
            TimerText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
        }
    }
}