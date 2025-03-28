using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponFactory
{
    public static Weapon CreateWeapon(string weaponType)
    {
        switch (weaponType)
        {
            case "Sword":
                return new GameObject("BasicSword").AddComponent<BasicSword>();
            case "Hammer":
                return new GameObject("Hammer").AddComponent<Hammer>();
            case "Big Sword":
                return new GameObject("BigSword").AddComponent<BigSword>();
            default:
                Debug.LogError("Invalid weapon type!");
                return null;
        }
    }
}
