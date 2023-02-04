using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIManager : MonoBehaviour
{
    public List<GameObject> Papers;
    public GameObject Key;
    public GameObject Lock;
    public GameObject Doors;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && Papers[1].activeSelf)
        {
            Papers[1].SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Escape) && Papers[2].activeSelf)
        {
            Papers[2].SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Escape) && Papers[3].activeSelf)
        {
            Papers[3].SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Paper_1")
        {
            Papers[1].SetActive(true);
        }
        if(collision.gameObject.tag == "Paper_2")
        {
            Papers[2].SetActive(true);
        }
        if (collision.gameObject.tag == "Paper_3")
        {
            Papers[3].SetActive(true);
        }
        if (collision.gameObject.tag == "Key")
        { 
            Key.SetActive(false);
        }
        if (collision.gameObject.tag == "Lock" && !Lock.activeSelf)
        { 
            Lock.SetActive(false);
            Doors.SetActive(true);
        }
    }
    
}
