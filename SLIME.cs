using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SLIME : MonoBehaviour
{
    public int PTOSVIDA;
    public int DAMAGE;
    public bool ACCION;


    public float speed = 3.0f;
    public bool vertical;
    public float changeTime = 3.0f;

    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;
    bool broken = true;
    public bool directionLookEnabled = true;

    int shootsFix;

    Animator animator;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
        shootsFix = PTOSVIDA;

    }

    // Update is called once per frame
    void Update()
    {
        //remember ! inverse the test, so if broken is true !broken will be false and return won’t be executed.
        if (!broken)
        {
            return;
        }

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }


        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
            if (directionLookEnabled)
            {
                if (direction < 0)
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }
                else if (direction > 0)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
            }

        }

        rigidbody2D.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        CONTROLLER player = other.gameObject.GetComponent<CONTROLLER>();

        if (player != null)
        {
            player.TakeDamage(DAMAGE);
            if (ACCION == true)
            {
                animator.SetTrigger("ACCION");
            }
        }
    }

    //Public because we want to call it from elsewhere like the projectile script
    public void TakeDamage(int damage)
    {
        shootsFix -= damage;

        animator.SetTrigger("Hurt");

        if (shootsFix <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Enemey died");
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject);
    }
}