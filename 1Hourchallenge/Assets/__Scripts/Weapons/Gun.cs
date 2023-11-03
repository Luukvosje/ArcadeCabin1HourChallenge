using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Player/Weapons")]
public class Gun : ScriptableObject
{
    public string name;
    public float gunDamage;
    public float bulletSpeed;
    public float fireSpeed;

    public Sprite inGameSprite;

    [Header("ShootPoints, X:0.5, Y:0 , is default")]
    public List<Vector2> shootPoints = new List<Vector2>();

    //0 is default
    public List<float> shootPointAngle = new List<float>();


}
