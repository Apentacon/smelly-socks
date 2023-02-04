using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveUpDown : MonoBehaviour
{
    public float amp;
    public float freq;
    //public float xaxis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // xaxis = -3.14;
        transform.position = new Vector3(-3.14f, Mathf.Sin(Time.time * freq) * amp, 0);
    }
}
