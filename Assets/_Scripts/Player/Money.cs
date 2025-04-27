using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    int money = 0;

    void Start()
    {
        UpdateUI();
    }

    public void Up(int amount)
    {
        money += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        scoreText.text = "Money : " + money;
    }
}
