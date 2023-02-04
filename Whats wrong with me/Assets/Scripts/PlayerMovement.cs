using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public GameObject winScreen;
    private Rigidbody player;

    void Start()
    {
        winScreen.SetActive(false);
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    /*void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
             transform.position = transform.position + new Vector3(0f, 0f, moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + new Vector3(-moveSpeed * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position + new Vector3(0f, 0f, -moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
        }
    }*/

    private void FixedUpdate()
    {
        Vector3 m_Input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        player.MovePosition(transform.position + m_Input * Time.deltaTime * moveSpeed);
        if (Input.GetAxisRaw("Horizontal")  == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            player.velocity = Vector3.zero;
            player.angularVelocity = Vector3.zero;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dog")
        {
            winScreen.SetActive(true);
            Time.timeScale = 0;
        }
        if(other.gameObject.tag == "Doors")
        {
            Debug.Log("NEXT LEVEL");
        }
    }
}
