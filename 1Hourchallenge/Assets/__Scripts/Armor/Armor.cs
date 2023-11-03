using UnityEngine;

[CreateAssetMenu(menuName = "Player/Armor")]
public class Armor : ScriptableObject
{

    public int _Health;
    public int _Speed;
    public Sprite Sprite;

    public Sprite inGameSprite;
}
