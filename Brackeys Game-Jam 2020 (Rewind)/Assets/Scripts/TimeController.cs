using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public bool isRewinding = false;
    public float startTime;
    public Text rewindTime;

    List<Vector2> positions;
    void Start()
    {
        positions = new List<Vector2>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // startTime += Time.deltaTime;
            StartRewind();
            // rewindTime.text = string.Format("Rewind-Time: {0,2} sec.", startTime);
            
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopRewind();

        }
    }

    private void FixedUpdate()
    {
        if (isRewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        }
    }

    void Record()
    {
        positions.Insert(0, transform.position);
    }

    void Rewind()
    {
        if (positions.Count > 0)
        {
            transform.position = positions[0];
            positions.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }

    }

    public void StartRewind()
    {
        isRewinding = true;
    }

    public void StopRewind()
    {
        isRewinding = false;
    }
}
