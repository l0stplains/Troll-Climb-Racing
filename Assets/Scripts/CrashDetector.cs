using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem crashEffect; 
    [SerializeField] AudioClip crashSFX;
    bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Ground" && !hasTriggered){
            hasTriggered = true;
            crashEffect.Play();
            GetComponent<PlayerController>().DisableControl();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", loadDelay);
        }
    }

    private void ReloadScene(){
        SceneManager.LoadScene("Level1");
    }
}
