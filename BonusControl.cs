using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusControl : MonoBehaviour
{

    public  void VideoAdd(int percent)
    {
        Bonus.video = Bonus.video + (float)(percent / 100);
    }
    public  void AudioAdd(int percent)
    {
        Bonus.audio = Bonus.audio + (float)(percent / 100);
    }
    public  void EditAdd(int percent)
    {
        Bonus.edit = Bonus.edit + (float)(percent / 100);
    }
    public  void ManageAdd(int percent)
    {
        Bonus.manage = Bonus.manage + (float)(percent / 100);
    }

    //add ammount of workers
    public  void ManageQuantity(int ammount)
    {
        Bonus.Qmanage = Bonus.Qmanage + ammount;
    }

    public  void StressAdd(int percent)
    {
        Bonus.stress = Bonus.stress + (float)(percent / 100);
    }
    public  void FireAdd(int percent)
    {
        Bonus.fire = Bonus.fire + (float)(percent / 100);
    }
    public  void PenaltyAdd(int percent)
    {
        Bonus.penalty = Bonus.penalty + (float)(percent / 100);
    }
    public  void PaymentAdd(int percent)
    {
        Bonus.payment = Bonus.payment + (float)(percent / 100);
    }
    public  void RateAdd(int percent)
    {
        Bonus.rate = Bonus.rate + (float)(percent / 100);
    }
}
