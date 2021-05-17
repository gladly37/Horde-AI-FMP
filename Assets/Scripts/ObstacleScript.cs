using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObstacleScript : MonoBehaviour
{
    public bool activated = false;
    public float obstacleTranslateMultiplier = 1;
    public float obstacleScaleMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        /**if (collision.collider.tag == "Player")
        {
            if (!activated)
            {
                
            }
        }**/
    }

    public void Activate()
    {
        activated = true;
        CreateNavMeshObstacle();
        gameObject.AddComponent<Rigidbody>();
    }

    void CreateNavMeshObstacle()
    {

        GameObject newObstacle = gameObject;
        GameObject spawnedNewObstacle = Instantiate(newObstacle, transform);
        spawnedNewObstacle.GetComponent<MeshCollider>().isTrigger = true;
        spawnedNewObstacle.GetComponent<MeshRenderer>().enabled = false;
        spawnedNewObstacle.transform.position = spawnedNewObstacle.transform.parent.position + Vector3.up * obstacleTranslateMultiplier;
        spawnedNewObstacle.transform.parent = null;
        //spawnedNewObstacle.transform.localScale = new Vector3(transform.localScale.x / obstacleScaleMultiplier, transform.localScale.y / obstacleScaleMultiplier, transform.localScale.z / obstacleScaleMultiplier); -- changing its scale also changes its position, for some reason.
        spawnedNewObstacle.AddComponent<TrapZombies>();
    }
}
