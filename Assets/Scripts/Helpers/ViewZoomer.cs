using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ScreenBounds))]
public class ViewZoomer : MonoBehaviour
{
    [SerializeField]
    float targetZoom;

    ScreenBounds bounds;

    private void Awake()
    {
        bounds = GetComponent<ScreenBounds>();
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

    public void SetZoomTarget(float target)
    {
        targetZoom = target;
        if(targetZoom < 1f)
            targetZoom = 1f;
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
