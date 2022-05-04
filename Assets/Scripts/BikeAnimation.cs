using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeAnimation : MonoBehaviour
{
    [SerializeField] float pedalingSpeed = 0.5f;
    [SerializeField] float tireSpinSpeed = 1f;
    [SerializeField] GameObject sepeda1;
    [SerializeField] GameObject sepeda2;
    [SerializeField] GameObject sepeda3;
    [SerializeField] GameObject sepeda4;
    [SerializeField] GameObject banDepan;
    [SerializeField] GameObject banBelakang;
    SpriteRenderer sepeda1Sprite;
    SpriteRenderer sepeda2Sprite;
    SpriteRenderer sepeda3Sprite;
    SpriteRenderer sepeda4Sprite;
    Transform banDepanTransform;
    Transform banBelakangTransform;
    float timer = 0;
    float currentTireRotation = 0;
    int currentBikeSpin = 0;
    bool isOnTheGround = false;

    private void Start()
    {
        sepeda1Sprite = sepeda1.GetComponent<SpriteRenderer>();
        sepeda2Sprite = sepeda2.GetComponent<SpriteRenderer>();
        sepeda3Sprite = sepeda3.GetComponent<SpriteRenderer>();
        sepeda4Sprite = sepeda4.GetComponent<SpriteRenderer>();
        banDepanTransform = banDepan.GetComponent<Transform>();
        banBelakangTransform = banBelakang.GetComponent<Transform>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isOnTheGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isOnTheGround = false;
        }
    }

    private void Update()
    {
        currentTireRotation -= tireSpinSpeed * Time.deltaTime;
        banDepanTransform.Rotate(new Vector3(0, 0, currentTireRotation));
        banBelakangTransform.Rotate(new Vector3(0, 0, currentTireRotation));

        if (isOnTheGround)
        {
            timer -= Time.deltaTime;
        }
        if (timer < 0)
        {
            currentBikeSpin = (currentBikeSpin + 1) % 4;
            TurnOffAllRenderer();
            switch(currentBikeSpin){
                case 0:
                    sepeda1Sprite.enabled = true;
                    break;
                case 1:
                    sepeda2Sprite.enabled = true;
                    break;
                case 2:
                    sepeda3Sprite.enabled = true;
                    break;
                case 3:
                    sepeda4Sprite.enabled = true;
                    break;
            }
            timer = pedalingSpeed;
        }
    }
    void TurnOffAllRenderer(){
        sepeda1Sprite.enabled = false;
        sepeda2Sprite.enabled = false;
        sepeda3Sprite.enabled = false;
        sepeda4Sprite.enabled = false;
    }
}
