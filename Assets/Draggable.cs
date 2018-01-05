using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour {
    Vector3 offset;
    private void OnMouseDown()
    {
        Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        point.z = gameObject.transform.position.z;
        offset = transform.position - point;
    }
    void OnMouseDrag()

    {

        Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        point.z = gameObject.transform.position.z;

        gameObject.transform.position = point+offset;
    }
}
