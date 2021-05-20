using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class FirstPersonController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public GameObject playerCam;
    public Rigidbody rb;
    public Light flashlight;
    public bool isGrounded;
    Vector3 movementVector = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    private void Update()
    {

        isGrounded = checkIfGrounded();

        Jump();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            flashlight.enabled = !flashlight.isActiveAndEnabled; 
        }
        //transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
        //playerCam.transform.position = transform.position + Vector3.up/2;
    }



    private void FixedUpdate()
    {
        float walk = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        float strafe = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        movementVector = new Vector3(strafe, 0, walk);
        transform.Translate(movementVector);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) & isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            /**if (wasOnWagon)
            {
                Debug.Log(wagonOfPlayer.localEulerAngles);
                Vector3 directionOfWagon = new Vector3(wagonOfPlayer.localEulerAngles.y, 0, wagonOfPlayer.localEulerAngles.x);
                //rb.AddRelativeForce(directionOfWagon.normalized* trainManager.currentSpeed , ForceMode.Impulse);
            }**/
        }


    }

    private bool checkIfGrounded()
    {
        Vector3 playerFeet = transform.position - Vector3.up / 2;

        Collider[] colliders = Physics.OverlapSphere(playerFeet, 0.62f);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.CompareTag("Jumpable"))
            {
                return true;
            }
        }
        //transform.parent = null;
        return false;
    }

    private void OnDrawGizmos()
    {
        Vector3 playerFeet = transform.position - Vector3.up / 2;
        Gizmos.DrawWireSphere(playerFeet, 0.52f);
    }
}
