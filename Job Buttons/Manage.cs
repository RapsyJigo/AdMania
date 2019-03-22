using UnityEngine;

public class Manage : MonoBehaviour
{
    public Material mat;

    private void OnMouseUp()
    {
        if (GetComponentInParent<Employee>().Working == false)
        {
            GetComponentInParent<Employee>().Video = false;
            GetComponentInParent<Employee>().Edit = false;
            GetComponentInParent<Employee>().Audio = false;
            GetComponentInParent<Employee>().Manage = true;

            transform.parent.parent.GetComponent<MeshRenderer>().material = mat;
        }
    }
}
