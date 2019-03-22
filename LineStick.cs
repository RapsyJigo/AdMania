using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineStick : MonoBehaviour
{
    public GameObject other;
    private LineRenderer line;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        line.SetPosition(0, gameObject.transform.position);
        line.SetPosition(1, other.transform.position);
    }
}
