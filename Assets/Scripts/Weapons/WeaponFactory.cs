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
                //return new Sword();
            case "Hammer":
                //return new Hammer();
            case "Bow":
                //return new Bow();
            default:
                Debug.LogError("Invalid weapon type!");
                return null;
        }
    }
}
