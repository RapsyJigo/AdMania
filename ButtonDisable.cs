using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDisable : MonoBehaviour
{
    Money mon;
    public int price;

    private void Start()
    {
        mon = GameObject.Find("Money").GetComponent<Money>();
    }
    private void Update()
    {
        gameObject.GetComponent<Button>().interactable = (mon.money > price);
    }
    public void done ()
    {
        Destroy(gameObject);
    }

}
