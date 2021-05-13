using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie_AI : MonoBehaviour
{
    public float personalResetTimer;
    public float personalResetCooldown;
    public Horde_AI HordeAI;
    public NavMeshAgent ZombieAgent;

    // Start is called before the first frame update
    void Start()
    {
        HordeAI = transform.parent.GetComponent<Horde_AI>();
        ZombieAgent = GetComponent<NavMeshAgent>();
        personalResetTimer = personalResetCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        personalResetTimer -= Time.deltaTime;
        if (personalResetTimer <= 0)
        {
            personalResetTimer = personalResetCooldown + Random.Range (personalResetCooldown / 2 * -1, personalResetCooldown / 2);
            HordeAI.SetNewDestination(ZombieAgent);
        }
    }
}
