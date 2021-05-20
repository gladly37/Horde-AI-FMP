using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class FirstPersonCamera : MonoBehaviour

{

    public Vector2 mouseLook;
    public Vector2 smoothV;
    public float sensitivity;
    public float smoothing;

    public GameObject character;

    public pauseMenu pauseMenu;

    void Start()
    {
        pauseMenu = character.GetComponent<pauseMenu>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!pauseMenu.isGamePaused)
        {
            Vector2 vct2 = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            smoothV.x = Mathf.Lerp(smoothV.x, vct2.x, 1 / smoothing);
            smoothV.y = Mathf.Lerp(smoothV.y, vct2.y, 1 / smoothing);
            mouseLook += smoothV;
            mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

            transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
            character.transform.rotation = Quaternion.AngleAxis(mouseLook.x, Vector3.up);
            transform.position = character.transform.position + Vector3.up / 2;
        }
    }

}