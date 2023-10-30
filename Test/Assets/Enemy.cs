using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public float speed = 100f;
    public float maxSpeed = 5f;
    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.forward.normalized * speed * Time.deltaTime);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }
    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Wall")){
            int rand = Random.Range(1,3);
            if (rand == 1){
                transform.Rotate( 0, 90, 0);
            } else {
                transform.Rotate( 0, -90, 0);
            }
        }
    }
}
