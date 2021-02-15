using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private float mouseSensitivity;

    private Transform parent;


    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;

        //offset = transform.position - player.transform.position;
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X")* mouseSensitivity * Time.deltaTime;

        parent.Rotate(Vector3.up, mouseX);

    }    
    // Update is called once per frame
    void LateUpdate()
    {
       // transform.position = player.transform.position + offset;
    }
}
