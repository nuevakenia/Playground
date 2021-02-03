using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float velocidad;
    public Text txtContador;
    public Text winText;
    public Text txtHp;

    private Rigidbody rb;
    private int contador;

    // Salto

    private float jumpSpeed = 5;
    private bool onGround = true;
    private const int maxJump = 2;
    public int currentJump = 0;
    public float hpPlayer;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       // hp = GameObject.Find("Enemigo").GetComponent<Enemy>().health;
        contador = 0;
        UpdatePuntaje();
        //winText.text = "";

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") && (onGround || maxJump > currentJump))
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            onGround = false;
            currentJump++;
        }
    }

  

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * velocidad);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            contador = contador + 1;
            UpdatePuntaje();
        }
       
    }

    void UpdatePuntaje()
    {
        txtContador.text = "Puntaje: " + contador.ToString();
        if (contador >= 9)
        {
            winText.text = "Ganaste!";
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);
        onGround = true;
        currentJump = 0;


        if (collision.gameObject.CompareTag("Enemigo"))
        {
            hpPlayer -= 25;
           // Destroy(collision.gameObject);
            Debug.Log("Me pegooo");
            UpdateHp();
        }

    }

    public void TakeDamage(int damage)
    {
      //  hpPlayer -= damage;
       // UpdateHp();
    //    if (hpPlayer <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }

    void UpdateHp()
    {
        txtHp.text = "HP: " + hpPlayer.ToString();
        if (hpPlayer <= 0)
        {
            //
            Debug.Log("Estas muerto!");
            winText.text = "ESTAS MUERTO";
        }
    }
}
