using UnityEngine;

[CreateAssetMenu(menuName = "Player/Players")]
public class Player : ScriptableObject
{
    public int _Damage;
    public int _Health;
    public int Speed;
    public int gun;

    public Armor Helmet;
    public Armor ChestPlate;


    public void AssignArmor()
    {
        _Health += Helmet._Health + ChestPlate._Health;
        _Damage += Helmet._Damage + ChestPlate._Damage;
        Speed += Helmet.Speed + ChestPlate.Speed;
    }
}
