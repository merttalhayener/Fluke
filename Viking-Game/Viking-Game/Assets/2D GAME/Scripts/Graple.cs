using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graple : MonoBehaviour
{

    private Vector3 _mousePos;
    private Camera _camera;

    private bool _check;

    private DistanceJoint2D _distanceJoint;

    private LineRenderer _lineRenderer;

    private Vector3 _tempPos;

    public LayerMask grappleMask;
    
    void Start()
    {
        _camera = Camera.main;
        _distanceJoint = GetComponent<DistanceJoint2D>();
        _lineRenderer = GetComponent<LineRenderer>();
        _distanceJoint.enabled = false;
        _check = true;
        _lineRenderer.positionCount = 0;
    }

     
    void Update()
    {
        GetMousePos();
        RaycastHit2D hit2D = Physics2D.Raycast(_camera.transform.position, _mousePos, Mathf.Infinity, grappleMask);
        if (Input.GetMouseButtonDown(0) && _check && hit2D)
        {
            _distanceJoint.enabled = true;
            _distanceJoint.connectedAnchor = _mousePos;
            _lineRenderer.positionCount = 2;
            _tempPos = _mousePos;
            _check = false;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            _distanceJoint.enabled = false;
            _check = true;
            _lineRenderer.positionCount = 0;
        }
        DrawLine();
    }

    private void DrawLine()
    {
        if (_lineRenderer.positionCount <= 0) return;
        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, _tempPos);
    }

    private void GetMousePos()
    {
        _mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
    }
}