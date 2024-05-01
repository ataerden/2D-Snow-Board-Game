using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SurfaseCollapse : MonoBehaviour
{
    [SerializeField] ParticleSystem crashEffect;
    CircleCollider2D playerHead;
    // Start is called before the first frame update
    private void Start(){
        playerHead = GetComponent<CircleCollider2D>();
    }  
    

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Ground" && playerHead.IsTouching(other.collider)) {
                    FindObjectOfType<PlayerController>().DisableControls();
                    Debug.Log("Gafamı Vurdum!!!");
                    Invoke("ReloadScene", 0.5f);
                    crashEffect.Play();
                    
        }
    }

    void ReloadScene() {
        SceneManager.LoadScene(0);
    }

}
