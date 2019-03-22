using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateJob : MonoBehaviour
{
    public GameObject job;
    private Money mon;

    private void Start()
    {
        mon = GameObject.Find("Money").GetComponent<Money>();
    }

    private float timeBias;
    public void setBias (float bias)
    {
        timeBias = bias;
    }
    public void Create (int ammountBias) //mon.GetLevel() is the current difficulty (progresses automaticaly)
    {
        GameObject t = Instantiate(job,transform);

        Assign j = t.GetComponent<Assign>();

        t.GetComponent<Assign>().audioAmmount = (int)((ammountBias) * Random.Range(0.5f, 1.5f));
        j.editAmmount = (int)((ammountBias) * Random.Range(0.5f, 1.5f));
        j.videoAmmount = (int)((ammountBias) * Random.Range(0.5f, 1.5f));

        j.audioTime = (timeBias) * Random.Range(1f, 3f);
        j.editTime = (timeBias) * Random.Range(1f, 3f);
        j.videoTime = (timeBias) * Random.Range(1f, 3f);


        j.payment = (int)((10 + j.audioAmmount*j.audioTime + j.editAmmount*j.editTime + j.videoAmmount*j.videoTime) * Random.Range(0.5f, 1.5f) * ((timeBias + ammountBias)/10) * Bonus.payment);
        j.penalty = (j.audioAmmount * j.audioTime + j.editAmmount * j.editTime + j.videoAmmount * j.videoTime) * 4;
    }
}
