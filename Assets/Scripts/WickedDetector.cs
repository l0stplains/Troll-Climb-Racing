using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WickedDetector : MonoBehaviour
{

    [SerializeField] AudioClip wickedSFX;
    Rigidbody2D rb2d;
    float currentRotation = 0;
    float rotation;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rotation = rb2d.rotation;

        // Detect a rotation only if the player have at least rotated 300 degrees
        if (rotation > currentRotation + 300 || rotation < currentRotation - 300)
        {
            Debug.Log("WICKED!!!");
            GetComponent<AudioSource>().PlayOneShot(wickedSFX);
            currentRotation = Mathf.RoundToInt(rotation / 360) * 360;  // Rounding to the nearest multiple of 360
        }
    }
}
