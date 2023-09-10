using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    private bool        canSeePlayer;
    private Vector3     playerLastPosition;

    public float        radiusVision;
    public float        radiusSense;
    
    [Range(0, 360)]
    public float        angle;

    public Transform    playerTransform;

    public LayerMask    targetMask;
    public LayerMask    obstructionMask;


    private void Start()
    {
        playerLastPosition = transform.position;
    }

    private void Update()
    {
        FieldOfViewCheck();
    }


    private void FieldOfViewCheck()
    {
        Collider[] VisionRangeChecks    = Physics.OverlapSphere(transform.position, radiusVision,   targetMask);

        if (VisionRangeChecks.Length != 0 )
        {

            Vector3 directionToTarget   = (playerTransform.position - transform.position).normalized;

            float distanceToTarget      = Vector3.Distance(transform.position, playerTransform.position);

            if (Vector3.Angle(transform.forward, directionToTarget) < angle/2 || distanceToTarget < radiusSense)
            {

                if(!Physics.Raycast(transform.position,directionToTarget,distanceToTarget,obstructionMask))
                {
                    canSeePlayer        = true;
                }
                else
                {
                    canSeePlayer = false;
                }
            }
            else
            {
                canSeePlayer = false;
            }
        }
        else if(canSeePlayer)
        {
            canSeePlayer = false;
            playerLastPosition = playerTransform.position;
        }

    }

    public bool IsSeePlayer()
    {
        return canSeePlayer;
    }

    public Vector3 GetLastPosition()
    {
        return playerLastPosition;
    }


}

