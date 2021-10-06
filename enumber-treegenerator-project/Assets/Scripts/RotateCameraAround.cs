using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraAround : MonoBehaviour
{
    [SerializeField] private GameObject m_Camera;
    [SerializeField] private float m_Speed;
    
    private void Update()
    {
        m_Camera.transform.RotateAround(transform.position, Vector3.up, m_Speed * Time.deltaTime);
    }
}
