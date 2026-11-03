using UnityEngine;

[CreateAssetMenu(fileName = "Dish", menuName = "ScriptableObjects/Cooking")]
public class Dish : Item
{
    public Item resultDish;
    public bool isVegan;
    public CookingMethod cookingMethod;
}
