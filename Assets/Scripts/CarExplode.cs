using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CarExplode : MonoBehaviour
{
    public ObstacleScript obstacleToTrigger;
    public float explosionRadius;
    public float explosionForce;
    public bool exploded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CarIgniter")
        {
            if (!obstacleToTrigger.activated && !exploded)
            {
                obstacleToTrigger.Activate();
                Collider[] rigidbodiesNearby = Physics.OverlapSphere(transform.position, explosionRadius);
                foreach (Collider col in rigidbodiesNearby)
                {
                    if (col.GetComponent<Rigidbody>() != null)
                    {
                        col.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRadius);
                    }

                    if (col.tag == "Explodeable")
                    {
                        col.GetComponent<NavMeshObstacle>().carving = false;
                    }
                    exploded = true;
                }
            }
        }
    }
}
