using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public GameObject looseScreen;
    public GameObject buttonImage;
    private Rigidbody2D player;
    Vector2 m_Input;
    public GameObject LevelManager;
    private LevelTransition levelTransition;
    float moveDirectionX;
    float moveDirectionY;
    
    
    public List<GameObject> Papers;
    public GameObject Key;
    public GameObject Lock;
    public GameObject Doors;


    public GameObject u;
    public GameObject i;
    public GameObject o;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        levelTransition = GameObject.Find("LevelManager").GetComponent<LevelTransition>();
        Time.timeScale = 1;
        u.SetActive(false);
        i.SetActive(false);
        o.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U) && u.activeSelf)
        {
            moveDirectionX = -1;
        }
        else if (Input.GetKeyUp(KeyCode.U) && u.activeSelf)
        {
            moveDirectionX = 0;
        }
        else if (Input.GetKeyDown(KeyCode.O) && o.activeSelf)
        {
            moveDirectionX = 1;
        }
        else if (Input.GetKeyUp(KeyCode.O) && o.activeSelf)
        {
            moveDirectionX = 0;
        }
        else if (Input.GetKeyDown(KeyCode.I) && i.activeSelf)
        {
            moveDirectionY = 1;
        }
        else if (Input.GetKeyUp(KeyCode.I) && i.activeSelf)
        {
            moveDirectionY = 0;
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            moveDirectionY = -1;
        }
        else if (Input.GetKeyUp(KeyCode.K))
        {
            moveDirectionY = 0;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && Papers[0].activeSelf)
        {
            Papers[0].SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && Papers[1].activeSelf)
        {
            Papers[1].SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Escape) && Papers[2].activeSelf)
        {
            Papers[2].SetActive(false);
        }

        m_Input = new Vector2(moveDirectionX, moveDirectionY);
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
        switch (collision.gameObject.tag)
        {
            case "Dog":
                Time.timeScale = 0;
                break;
            case "Doors":
                Debug.Log("NEXT LEVEL");
                break;
            case "Laser":
                looseScreen.SetActive(true);
                buttonImage.SetActive(false);
                Time.timeScale = 0;
                break;
            case "Left_Door":
                levelTransition.LevelSwitch();
                player.velocity = Vector2.zero;
                break;
            case "Paper_1":
                Papers[0].SetActive(true);
                u.SetActive(true);
                break;
            case "Paper_2":
                Papers[1].SetActive(true);
                i.SetActive(true);
                break;
            case "Paper_3":
                Papers[2].SetActive(true);
                o.SetActive(true);
                break;
            case "Key":
                Key.SetActive(false);
                break;
            case "Lock":
                Lock.SetActive(false);
                Doors.SetActive(true);
                break;
        }
         /*if (collision.gameObject.tag == "Lock" && !Lock.activeSelf)
         { 
             Lock.SetActive(false);
             Doors.SetActive(true);
         }*/
     }
}
