using UnityEngine;
using UnityEngine.UI;

public class ToggleDoorAnimation : MonoBehaviour
{
    public Button yourButton;        // Reference to the UI Button
    public Animator yourAnimator;    // Reference to the Animator component
    public BoxCollider2D doorCollider;    // Reference to the Collider component
    private bool isOpen = false;     // Track the state of the door

    void Start()
    {
        // Add a listener to the button to call the ToggleAnimation method when the button is clicked
        yourButton.onClick.AddListener(ToggleAnimation);
    }

    void ToggleAnimation()
    {
        // Toggle the isOpen state
        isOpen = !isOpen;
        
        // Log the current state
        Debug.Log("isOpen: " + isOpen);
        
        // Set the boolean parameter in the Animator
        yourAnimator.SetBool("isOpen", isOpen);

        // Enable or disable the Collider based on the door state
        doorCollider.enabled = !isOpen;
    }
}
