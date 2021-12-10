using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{

    public float speed = 3;
    Rigidbody2D rb;
    public float jumpPower = 10;


    SpriteRenderer spriteRenderer;

    Animator anim;

    public static int packageProgress = 0;

    public float startPos;
    public float endPos;
    public float altStartPos;
    public float altEndPos;

    AudioSource soundEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        soundEffect = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalMovement = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * horizontalMovement, rb.velocity.y);

        bool isJumping = Input.GetAxis("Jump") > 0;


        if (isJumping)
        {

            Vector3 feetPosition = transform.GetChild(0).position;


            Collider2D[] colliders = Physics2D.OverlapCircleAll(feetPosition, .25f);
            for (int i = 0; i < colliders.Length; ++i)
            {
                if (colliders[i].gameObject == gameObject)
                    continue;


                rb.velocity = new Vector2(rb.velocity.x, 0);

                rb.AddForce(Vector2.up * jumpPower);
                break;
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && transform.position.x > startPos && transform.position.x < endPos)
        {
            //Debug.Log("Pallet is being built.");
            if (PackageScore.packages >= 1 && packageProgress <= 3)
            {
                Debug.Log("Package has been dropped.");
                PackageScore.packages -= 1;
                packageProgress += 1;
            }
            else if (PackageScore.packages >= 2 && packageProgress <= 3)
            {
                Debug.Log("Package has been dropped.");
                PackageScore.packages -= 2;
                packageProgress += 2;
            }

            else if (PackageScore.packages >= 3 && packageProgress <= 3)
            {
                Debug.Log("Package has been dropped.");
                PackageScore.packages -= 3;
                packageProgress += 3;
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && transform.position.x > altStartPos && transform.position.x < altEndPos)
        {
            //Debug.Log("Pallet is being built.");
            if (PackageScore.packages >= 1 && packageProgress <= 3)
            {
                Debug.Log("Package has been dropped.");
                PackageScore.packages -= 1;
                packageProgress += 1;
            }
            else if (PackageScore.packages >= 2 && packageProgress <= 3)
            {
                Debug.Log("Package has been dropped.");
                PackageScore.packages -= 2;
                packageProgress += 2;
            }

            else if (PackageScore.packages >= 3 && packageProgress <= 3)
            {
                Debug.Log("Package has been dropped.");
                PackageScore.packages -= 3;
                packageProgress += 3;
            }
        }

        if (rb.velocity.magnitude > .01f)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

        if (rb.velocity.x < 0)
          {
              spriteRenderer.flipX = true;
          }
          else if (rb.velocity.x > 0)
          {
              spriteRenderer.flipX = false;
          }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Occurred");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Package")
        {
            Destroy(collision.gameObject);
            PackageScore.packages += 1;
            soundEffect.Play();
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Health.health -= 5f;
        }

        /* if (collision.gameObject.tag == "incPallet")
          {
              Destroy(collision.gameObject);
              PackageScore.packages += 1;
          } */
    }

}
