using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Variable de referencia
    private Rigidbody playerRb;
    private GameObject respawnPoint;
    

    //Variables del movimiento del jugador
    [Header ("Player Stats")]
    public float speed;
    public float jumpForce;
    public bool isGrounded = true;

    //Variables generales del player
    [Header ("Point Manager")]
    public int pointCount = 0;
    [SerializeField] private int maxCount = 5;
    //Variables de referencia de la UI
    [Header ("UI References")]
    public Text pointsText;
    public GameObject winScreen;

    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = GameObject.Find("RespawnPoint");
        playerRb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        CountUptdate();
        GameConditions();
        
    }

    private void FixedUpdate()
    {
        Movement();
    }
    void Movement()
    {
        //Se declaran dos variables locales que almacenen el Input de derecha/izquierda y de arriba/abajo
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        //Declaramos una variable local Vector3 que tendrá como valores X,Z el Input declarado
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        //Aplicamos una fuerza determinada al Rigidbody del player
        playerRb.AddForce(movement * speed, ForceMode.Force);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            
        }
 
    
    }

    void GameConditions()
    {
        if (pointCount == maxCount)
        {
            winScreen.SetActive(true);

        }

        if (transform.position.y <= -30)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        playerRb.velocity = new Vector3(0, 0, 0);
        transform.position = respawnPoint.transform.position;
    }

    void ChangePlayerScaleSmall()
    {
        playerRb.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f); 
    }

    void ChangePlayerScaleBig()
    {
        playerRb.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
    }


    private void OnCollisionEnter(Collision collision)
    {
     if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
     if (collision.gameObject.CompareTag("Wall"))
        {
            Respawn();
            ChangePlayerScaleSmall();
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Has sido eliminado");
            ChangePlayerScaleSmall();
            Respawn();
        }
    }

    void CountUptdate()
    {
        pointsText.text = "Count: " + pointCount.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick_Up"))
        {
            pointCount += 1;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Power_Up"))
        {
            ChangePlayerScaleBig();
        }
    }


}
