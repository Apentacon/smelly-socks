using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public GameObject winScreen;
    public GameObject looseScreen;
    private Rigidbody2D player;
    Vector2 m_Input;
    private GameObject levelScript;
    private LevelTransition levelTransition;

    void Start()
    {
        //winScreen.SetActive(false);
        player = GetComponent<Rigidbody2D>();
        levelScript = GameObject.Find("LevelManager");
        levelTransition = levelScript.GetComponent<LevelTransition>();
    }

    void Update()
    {
        m_Input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        player.AddForce(m_Input * Time.deltaTime * moveSpeed);
        //player.velocity = m_Input * moveSpeed * Time.deltaTime;
        if (Input.GetAxisRaw("Horizontal")  == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            //player.velocity = Vector2.zero;
       }
    }

    public void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.gameObject.tag == "Dog")
         {
             winScreen.SetActive(true);
             Time.timeScale = 0;
         }
         if(collision.gameObject.tag == "Doors")
         {
             Debug.Log("NEXT LEVEL");
         }
         if (collision.gameObject.tag == "Laser")
         {
             looseScreen.SetActive(true);
             Time.timeScale = 0;
         }
         else if (collision.gameObject.tag == "Left_Door")
        { 
            levelTransition.LevelSwitch();
            player.velocity = Vector2.zero;
        }
     }
}
