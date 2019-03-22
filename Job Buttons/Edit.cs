using UnityEngine;

public class Edit : MonoBehaviour
{
    public Material mat;

    private void OnMouseUp()
    {
        if (GetComponentInParent<Employee>().Working == false)
        {
            GetComponentInParent<Employee>().Edit = true;
            GetComponentInParent<Employee>().Video = false;
            GetComponentInParent<Employee>().Audio = false;
            GetComponentInParent<Employee>().Manage = false;

            transform.parent.parent.GetComponent<MeshRenderer>().material = mat;
        }
    }
}
