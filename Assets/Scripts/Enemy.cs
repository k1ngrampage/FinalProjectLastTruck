using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject targetObject;

    public Transform targetTransform;

    public Vector3 targetPosition;

    public bool useActivationRange = true;
    public bool shouldRotate = false;
    public float activationRange = 2;
    public float speedPerSecond = 3;

    public bool facingRight = false;

    SpriteRenderer spriteRenderer;

    AudioSource soundEffect;

    // Start is called before the first frame update
    void Start()
    {
        if (targetTransform == null)
        {
            targetTransform = FindObjectOfType<PlayerControls>().transform;
        }

        spriteRenderer = GetComponent<SpriteRenderer>();

        soundEffect = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetTransform == null)
        {
            targetTransform = FindObjectOfType<PlayerControls>().transform;
        }

        Vector3 directionVector =
             targetTransform.position - transform.position;

        float distanceToTarget = Vector3.Distance(transform.position, targetTransform.position);
        float distanceToTarget2 = directionVector.magnitude;

        soundEffect.Play();

        if (useActivationRange && distanceToTarget2 > activationRange)
        {
            soundEffect.Stop();
            return;
        }

        directionVector.Normalize();



        transform.position += directionVector * speedPerSecond * Time.deltaTime;

        if (targetTransform.position.x < gameObject.transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
        if (targetTransform.position.x > gameObject.transform.position.x)
        {
            spriteRenderer.flipX = true;
        }

    }
}
