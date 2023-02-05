using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public GameObject looseScreen;
    public GameObject buttonImage;
    private Rigidbody2D player;
    Vector2 m_Input;
    private LevelTransition levelTransition;
    float moveDirectionX;
    float moveDirectionY;
    public GameObject continueText;
    public GameObject speachBubles;
    public GameObject dogBubles;
    public GameObject pauseScreen;
    
    
    public List<GameObject> Papers;
    public GameObject Key;
    public GameObject Lock;
    public GameObject Doors;


    public GameObject u;
    public GameObject i;
    public GameObject o;

    public Image uIm;
    public Image iIm;
    public Image oIm;
    public Image kIm;

    private bool canMove;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        levelTransition = GameObject.Find("LevelManager").GetComponent<LevelTransition>();
        Time.timeScale = 1;
        u.SetActive(false);
        i.SetActive(false);
        o.SetActive(false);
        uIm.enabled = false;
        iIm.enabled = false; 
        oIm.enabled = false;
        kIm.enabled = false;
        speachBubles.SetActive(false);
        continueText.SetActive(true);
        dogBubles.SetActive(false);
        canMove = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            continueText.SetActive(false);
            speachBubles.SetActive(true);
            canMove = true;
        }
        if(canMove)
        {
            if (Input.GetKeyDown(KeyCode.U) && u.activeSelf)
            {
                moveDirectionX = -1;
                uIm.enabled = true;
            }
            else if (Input.GetKeyUp(KeyCode.U) && u.activeSelf)
            {
                moveDirectionX = 0;
            }
            else if (Input.GetKeyDown(KeyCode.O) && o.activeSelf)
            {
                moveDirectionX = 1;
                oIm.enabled = true;
            }
            else if (Input.GetKeyUp(KeyCode.O) && o.activeSelf)
            {
                moveDirectionX = 0;
            }
            else if (Input.GetKeyDown(KeyCode.I) && i.activeSelf)
            {
                moveDirectionY = 1;
                iIm.enabled = true;
            }
            else if (Input.GetKeyUp(KeyCode.I) && i.activeSelf)
            {
                moveDirectionY = 0;
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                moveDirectionY = -1;
                kIm.enabled = true;
            }
            else if (Input.GetKeyUp(KeyCode.K))
            {
                moveDirectionY = 0;
            }
           /* if (Input.GetKeyDown(KeyCode.Escape) && Papers[0].activeSelf)
            {
                Papers[0].SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Escape) && Papers[1].activeSelf)
            {
                Papers[1].SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Escape) && Papers[2].activeSelf)
            {
                Papers[2].SetActive(false);
            }*/
            
        }

        if(pauseScreen.activeSelf)
        {
            canMove = false;
            player.velocity = Vector2.zero;
        } else if(!pauseScreen.activeSelf)
        {
            canMove = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && pauseScreen.activeSelf)
        {
            pauseScreen.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !pauseScreen.activeSelf)
        {
            pauseScreen.SetActive(true);
        }

        m_Input = new Vector2(moveDirectionX, moveDirectionY);
    }

    private void FixedUpdate()
    {
        player.AddForce(m_Input * Time.deltaTime * moveSpeed);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Dog":
                dogBubles.SetActive(true);
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
            case "FinalPaper":
                Papers[3].SetActive(true);
                o.SetActive(true);
                break;
            case "Key":
                Key.SetActive(false);
                Doors.SetActive(true);
                break;
        }
     }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Paper_1":
                Papers[0].SetActive(false);
                break;
            case "Paper_2":
                Papers[1].SetActive(false);
                break;
            case "Paper_3":
                Papers[2].SetActive(false);
                break;
            case "FinalPaper":
                Papers[3].SetActive(false);
                break;
        }
    }
}
