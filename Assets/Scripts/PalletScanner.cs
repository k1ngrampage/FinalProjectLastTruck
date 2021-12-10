using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalletScanner : MonoBehaviour
{
    AudioSource soundEffect;

    // Start is called before the first frame update
    void Start()
    {
        soundEffect = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pallet")
        {
            soundEffect.Play();
        }
    }
}
