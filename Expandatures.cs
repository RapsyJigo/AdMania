using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Expandatures : MonoBehaviour
{
    private TextMeshProUGUI text;
    private int second;
    private int ammount = 0;
    public GameObject money;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        StartCoroutine(spend());
    }

    IEnumerator spend ()
    {
        while (true)
        {
            second = 60;
            while (second > 0)
            {
                yield return new WaitForSeconds(1);
                second--;
            }
            money.GetComponent<TextMeshProUGUI>().text = "Money: " + (money.GetComponent<Money>().money - ammount).ToString();
            money.GetComponent<Money>().money = money.GetComponent<Money>().money - ammount;
        }
    }

    public int GetSecond ()
    {
        return second;
    }

    public void AddAmmount (int q)
    {
        ammount = q + ammount;
        text.text = "-" + ammount.ToString();
    }
}
