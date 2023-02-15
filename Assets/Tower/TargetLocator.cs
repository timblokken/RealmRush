using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{

    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float range = 15f;
    Transform target;



    // Update is called once per frame
    void Update()
    {
        FindClosestedTarget();
        AimWeapon();
    }

    void FindClosestedTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDsitance = Mathf.Infinity;

        foreach(Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position,enemy.transform.position);

            if(targetDistance < maxDsitance)
            {
                closestTarget = enemy.transform;
                maxDsitance = targetDistance;
            }
        }

        target = closestTarget;
        
    }

    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position,target.position);

        weapon.LookAt(target.position);

        if (targetDistance <range)
        {
            Attack(true);
        }
        else{
            Attack(false);
        }

    }

    void Attack(bool isActive)
    {
        var emissionModule = projectileParticles.emission;
        emissionModule.enabled = isActive;
    }
}
