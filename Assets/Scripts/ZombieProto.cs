using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieProto : MonoBehaviour
{
    public GameObject Player;
    public NavMeshAgent navMeshAgent;
    public float changeDestinationCooldown = 1f;
    public float originalCooldown;

    // Start is called before the first frame update
    void Start()
    {
        originalCooldown = changeDestinationCooldown;
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(Player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        changeDestinationCooldown -= Time.deltaTime;
        if (changeDestinationCooldown <= 0)
        {
            navMeshAgent.SetDestination(Player.transform.position);
            changeDestinationCooldown = originalCooldown;
        }
    }
}
