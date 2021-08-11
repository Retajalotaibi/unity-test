using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    [SerializeField] float movementSpeed;
    public float mouseSensitivity = 100f;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x + offset.x, 0, offset.z);
    }
}
