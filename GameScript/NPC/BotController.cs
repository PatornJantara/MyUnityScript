using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotController : MonoBehaviour
{
    public float            chaseSpeed      = 5.0f;
    public float            walkSpeed       = 3.0f;

    public  FieldOfView     fov;
    public  Patrol          pt;
    public  BotSound        botSound;

    private Transform       playerTransform;
    private NavMeshAgent    enermy;
    private Animator        animator;

    private string          IsMoving = "IsMoving";
    private string          IsTackle = "IsTackle";

    private void Start()
    {
        playerTransform     = GameObject.FindGameObjectWithTag("Player").transform;
        enermy              = GetComponent<NavMeshAgent>();
        animator            = GetComponent<Animator>();


    }

    private void Update()
    {
        bool canSeePlayer = (fov == null)? false: fov.IsSeePlayer();

        if (canSeePlayer)
        {
            if (botSound != null)   botSound.MakeSound();

            enermy.speed = chaseSpeed;
            enermy.SetDestination(playerTransform.position);
  
        }
        else 
        {
            enermy.speed = walkSpeed;
            if (botSound != null)   botSound.Stop();
        }


        if (animator != null)
        {
            animator.SetFloat(IsMoving, (float)(enermy.speed));
        }


        transform.rotation   =  (enermy.velocity != Vector3.zero) ? Quaternion.LookRotation(enermy.velocity.normalized) : transform.rotation;

    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is the player
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool(IsTackle, true);
        }

    }

}


