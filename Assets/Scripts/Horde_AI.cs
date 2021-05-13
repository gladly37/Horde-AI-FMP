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
        /**destinationUpdateTimer -= Time.deltaTime;
        if (destinationUpdateTimer <= 0)
        {
            Vector3 playerLocation = GetPlayerLoc(Player);
            Transform playerTransform = Player.transform;
            Debug.Log(playerTransform.right);
            foreach(NavMeshAgent zombieAgent in zombieAgentsInHorde)
            {
                //Vector3 destinationNearPlayer = new Vector3(playerTransform.right + Random.Range(-5f, 5f), playerTransform.position.y, playerTransform.forward + Random.Range()
                SetNewDestination(zombieAgent);
            }
            destinationUpdateTimer = destinationUpdateCooldown + Random.Range(-0.5f, 0.5f);
        } **/
    }

    public void SetNewDestination(NavMeshAgent agent)
    {
        Vector3 desiredLoc = Player.transform.position + Player.transform.forward * Random.Range(1, 5f) + Player.transform.right * Random.Range(-5f, 5f);
        agent.SetDestination(desiredLoc);
    }

    public Vector3 GetPlayerLoc(GameObject player)
    {
        return player.transform.position;
    }
}
