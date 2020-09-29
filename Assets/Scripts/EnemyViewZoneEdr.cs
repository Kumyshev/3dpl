using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(EnemyViewZone))]
public class EnemyViewZoneEdr : Editor
{
    void OnSceneGUI() 
    {
        EnemyViewZone zone = (EnemyViewZone)target;
        Handles.color = Color.red;
        Handles.DrawWireArc(zone.transform.position, Vector3.up, Vector3.forward, 360, zone.viewRadius);
        Vector3 zoneA = zone.DirectAngle(-zone.viewAngle / 2, false);
        Vector3 zoneB = zone.DirectAngle(zone.viewAngle / 2, false);

        Handles.DrawLine(zone.transform.position, zone.transform.position + zoneA * zone.viewRadius);
        Handles.DrawLine(zone.transform.position, zone.transform.position + zoneB * zone.viewRadius);

    }
}
