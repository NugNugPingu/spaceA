using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator animator;  // Reference to the Animator component
    public BoxCollider2D doorCollider;  // Reference to the BoxCollider2D component
    public GameObject button;  // Reference to the button (if any)
    public new ParticleSystem particleSystem;  // Reference to the ParticleSystem component
    
    private bool isOpen = false;  // Track whether the door is open or closed
    private bool playerNearby = false;  // Track whether the player is near the door

    void Start()
    {
        CloseDoor();  // Ensure the door starts closed
        if (button != null)
        {
            button.SetActive(false);  // Disable the button initially
        }
        if (particleSystem != null)
        {
            particleSystem.Stop();  // Ensure the particle system is stopped initially
        }
    }

    void Update()
    {
        // Check if the "Space" key is pressed and the player is nearby
        if (playerNearby && Input.GetKeyDown(KeyCode.Space))
        {
            // Toggle the door's state
            if (isOpen)
            {
                CloseDoor();
            }
            else
            {
                OpenDoor();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player has entered the trigger area
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            if (particleSystem != null)
            {
                particleSystem.Play();  // Play the particle system
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Check if the player has exited the trigger area
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            if (particleSystem != null)
            {
                particleSystem.Stop();  // Stop the particle system
            }
        }
    }

    void OpenDoor()
    {
        Debug.Log("Opening door");
        animator.SetBool("isOpen", true);  // Set the isOpen boolean to true
        doorCollider.enabled = false;  // Disable the BoxCollider2D
        isOpen = true;  // Set the state to open
    }

    void CloseDoor()
    {
        Debug.Log("Closing door");
        animator.SetBool("isOpen", false);  // Set the isOpen boolean to false
        doorCollider.enabled = true;  // Enable the BoxCollider2D
        isOpen = false;  // Set the state to closed
    }
}
