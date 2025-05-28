using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    public float sensitivityX;
    public float sensitivityY;

    public Transform Orientation;

    float XRotation;
    float YRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //mouse input
        float MouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivityX;
        float MouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivityY;

        YRotation += MouseX;
        XRotation -= MouseY;
        XRotation = Mathf.Clamp(XRotation, -90f, 90f);

        //camera rotation
        transform.rotation = Quaternion.Euler(XRotation, YRotation, 0);
        Orientation.rotation = Quaternion.Euler(0, YRotation, 0);
    }
}
