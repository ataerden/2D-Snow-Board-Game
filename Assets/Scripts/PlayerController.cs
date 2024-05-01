using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb2d;
    [SerializeField]  float torque = 1;
    SurfaceEffector2D surfaceEffector2D;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] ParticleSystem trailEffect;
    float defaultEmission = 15;
    float fasterEmission = 300;

    float baseSpeed = 10f;
    float boostSpeed = 15f;
    bool canMove =  true;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove) {
            Rotate();
            Boost();
        }
    }
    public void DisableControls() {
        canMove = false;
    }
    void Boost() {

        if(Input.GetKey(KeyCode.Space)) {
            surfaceEffector2D.speed = boostSpeed;
            if (trailEffect != null) {
            var emissionModule = trailEffect.emission;
            var emissionOverTime = new ParticleSystem.MinMaxCurve(fasterEmission);
            emissionModule.rateOverTime = emissionOverTime;
        }
        }
        else{
            surfaceEffector2D.speed = baseSpeed;
            if (trailEffect != null) {
            var emissionModule = trailEffect.emission;
            var emissionOverTime = new ParticleSystem.MinMaxCurve(defaultEmission);
            emissionModule.rateOverTime = emissionOverTime;
        }
        }

    }

    void Rotate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torque);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torque);
        }
    }
}
