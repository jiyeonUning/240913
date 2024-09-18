using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] Transform muzzePoint;
    [SerializeField] GameObject prefab;
    private RaycastHit hit;

    public void TargetModeOn()
    {
             Debug.DrawLine(muzzePoint.position, hit.point, Color.white);              
    }

    public void Fire()
    {
        Instantiate(prefab, muzzePoint.position, muzzePoint.rotation);
    }
}
