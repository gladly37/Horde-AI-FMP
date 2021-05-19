using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class Zombie_AI : MonoBehaviour
{
    public float personalResetTimer;
    public float personalResetCooldown;
    public Horde_AI HordeAI;
    public NavMeshAgent ZombieAgent;
    public bool isActive = false;
    public bool isDead = false;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        HordeAI = transform.parent.GetComponent<Horde_AI>();
        ZombieAgent = GetComponent<NavMeshAgent>();
        personalResetTimer = personalResetCooldown;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead && isActive)
        {
            if (ZombieAgent.enabled) //this is really stupid and chugs performance but just leave it be, trapzombies.cs doesnt work otherwise. prolly way better way of doing this but im tired
            {
                personalResetTimer -= Time.deltaTime;
                if (personalResetTimer <= 0)
                {
                    animator.SetBool("ZombieIsDead", false);
                    personalResetTimer = personalResetCooldown + Random.Range(personalResetCooldown / 2 * -1, personalResetCooldown / 2);
                    HordeAI.SetNewDestination(ZombieAgent);
                }
            }
            else
            {
                isDead = true; 
            }
        }
        else if (isDead)
        {
            animator.SetBool("ZombieIsDead", true);
        }

        
    }
}
