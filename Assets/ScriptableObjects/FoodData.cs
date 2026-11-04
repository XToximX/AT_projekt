using UnityEngine;

[CreateAssetMenu(fileName = "Food", menuName = "ScriptableObjects/Cooking/FoodData")]
public class FoodData : ItemData
{
    public bool isVegan;
    public CookingMethod cookingMethod;
}
