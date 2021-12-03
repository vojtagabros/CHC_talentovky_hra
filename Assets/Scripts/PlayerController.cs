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

    public GameObject Death_Wizard { get; private set; }

    public TextMeshProUGUI Kort;

    private float movementX;
    private float movementY;



    public Vector3 jump;
    public float jumpForce = 2.0f;

    public bool isGrounded;

    public bool RotateAroundPlayer = true;

    public float RotationSpeed = 5.0f;

    private Rigidbody rb;
    private int count;
    private int count_Koruna;
    private int count_kort;


    // At the start of the game..
    void Start()
    {
        // Assign the Rigidbody component to our private rb variable
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        // Set the count to zero 
        count = 0;
        count_kort = 0;

        
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

        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            count = count + 1;


            SetCountText();

        }

        
        if (other.gameObject.CompareTag("Zmizet"))
        {
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Koruna"))
        {
            other.gameObject.SetActive(false);

            count_Koruna = count_Koruna + 1;

            SetWinText();
        }
        if (other.gameObject.CompareTag("Level1"))
        {
            if (count >= 5)
            {
                other.gameObject.SetActive(false);
            }
        }

        if (other.gameObject.CompareTag("PickUp1"))
        {
            other.gameObject.SetActive(false);

            count_kort = count_kort + 1;
            
            KortX();

        }

        if (other.gameObject.CompareTag("Kill"))
        {
            if (count_kort >= 1)
            {
                other.gameObject.SetActive(false);
            }
        }


    } 
    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();

        movementX = v.x;
        movementY = v.y;
    }

    void SetCountText()
    {
        countText.text = "Coblich Count: " + count.ToString() + "/5";
    }

    void SetWinText()
    {
        


        if (count_Koruna >= 1)
        {
            winTextObject.SetActive(true);

        }
    }

     void KortX ()
    {
        countText.text ="máš meč!";
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }




}