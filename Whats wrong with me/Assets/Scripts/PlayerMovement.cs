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
    private LevelTransition levelTransition;
    private float moveDirectionX;
    private float moveDirectionY;

    public GameObject u;
    public GameObject i;
    public GameObject o;

    void Start()
    {
        looseScreen.SetActive(false);
        buttonImage.SetActive(true);
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
        }
    }
}
