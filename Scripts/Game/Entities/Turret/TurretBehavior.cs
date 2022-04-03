using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour
{

    [Header("Turret Information")]

    public GameObject pivotObject;

    public GameObject gunBarrel;
    public GameObject radiusCircle;
    public LayerMask layerMask;

    public GameObject hitParticles;

    public ParticleSystem[] sparkParticles;



    public virtual void OnShoot(GameObject target) { }
}
