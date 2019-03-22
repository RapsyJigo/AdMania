using UnityEngine;
using System.Collections;

public class MoveEmployees : MonoBehaviour
{
    public GameObject line;
    private int index = -1;

    public static bool active = true;

    bool move = false;
    bool clicked = false;

    public void activate (bool state)
    {
        active = state;
    }

    public void SetIndex (int i)
    {
        index = i;
    }

    private void OnMouseDown()
    {
        if (active)
        {
            if (clicked == true)
            {
                GameObject.Find("Expendatures").GetComponent<Expandatures>().AddAmmount(-gameObject.GetComponent<Employee>().salary);
                GameObject.Find("Money").GetComponent<Money>().buy(-(gameObject.GetComponent<Employee>().salary * (GameObject.Find("Expendatures").GetComponent<Expandatures>().GetSecond())/60));
                Destroy(gameObject);
            }
            clicked = true;
            move = false;
            StartCoroutine("hold");
            Camera.main.GetComponent<PanZoom>().enabled = false;
        }
    }
    private void OnMouseDrag()
    {
        if (active)
        {
            if (move == true)
            {
                Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                Vector2 objPos = Camera.main.ScreenToWorldPoint(mousePos);

                Vector3 place = new Vector3(objPos.x, objPos.y, 400);

                transform.position = place;
            }
        }
    }
    private void OnMouseUp()
    {
        if (active)
        {
            Camera.main.GetComponent<PanZoom>().enabled = true;
            if (move == false)
            {
                transform.GetChild(0).gameObject.SetActive(!transform.GetChild(0).gameObject.active);
            }
        }
    }

    IEnumerator hold ()
    {
        yield return new WaitForSeconds(0.3f);
        clicked = false;
        if (Input.GetMouseButton(0))
            move = true;
    }
}
