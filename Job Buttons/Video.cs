using UnityEngine;

public class Video : MonoBehaviour
{
    public Material mat;
    private void OnMouseUp()
    {
        if (GetComponentInParent<Employee>().Working == false)
        {
            GetComponentInParent<Employee>().Video = true;
            GetComponentInParent<Employee>().Edit = false;
            GetComponentInParent<Employee>().Audio = false;
            GetComponentInParent<Employee>().Manage = false;

            transform.parent.parent.GetComponent<MeshRenderer>().material = mat;
        }
    }
}
