using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class jumpButtonScript : MonoBehaviour
{
    private Transform _jumpButton;
    private Vector2 _mousePos;
    private Vector2 _startPosition;
    private float _deltaX, _deltaY;

    public PlayerController pc;
    public static bool isLocked = false;

    void Start()
    {
        _startPosition = transform.position;
    }

    private void OnMouseDown()
    {
        if (!isLocked)
        {
            _deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            _deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }
        if (pc.startGame)
        {
            isLocked = true;
        }
    }

    private void OnMouseDrag()
    {
        if (!isLocked)
        {
            _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(_mousePos.x - _deltaX, _mousePos.y - _deltaY);
        }
        if (pc.startGame)
        {
            isLocked = true;
        }
    }
}
