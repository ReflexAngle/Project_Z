using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
[RequireComponent(typeof(Rigidbody))]

public class WeaponFactory : MonoBehaviour
{
    public BasicSword basicSwordPrefab;
    public Axe AxePrefab;
    public BigSword bigSwordPrefab;

    public Weapon CreateWeapon(string weaponType)
    {
        switch (weaponType)
        {
            case "Sword":
                return basicSwordPrefab;
            case "Hammer":
                return AxePrefab;
            case "Big Sword":
                return bigSwordPrefab;
            default:
                Debug.LogError("Invalid weapon type!");
                return null;
        }
    }
}
