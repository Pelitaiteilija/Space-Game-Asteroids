using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ScreenBounds))]
public class ViewZoomer : MonoBehaviour
{
    [SerializeField]
    float targetZoom;

    [SerializeField]
    ViewZoomerSO viewZoomerSO;

    private float minimumZoom, maximumZoom;
    ScreenBounds bounds;

    private void Awake()
    {
        bounds = GetComponent<ScreenBounds>();
        if (viewZoomerSO == null) { 
            Debug.LogError("ViewZoomer is missing a viewZoomerSO object!");
            minimumZoom = 1f;
            maximumZoom = 20f;
        }
        else
        {
            minimumZoom = viewZoomerSO.minimumZoom;
            maximumZoom = viewZoomerSO.maximumZoom;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        targetZoom = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        float orthoSize = Camera.main.orthographicSize;

        // inputs
        HandleManualzoom();

        // if floats are the same, return
        if (orthoSize == targetZoom)
            return;

        orthoSize = Mathf.Lerp(orthoSize, targetZoom, Time.deltaTime);

        if (Mathf.Abs(targetZoom - orthoSize) < 0.01f)
        {
            orthoSize = targetZoom;
        }

        Camera.main.orthographicSize = orthoSize;
        bounds.UpdateBoundsSize();
    }

    public void ChangeZoomTarget(float target)
    {
        SetZoomTarget(targetZoom + target);
    }

    public void SetZoomTarget(float target)
    {
        targetZoom = target;
        // make sure value stays within constraints
        targetZoom = Mathf.Min(maximumZoom, targetZoom);
        targetZoom = Mathf.Max(minimumZoom, targetZoom);
    }

    private void HandleManualzoom()
    {
        if (Input.GetKey(KeyCode.Plus) || Input.GetKey(KeyCode.KeypadPlus))
        {
            SetZoomTarget(targetZoom - (1f * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.Minus) || Input.GetKey(KeyCode.KeypadMinus))
        {
            SetZoomTarget(targetZoom + (1f * Time.deltaTime));
        }
    }
}
