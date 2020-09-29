using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyViewZone : MonoBehaviour
{
    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;

    public LayerMask obstacle;
    public LayerMask target;

    [HideInInspector]
    public List<Transform> visibleTargs = new List<Transform>();

    public GameObject loseMenu;




    private void FixedUpdate()
    {
        FindTarget();
    }
    private void FindTarget() 
    {

        Collider[] targetsInZone = Physics.OverlapSphere(transform.position, viewRadius, target);
        for (int i=0; i < targetsInZone.Length; i++) 
        {
            Transform targetTransf = targetsInZone[i].transform;
            Vector3 directToTarget = (targetTransf.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, directToTarget) < viewAngle / 2) 
            {
                float distanceToTarg = Vector3.Distance(transform.position, targetTransf.position);

                if (!Physics.Raycast(transform.position, directToTarget, distanceToTarg, obstacle)) 
                {

                    loseMenu.SetActive(true);
                    Time.timeScale = 0;
                }
            }
        }
    }

    public Vector3 DirectAngle(float angle, bool angleIsGlobl) 
    {
        if (!angleIsGlobl) 
        {
            angle += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad));
    }
}
