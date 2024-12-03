using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Weapon")]
public class WeaponSO : ScriptableObject
{
    public int initClipAmmo;
    public int initBagAmmo;
    public float attackRate;
    public float distance;
    public float weaponDamage;
    public LayerMask whatIsDamagable;


    public enum Type { Melee, Automatic, Manual};
    public Type type;

}
