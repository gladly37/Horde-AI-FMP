using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObstacleScript : MonoBehaviour
{
    public bool playerTouched = false;
    public float obstacleTranslateMultiplier = 1;
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
        if (collision.collider.tag == "Player")
        {
            if (!playerTouched)
            {
                playerTouched = true;
                CreateNavMeshObstacle();
                gameObject.AddComponent<Rigidbody>();
            }
        }
    }

    void CreateNavMeshObstacle()
    {
        GameObject newObstacle = gameObject;
        GameObject spawnedNewObstacle = Instantiate(newObstacle, transform);
        Destroy(spawnedNewObstacle.GetComponent<MeshCollider>());
        spawnedNewObstacle.GetComponent<MeshRenderer>().enabled = false;
        spawnedNewObstacle.transform.position = spawnedNewObstacle.transform.parent.position + Vector3.up * obstacleTranslateMultiplier;
        
        spawnedNewObstacle.transform.parent = null;
    }
}
