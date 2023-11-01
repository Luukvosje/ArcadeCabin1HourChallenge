using UnityEngine;

[CreateAssetMenu(menuName = "Player/Armor")]
public class Armor : ScriptableObject
{
    public int _Damage;
    public int _Health;
    public int Speed;
    public Sprite Sprite;
}
