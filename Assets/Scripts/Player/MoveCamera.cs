using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform CameraPosition; 

    // Update is called once per frame
    private void Update()
    {
        transform.position = CameraPosition.position;   
    }
}
