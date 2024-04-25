using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float slowSpeed = 10f;
    [SerializeField] float fastSpeed = 20f;
    [SerializeField] float destroyTime = 0.25f;
    bool hasBoost;

    
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        float steerAmount =  Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);

    }

    private void OnCollisionEnter2D(Collision2D other) {
        moveSpeed = slowSpeed;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("FastBoost")){
            Debug.Log("Time to go fast!");
            moveSpeed = fastSpeed;
            // hasBoost = true;
            Destroy(other.gameObject, destroyTime);
        } else if (other.CompareTag("SlowBoost")){
            Debug.Log("Time to slow down!");
            moveSpeed = slowSpeed;
            // hasBoost = true;
            Destroy(other.gameObject, destroyTime);
        }
    }
}
