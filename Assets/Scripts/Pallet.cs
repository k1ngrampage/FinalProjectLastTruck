using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pallet : MonoBehaviour
{
    public static int palletScore;

    AudioSource soundEffect;

    public AudioClip soundClip;

    // Start is called before the first frame update
    void Start()
    {
        soundEffect = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        palletScore = Score.score;

        if (transform.position.x < -10)
        {
            Destroy(gameObject);
            Score.score += 1;
            soundEffect.Play();
            soundEffect.PlayOneShot(soundClip, 0.7f);
        }
    }
}
