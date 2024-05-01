using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrails : MonoBehaviour
{
    [SerializeField] ParticleSystem trailEffect;
    CapsuleCollider2D board;


     private void Start(){
        board = GetComponent<CapsuleCollider2D>();
    }  
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Ground" && board.IsTouching(other.collider)) {
                    trailEffect.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
          
        trailEffect.Stop();

    }
}
