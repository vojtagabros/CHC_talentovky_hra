// Include the namespace required to use Unity UI and Input System
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Create public variables for player speed, and for the Text UI game objects
    public float speed;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject Koruna;
    public AudioSource Sound1;
    public AudioSource Sound2;
    public AudioSource Soundtrack;


    public GameObject Death_Wizard { get; private set; }

    private float movementX;
    private float movementY;

    public GameObject[] mizejiciDvere;

    public Vector3 jump;
    public float jumpForce = 2.0f;

    public bool isGrounded;


    private Rigidbody rb;
    private int count;
    private int count_Koruna;
    private bool have_kord;


    // At the start of the game..
    void Start()
    {
        // Assign the Rigidbody component to our private rb variable
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        // Set the count to zero 
        count = 0;
        have_kord = false;

        Koruna = GameObject.FindWithTag ("Koruna");
        Death_Wizard = GameObject.FindWithTag ("Kill");
       

        // Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
        winTextObject.SetActive(false);

    }

    void FixedUpdate()
    {
        // Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);

    }

    void OnTriggerEnter(Collider other)
    {

        //koblihy
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            Sound1.Play();
            SetCountText();
            
            //při získání všech koblih - otevření velkých dveří
            if (count >= 5)
            {
                //najdi objekt Level 1 a nech ho zmizet
                mizejiciDvere = GameObject.FindGameObjectsWithTag("Level1");
                foreach (GameObject dvere in mizejiciDvere)
                {
                    dvere.SetActive(false);
                }
           
            }

        }

        //zmizení textu na velkých dveřích
        if (other.gameObject.CompareTag("Zmizet"))
        {
            other.gameObject.SetActive(false);
        }

        //sebrání kordu
        if (other.gameObject.CompareTag("PickUp1"))
        {
            other.gameObject.SetActive(false);
            have_kord = true;
            KortX();

        }

        //smrt death wizarda
        if (other.gameObject.CompareTag("Kill"))
        {
            if (have_kord)
            {
                other.gameObject.SetActive(false);
                Time.timeScale = 0f;
                SetWinText();               
                Soundtrack.Stop();
                Sound2.Play();

            }
        }


    } 

    
    //pohyb kuličky z tutorialu
    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();

        movementX = v.x;
        movementY = v.y;
    }

    //zobrazení počtu koblih
    void SetCountText()
    {
        countText.text = "Počet koblih: " + count.ToString() + "/5";
    }

    //zobrazení velkého, červeného KONEC
    void SetWinText()
    {
          winTextObject.SetActive(true);
    }

    
    void KortX ()
    {
        countText.text ="máš meč!";
    }
    
    //kód ze StackOverflow pro skákání
    void OnCollisionStay()
    {
        isGrounded = true;
    }

    //kód ze StackOverflow pro skákání
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

       
    }

}