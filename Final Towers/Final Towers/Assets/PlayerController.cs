using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Connection;
using FishNet.Object;


public class PlayerController : NetworkBehaviour
{
    [Header("Base setup")]
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    [SerializeField]
    private float cameraYOffset = 0.4f;
    private Camera playerCamera;

    [Header("Animator setup")]
    public Animator anime;

    // Spawns a player and applies the appropriate constraints.
    public override void OnStartClient()
    {
        // Sets the stage for the player
        base.OnStartClient();

        // Checks if the player spawned is an owner
        if (base.IsOwner) 
        {
            // Puts the camera view from own player's pov
            playerCamera = Camera.main;
            // Applies the appropriate transformations for player movement
            playerCamera.transform.position = new Vector3(transform.position.x, transform.position.y + cameraYOffset, transform.position.z);
            playerCamera.transform.SetParent(transform);
        }
        else
        {
            // Means another player has spawned within our lines of sight and non-owners
            // of that player cannot control them
            gameObject.GetComponent<PlayerController>().enabled = false;
        }

        void Start()
        {
            characterController = GetComponent<CharacterController>();

            // Lock cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

}
