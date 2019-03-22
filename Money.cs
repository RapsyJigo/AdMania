using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Money : MonoBehaviour
{
    public int money;
    private TextMeshProUGUI display;

    void Start()
    {
        display = GetComponent<TextMeshProUGUI>();
        display.text = "Money: " + money.ToString();
    }

    public void buy(int ammount)
    {
        if (money + ammount >= 0)
        {
            money -= ammount;
            display.text = "Money: " + money.ToString();
        }
    }
}