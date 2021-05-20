using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliEnd : MonoBehaviour
{
    public bool gameWon = false;
    public Rigidbody rb;
    public float takeOffSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameWon)
        {
            rb.MovePosition(rb.position + rb.transform.up * Time.deltaTime * takeOffSpeed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            gameWon = true;
        }
    }
}
