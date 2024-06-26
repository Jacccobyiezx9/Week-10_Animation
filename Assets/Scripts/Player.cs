using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator knightAnim;
    private int currentAttack = 0; // Track the current attack animation
    private bool isAttacking = false; // Flag to track if currently attacking
    private float attackTimeout = 1f; // Time in seconds before returning to idle
    private float lastAttackTime; // Time when the last attack animation started

    void Start()
    {
        // Initialize the knightAnim variable to the Animator component on this GameObject
        knightAnim = GetComponent<Animator>();
    }

    void Update()
    {
        // Check for walking animation control
        if (Input.GetKeyDown(KeyCode.D))
        {
            knightAnim.SetBool("Walking", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            knightAnim.SetBool("Walking", false);
        }

        // Check for dashing animation control
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            knightAnim.SetBool("Dash", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            knightAnim.SetBool("Dash", false);
        }

        // Check for Attack Animation
        if (Input.GetKeyDown(KeyCode.J))
        {
            // Reset attack timeout timer
            lastAttackTime = Time.time;

            // Increment the current attack number
            currentAttack++;

            // Reset to Attack1 if currentAttack goes beyond Attack4
            if (currentAttack > 4)
            {
                currentAttack = 1;
            }

            // Set the Attack parameter based on currentAttack
            knightAnim.SetInteger("Attack", currentAttack);

            // Set attacking flag
            isAttacking = true;
        }

        // Check if attack timeout has elapsed
        if (isAttacking && Time.time >= lastAttackTime + attackTimeout)
        {
            // Reset to Idle state
            knightAnim.SetInteger("Attack", 0); // Assuming 0 is the value for the Idle state
            isAttacking = false;
        }
    }
}
