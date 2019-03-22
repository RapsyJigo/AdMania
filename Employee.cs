using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Employee : MonoBehaviour
{
    public Money money;

    public bool Video;
    public bool Audio;
    public bool Edit;
    public bool Manage;

    public bool Working = false;

    private float videoSkill=1.0f;
    private float audioSkill=1.0f;
    private float editSkill=1.0f;
    private float manageSkill=1.0f;

    public List<Employee> employees = new List<Employee>();

    private float rest = 1; //Value that reprezents tiredness of employee lower more tired higher less tired
    public int salary;

    private void Start()
    {
        transform.GetChild(0).GetChild(0).GetComponent<TextMeshPro>().text = rest.ToString();
        transform.GetChild(0).GetChild(1).GetChild(1).GetComponent<TextMeshPro>().text = videoSkill.ToString();
        transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<TextMeshPro>().text = audioSkill.ToString();
        transform.GetChild(0).GetChild(3).GetChild(1).GetComponent<TextMeshPro>().text = editSkill.ToString();
        transform.GetChild(0).GetChild(4).GetChild(1).GetComponent<TextMeshPro>().text = manageSkill.ToString();

        Debug.Log(videoSkill.ToString() + " " + audioSkill.ToString() + " " + editSkill.ToString() + " " + manageSkill.ToString());
    }

    public void Set(float vS, float aS, float eS, float mS, int s)
    {
        videoSkill = vS;
        audioSkill = aS;
        editSkill = eS;
        manageSkill = mS;
        salary = s;
    }

    public void workVideo (float expectedTime)
    {
        StartCoroutine ("execute",(expectedTime / (videoSkill * Bonus.video * rest)));
        videoSkill = videoSkill * (1 + (expectedTime / (videoSkill * rest)) / 1500) * Bonus.rate;
    }
    public void workAudio (float expectedTime)
    {
        StartCoroutine("execute", (expectedTime / (audioSkill * Bonus.audio * rest)));
        audioSkill = audioSkill * (1 + (expectedTime / (audioSkill * rest)) / 1500) * Bonus.rate;
    }
    public void workEdit (float expectedTime)
    {
        StartCoroutine("execute", (expectedTime / (editSkill * Bonus.edit * rest)));
        editSkill = editSkill * (1 + (expectedTime / (editSkill * rest)) / 1500) * Bonus.rate;
    }
    public IEnumerator manageExecute (GameObject job)
    {
        Assign j = job.GetComponent<Assign>();
        Working = true;
        while (j.videoAmmount > 0 || j.audioAmmount > 0 || j.editAmmount > 0)
        {
            bool gavejob = false;
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Edit == true && employees[i].Working == false && j.editAmmount > 0)
                {
                    j.assignEdit(employees[i]);

                    gavejob = true;
                }
                else
                if (employees[i].Video == true && employees[i].Working == false && j.videoAmmount > 0)
                {
                    j.assignVideo(employees[i]);

                    gavejob = true;
                }
                else
                if (employees[i].Audio == true && employees[i].Working == false && j.audioAmmount > 0)
                {
                    j.assignAudio(employees[i]);

                    gavejob = true;
                }
                if (gavejob == true)
                {
                    float t = 5f / manageSkill * Bonus.manage;
                    while (t > 0)
                    {
                        transform.GetChild(1).GetComponent<TextMeshPro>().text = ((int)(t / 60)).ToString() + ":" + ((int)(t % 60)).ToString();
                        yield return new WaitForSeconds(1);
                        t = t - 1f;
                    }
                }
            }
            if (gavejob == false)
            {
                manageSkill = manageSkill * (1 + ((j.videoTime + j.audioTime + j.editTime) / (manageSkill * rest)) / 4500) * Bonus.rate;
                salary = (int)(editSkill * videoSkill * manageSkill * audioSkill * 5);
                rest = rest * (1 - ((j.videoAmmount + j.audioAmmount + j.editAmmount) * manageSkill / 4500)) * Bonus.stress;
                Working = false;
                transform.GetChild(0).GetChild(4).GetChild(1).GetComponent<TextMeshPro>().text = manageSkill.ToString();

                yield break;
            }
        }
    }
    
    IEnumerator execute (float time)
    {
        Working = true;
        float t = time;
        while (t > 0)
        {
            transform.GetChild(1).GetComponent<TextMeshPro>().text = ((int)(t / 60)).ToString() + ":" + ((int)(t % 60)).ToString();
            yield return new WaitForSeconds(1);
            t = t-1f;
        }
        rest = rest * (1 - (time / 1500)) * Bonus.stress;
        salary = (int)(editSkill * videoSkill * manageSkill * audioSkill * 5);
        transform.GetChild(0).GetChild(0).GetComponent<TextMeshPro>().text = rest.ToString();
        transform.GetChild(0).GetChild(1).GetChild(1).GetComponent<TextMeshPro>().text = videoSkill.ToString();
        transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<TextMeshPro>().text = audioSkill.ToString();
        transform.GetChild(0).GetChild(3).GetChild(1).GetComponent<TextMeshPro>().text = editSkill.ToString();
        Working = false;
    }


}
