using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Horde_AI : MonoBehaviour
{
    public List<GameObject> zombies = new List<GameObject>();
    public GameObject[] zombiesInHorde;
    public NavMeshAgent[] zombieAgentsInHorde;
    public float destinationUpdateTimer;
    public float destinationUpdateCooldown;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        destinationUpdateTimer = destinationUpdateCooldown;
        for (int i =0; i < transform.childCount; i++)
        {
            zombies.Add(transform.GetChild(i).gameObject);
        }
        zombiesInHorde = zombies.ToArray();
        zombieAgentsInHorde = new NavMeshAgent[zombiesInHorde.Length];
        for (int i = 0; i < zombiesInHorde.Length; i++)
        {
            zombieAgentsInHorde[i] = zombiesInHorde[i].GetComponent<NavMeshAgent>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        destinationUpdateTimer -= Time.deltaTime;
        if (destinationUpdateTimer <= 0)
        {
           /** foreach(NavMeshAgent zombieAgent in zombieAgentsInHorde)
            {
                SetNewDestination(zombieAgent, GetPlayerLoc(Player));
            } **/
        }
    }

    public void SetNewDestination(NavMeshAgent agent, Vector3 playerLoc)
    {
        agent.SetDestination(playerLoc);
    }

    public Vector3 GetPlayerLoc(GameObject player)
    {
        return player.transform.position;
    }
}
