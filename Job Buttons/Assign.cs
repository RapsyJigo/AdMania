using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Assign : MonoBehaviour, IDragHandler , IPointerUpHandler , IPointerDownHandler
{
    private Money money;

    public int audioAmmount;
    public float audioTime;

    public int videoAmmount;
    public float videoTime;

    public int editAmmount;
    public float editTime;

    public int payment;
    public float penalty; //time after witch payment gets deducted and job lost

    RaycastHit hit;

    private TextMeshProUGUI video, straudio, edit, cash, penaltycountdown;

    private void Start()
    {
        money = GameObject.Find("Money").GetComponent<Money>();

        video = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        straudio = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        edit = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        cash = transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        penaltycountdown = transform.GetChild(4).GetComponent<TextMeshProUGUI>();

        video.text = "Video: " + videoAmmount.ToString() + "*" + videoTime.ToString("F2");
        straudio.text = "Audio: " + audioAmmount.ToString() + "*" + audioTime.ToString("F2");
        edit.text = "Edit: " + editAmmount.ToString() + "*" + editTime.ToString("F2");
        cash.text = "Payment: " + payment.ToString();

        InvokeRepeating("countdown", 0.0f, 1.0f);
    }

    public void OnDrag(PointerEventData eventData)
    {
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         Physics.Raycast(ray, out hit);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (string.Compare(hit.collider.tag, "Employee") == 0)
        {
            Employee emp = hit.collider.GetComponent<Employee>();

            if (emp.Audio == true && emp.Working == false && audioAmmount > 0)
            {
                assignAudio(emp);
            }
            else
            if (emp.Edit == true && emp.Working == false && editAmmount > 0)
            {
                assignEdit(emp);
            }
            else
            if (emp.Video == true && emp.Working == false && videoAmmount > 0)
            {
                assignVideo(emp);
            }
            else
            if (emp.Manage == true)
            {
                StartCoroutine(emp.manageExecute(this.gameObject));
            }
        }

        Camera.main.GetComponent<PanZoom>().enabled = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Camera.main.GetComponent<PanZoom>().enabled = false;
    }

    public void assignAudio (Employee emp)
    {
        emp.workAudio(audioTime);
        audioAmmount--;
        straudio.text = "Audio: " + audioAmmount.ToString() + "*" + audioTime.ToString("F2");
        checkPay();
    }

    public void assignEdit (Employee emp)
    {
        emp.workEdit(editTime);
        editAmmount--;
        edit.text = "Edit: " + editAmmount.ToString() + "*" + editTime.ToString("F2");
        checkPay();
    }

    public void assignVideo (Employee emp)
    {
        emp.workVideo(videoTime);
        videoAmmount--;
        video.text = "Video: " + videoAmmount.ToString() + "*" + videoTime.ToString("F2");
        checkPay();
    }

    public void checkPay ()
    {
        if (audioAmmount == 0 && videoAmmount == 0 && editAmmount == 0)
        {
            Camera.main.GetComponent<PanZoom>().enabled = true;
            money.buy(-payment);
            Destroy(this.gameObject);
        }
    }

    private int t = 0;
    private void countdown ()
    {
        penaltycountdown.text = ((int)(t / 60)).ToString() + ":" + ((int)(t % 60)).ToString() + "/" + ((int)(penalty/60)).ToString() + ":" + ((int)(penalty%60)).ToString();
        t++;
        if (t>penalty)
        {
            money.buy((int)(payment * Bonus.penalty));
            Destroy(gameObject);
        }
    }
}
