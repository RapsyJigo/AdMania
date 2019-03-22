using UnityEngine;

public class Underling : MonoBehaviour
{
    Employee man;
    RaycastHit hit;

    private void Start()
    {
        man = GetComponentInParent<Employee>();
    }

    private void OnMouseDown()
    {
        Camera.main.GetComponent<PanZoom>().enabled = false;
    }


    private void OnMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
    }

    private void OnMouseUp()
    {
        Camera.main.GetComponent<PanZoom>().enabled = true;
        bool allreadyIn = false;

        if (string.Compare(hit.collider.tag, "Employee") == 0)
        {
            for (int i = 0; i < man.employees.Count; i++)
            {
                if (man.employees[i] == hit.collider.GetComponent<Employee>())
                {
                    allreadyIn = true;
                    i = 999;
                }
            }
            if (allreadyIn == false)
            {
                if (man.employees.Count < (Bonus.Qmanage + 2))
                {
                    if (hit.collider.GetComponent<Employee>() != GetComponentInParent<Employee>())
                    {
                        //add the guy
                        man.employees.Add(hit.collider.GetComponent<Employee>());

                        //set the line
                        drawLine(hit.collider.gameObject);
                    }

                }
            } else
            {
                //remove guy
                man.employees.Remove(hit.collider.GetComponent<Employee>());

                //remove line
                Destroy(hit.collider.GetComponent<LineStick>());
                Destroy(hit.collider.GetComponent<LineRenderer>());
            }
        }
    }
    private void drawLine(GameObject other)
    {
        GradientColorKey[] colorKey;
        Gradient g = new Gradient();
        colorKey = new GradientColorKey[2];
        colorKey[0].color = Color.yellow;
        colorKey[0].time = 0.0f;
        colorKey[1].color = Color.magenta;
        colorKey[1].time = 1.0f;
        g.colorKeys = colorKey;

        other.AddComponent<LineRenderer>();
        other.GetComponent<LineRenderer>().colorGradient = g;
        other.AddComponent<LineStick>();
        other.GetComponent<LineStick>().other = man.gameObject;
    }
}
