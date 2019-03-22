using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GenerateEmployee : MonoBehaviour
{
    public GameObject place;
    public GameObject employee;

    public Expandatures exp;
    private TextMeshProUGUI text;

    private struct empStats
    {
        public float edit { get; set; }
        public float manage { get; set; }
        public float video { get; set; }
        public float audio { get; set; }
        public int salary { get; set; }
    }

    private void Start()
    {
        text = place.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        StartCoroutine("change");
    }

    empStats[] emp = new empStats[3];

    IEnumerator change ()
    {
        int i = 180;
        while (true)
        {
            for (i = 0; i < 3; i++)
            {
                emp[i].edit = Bonus.tier * Random.Range((0.25f), (0.75f));
                emp[i].video = Bonus.tier * Random.Range((0.25f), (0.75f));
                emp[i].audio = Bonus.tier * Random.Range((0.25f), (0.75f));
                emp[i].manage = Bonus.tier * Random.Range((0.25f), (0.75f));

                emp[i].salary = (int)(emp[i].edit + emp[i].video + emp[i].audio + emp[i].manage + 1) * 13;

                place.transform.GetChild(1).GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Video: " + emp[i].video.ToString("F3");
                place.transform.GetChild(1).GetChild(i).GetChild(1).GetComponent<TextMeshProUGUI>().text = "Audio: " + emp[i].audio.ToString("F3");
                place.transform.GetChild(1).GetChild(i).GetChild(2).GetComponent<TextMeshProUGUI>().text = "Edit: " + emp[i].edit.ToString("F3");
                place.transform.GetChild(1).GetChild(i).GetChild(3).GetComponent<TextMeshProUGUI>().text = "Manage: " + emp[i].manage.ToString("F3");
                place.transform.GetChild(1).GetChild(i).GetChild(4).GetComponent<TextMeshProUGUI>().text = "Salary: " + emp[i].salary.ToString();

                place.transform.GetChild(1).GetChild(i).GetComponent<Button>().interactable = true;
            }
            i = 180;
            while (i > 0)
            {
                yield return new WaitForSeconds(1);
                i--;
                text.text = (i / 60).ToString() + ":" + (i % 60).ToString();
            }
        }
    }
    public void deployEmployee (int chosen)
    {
        place.transform.GetChild(1).GetChild(chosen).GetComponent<Button>().interactable = false;
        GameObject newEmp;
        newEmp = Instantiate(employee);
        newEmp.GetComponent<Employee>().Set(emp[chosen].video, emp[chosen].audio, emp[chosen].edit, emp[chosen].manage,emp[chosen].salary);
        exp.AddAmmount(emp[chosen].salary);

    }
}
