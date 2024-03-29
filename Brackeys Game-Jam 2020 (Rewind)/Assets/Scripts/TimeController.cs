﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public bool isRewinding = false;
    public float startTime;
    public Text rewindTime;
    private Slider slider;
    private float timeFuel;
    public float fillSpeed = 0.5f;
    private ParticleSystem particleSys;

    List<Vector2> positions;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        particleSys = GameObject.Find("Particels").GetComponent<ParticleSystem>();
    }

    void Start()
    {
        positions = new List<Vector2>();
        IncrementTimeFuel(0.75f);
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

        if (slider.value < timeFuel)
        {
            slider.value += fillSpeed * Time.deltaTime;
            if (!particleSys.isPlaying)
            {
                particleSys.Play();
            }
        }
        else
        {
            particleSys.Stop();
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

    public void IncrementTimeFuel(float newTimeFuel)
    {
        timeFuel = slider.value + newTimeFuel;
    }
}
