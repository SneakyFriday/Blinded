using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class timeButtonScript : MonoBehaviour
{
    private Transform timeButton;
    private Vector2 mousePos;
    private Vector2 startPosition;
    private float deltaX, deltaY;

    public static bool isLocked = false;

    void Start()
    {
        startPosition = transform.position;
    }

    private void OnMouseDown()
    {
        if (!isLocked)
        {
            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }
    }

    private void OnMouseDrag()
    {
        if (!isLocked)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePos.x - deltaX, mousePos.y - deltaY);
        }
    }
}
