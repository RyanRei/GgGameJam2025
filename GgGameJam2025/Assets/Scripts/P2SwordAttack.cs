using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Splines;
using System.Collections;
using UnityEngine.VFX;

public class P2SwordAttack : MonoBehaviour
{
    P2_Input_Actions inputActions;
    InputAction attackAction;
    InputAction ultimateAction;
    public audiomanager audioM;
    public HealthManager healthManager;
    public VisualEffect vfx;

    //[SerializeField] private SplineAnimate splineAnimate; // Reference to Spline Animate
    public Animator animator;
    public Animator animator2;
    public bool ultimateActivate=false;
    void Start()
    {

        // Initialize Input Actions
        animator2 = GameObject.Find("PivotP2").GetComponent<Animator>();
        animator = gameObject.GetComponent<Animator>();
        inputActions = new P2_Input_Actions();
        inputActions.Player.Enable();


        // Attack input setup
        attackAction = inputActions.Player.Attack;
        attackAction.performed += OnAttackPerformed;  // Subscribe to the attack performed event

        ultimateAction = inputActions.Player.Ultimate;
        ultimateAction.performed += UltimateAction_performed;
    }

    private void UltimateAction_performed(InputAction.CallbackContext obj)
    {
        if (ultimateActivate)
        {
            animator2.SetTrigger("Ultimate");
            ultimateActivate = false;
            healthManager.booster2.fillAmount = 0;
            healthManager.boosterP2 = 0;
        }
    }

    private void OnAttackPerformed(InputAction.CallbackContext context)
    {
        animator.SetTrigger("Attack1"); // Trigger the attack animation
        audioM.playRandomSwing();

    }

   /* private void TriggerAttack()
    {
        if (splineAnimate != null && !splineAnimate.IsPlaying)
        {
            //splineAnimate.Play(); // Trigger the attack animation
            splineAnimate.Restart(true);
        }
    }*/

    private IEnumerator vfxStart()
    {
        vfx.enabled = true;
        yield return new WaitForSeconds(0.32f);
        vfx.enabled = false;
    }




    private void OnDisable()
    {
        // Unsubscribe to avoid memory leaks
        attackAction.performed -= OnAttackPerformed;  // Unsubscribe using the method name
        ultimateAction.performed -= UltimateAction_performed;
        inputActions.Player.Disable();  // Disable the action map
    }
}
