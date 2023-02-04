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
    public GameObject LevelManager;
    private LevelTransition levelTransition;
    
    
    public List<GameObject> Papers;
    public GameObject Key;
    public GameObject Lock;
    public GameObject Doors;


    void Start()
    {
        //winScreen.SetActive(false);
        player = GetComponent<Rigidbody2D>();
        //levelTransition = 
    }

    void Update()
    {
        m_Input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
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
         if (collision.gameObject.tag == "Left_Door")
        { 
            levelTransition.LevelSwitch();
        }
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
