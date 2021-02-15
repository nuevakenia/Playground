using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // velocidad
    public float moveSpeed;
    public float walkSpeed;
    public float runSpeed;
    public float rotSpeed;

    private float rot = 0f;

    Vector3 moveDirection ;
    Vector3 velocity;

    // Character
    CharacterController controller;
    private Animator mAnimator;
    private Animator anim;

    private Rigidbody rb;
    private int contador;

    // Texto
    public Text txtContador;
    public Text winText;
    public Text txtHp;

    // Salto

    //[SerializeField] private float jumpSpeed = 5;
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float jumpHeight;

    public float gravity;

    private const int maxJump = 2;
    public int currentJump = 0;
    public float hpPlayer;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        mAnimator = GetComponent<Animator>();
        anim = GetComponentInChildren<Animator>();

        rb = GetComponent<Rigidbody>();
        
        // hp = GameObject.Find("Enemigo").GetComponent<Enemy>().health;
        contador = 0;
        UpdatePuntaje();
        //winText.text = "";

    }

    // Update is called once per frame
    void Update()
    {
       /* if(Input.GetKeyDown("space") && (isGrounded || maxJump > currentJump))
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            isGrounded = false;
            currentJump++;
        }
       */
        Move();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(Attack());
        }
        

       // mAnimator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
      //  mAnimator.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
      /*
        bool walking = Input.GetKey(KeyCode.W);

        mAnimator.SetBool("walking", walking);

        if (Input.GetKeyDown(KeyCode.X))
        {
            mAnimator.SetTrigger("attack");
        }
      */
    }

    void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if(isGrounded && velocity.y <0)
        {
            velocity.y = -2f;
        }

        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(0, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);

        if (isGrounded)
        {
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                //walk
                Walk();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                //Run
                Run();
            }
            else if (moveDirection == Vector3.zero)
            {
                //Idle
                Idle();
            }
            moveDirection *= moveSpeed;

            if(Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }    
        }

        controller.Move(moveDirection * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Idle()
    {
        anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }

    private void Run()
    {
        moveSpeed = runSpeed;
        anim.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
    }

    private void Jump()
    {

        velocity.y = Mathf.Sqrt(jumpHeight * -1 * gravity);
    }


    private IEnumerator Attack()
    {
        anim.SetLayerWeight(anim.GetLayerIndex("Attack Layer"), 1);
        anim.SetTrigger("Attack");

        yield return new WaitForSeconds(0.9f);
        anim.SetLayerWeight(anim.GetLayerIndex("Attack Layer"), 0);
    }   

    private void FixedUpdate()
    {
       /* float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

       Vector3 Move = new Vector3(moveHorizontal, 0.0f, moveVertical);

       rb.AddForce(Move * velocidad); */
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
        isGrounded = true;
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
