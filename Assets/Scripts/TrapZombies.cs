using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrapZombies : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<NavMeshAgent>() != null)
        {
            other.GetComponent<NavMeshAgent>().enabled = false;
            other.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
