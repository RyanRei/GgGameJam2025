using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Splines;

public class P2SwordAttack : MonoBehaviour
{
    [SerializeField] public P2_Input_Actions inputActions;
    InputAction attackAction;

    [SerializeField] private SplineAnimate splineAnimate; // Reference to Spline Animate
    public Animator animator;
    public audiomanager audioM;
    void Start()
    {
        // Initialize Input Actions
        animator = gameObject.GetComponent<Animator>();
        inputActions = new P2_Input_Actions();
        inputActions.Player.Enable();

        // Attack input setup
        attackAction = inputActions.Player.Attack;
        attackAction.performed += OnAttackPerformed;  // Subscribe to the attack performed event
    }

    private void OnAttackPerformed(InputAction.CallbackContext context)
    {
        animator.SetTrigger("Attack1");
        audioM.playRandomSwing();
        //TriggerAttack(); // Trigger the attack animation
    }

    private void TriggerAttack()
    {
        if (splineAnimate != null && !splineAnimate.IsPlaying)
        {
            //splineAnimate.Play(); // Trigger the attack animation
            splineAnimate.Restart(true);
        }
    }

    private void OnDisable()
    {
        // Unsubscribe to avoid memory leaks
        attackAction.performed -= OnAttackPerformed;  // Unsubscribe using the method name
        inputActions.Player.Disable();  // Disable the action map
    }
}
