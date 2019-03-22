using UnityEngine;

public class Audio : MonoBehaviour
{
    public Material mat;

    private void OnMouseUp()
    {
        if (GetComponentInParent<Employee>().Working == false)
        {
            GetComponentInParent<Employee>().Audio = true;
            GetComponentInParent<Employee>().Video = false;
            GetComponentInParent<Employee>().Edit = false;
            GetComponentInParent<Employee>().Manage = false;

            transform.parent.parent.GetComponent<MeshRenderer>().material = mat;
        }
    }
}
