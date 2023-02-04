using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveUpDown2 : MonoBehaviour
{
    public float amp;
    public float freq;
    private Vector3 startPosition;
    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPosition + transform.up * Mathf.Sin(Time.time * freq + offset) * amp;
    }
}
