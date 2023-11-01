using UnityEngine;

[CreateAssetMenu(menuName = "Player/Players")]
public class Player : ScriptableObject
{
    public int _Damage;
    public int _Health;
    public int Speed;
    public GameObject gun;

    public Armor Helmet;
    public Armor ChestPlate;


    public void AssignArmor()
    {
        _Damage = 100;
        _Health = 100;
        Speed = 100;

        _Health += Helmet._Health + ChestPlate._Health;
        _Damage += Helmet._Damage + ChestPlate._Damage;
        Speed += Helmet.Speed + ChestPlate.Speed;
    }
}
