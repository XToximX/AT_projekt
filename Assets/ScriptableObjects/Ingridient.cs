using UnityEngine;

[CreateAssetMenu(fileName = "Ingridient", menuName = "ScriptableObjects/Cooking")]
public class Ingridient : Item
{
    public bool isVegan;
    public CookingMethod cookingMethod;
}
