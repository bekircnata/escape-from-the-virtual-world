using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAround : MonoBehaviour
{
    [SerializeField] private float spinSpeed = 2f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * spinSpeed * 360);
    }
}
