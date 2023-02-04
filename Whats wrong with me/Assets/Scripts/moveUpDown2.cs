using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveUpDown2 : MonoBehaviour
{
    public float amp;
    public float freq;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(-0.36f, Mathf.Sin(3.14f + Time.time * freq) * amp, 0);
    }
}
