using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Recipe", menuName = "ScriptableObjects/Cooking/RecipeData")]
public class RecipeData : ScriptableObject
{
    public List<FoodData> IngridientList;
    public FoodData result;
}

public enum CookingMethod
{
    NONE,
    BOILING,
    FRYING,
    GRILLING
}