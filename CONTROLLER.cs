using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CONTROLLER : MonoBehaviour
{
    public string Tag;
    public int count;
    public Text countText;

    public int maxHealth = 7;
    public int currentHealth;
    public BARRA_VIDA healthBar;

    private Rigidbody2D rb;
    public float speed;
    private float moveInput;
    public float jumpForce;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;


    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;

    private Animator anim;

    void Start()
    {
        count = 0;
        setCountText();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        healthBar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            FindObjectOfType<Gamemanager>().EndGame();
            this.enabled = false;
        }


        if (currentHealth > maxHealth)
        {
            TakeDamage((currentHealth - maxHealth));
        }
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }

        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("takeOff");
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }
        if (isGrounded == true)
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }
    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            if (isInvincible)
                return;


            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("HURT");
        }
        else
        {
            anim.SetTrigger("DED");
            FindObjectOfType<Gamemanager>().EndGame();
            this.enabled = false;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(Tag))
        {
            other.gameObject.SetActive(false);
            Debug.Log("tocado");

            count = count + 100;
            setCountText();
        }
    }
    void setCountText()
    {
        countText.text = "Score: " + count.ToString();
    }
}

