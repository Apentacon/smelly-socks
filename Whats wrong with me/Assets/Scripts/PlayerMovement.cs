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
    private GameObject levelScript;
    private LevelTransition levelTransition;
    private float moveDirectionX;
    private float moveDirectionY;

    void Start()
    {
        looseScreen.SetActive(false);
        buttonImage.SetActive(true);
        player = GetComponent<Rigidbody2D>();
        levelScript = GameObject.Find("LevelManager");
        levelTransition = levelScript.GetComponent<LevelTransition>();
        Time.timeScale = 1;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            moveDirectionX = -1;
        }
        else if (Input.GetKeyUp(KeyCode.K))
        {
            moveDirectionX = 0;
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            moveDirectionX = 1;
        }
        else if (Input.GetKeyUp(KeyCode.P))
        {
            moveDirectionX = 0;
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            moveDirectionY = 1;
        }
        else if (Input.GetKeyUp(KeyCode.M))
        {
            moveDirectionY = 0;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            moveDirectionY = -1;
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            moveDirectionY = 0;
        }

        m_Input = new Vector2(moveDirectionX, moveDirectionY);
    }

    private void FixedUpdate()
    {
        player.AddForce(m_Input * Time.deltaTime * moveSpeed);
        if (moveDirectionX == 0 && moveDirectionY == 0)
        {
            //player.velocity = Vector2.zero;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dog")
        {
        Time.timeScale = 0;
        }
        if(collision.gameObject.tag == "Doors")
        {
        Debug.Log("NEXT LEVEL");
        }
        if (collision.gameObject.tag == "Laser")
        {
        looseScreen.SetActive(true);
        buttonImage.SetActive(false);
        Time.timeScale = 0;
        }
        else if (collision.gameObject.tag == "Left_Door")
        { 
            levelTransition.LevelSwitch();
            player.velocity = Vector2.zero;
        }
    }
}
