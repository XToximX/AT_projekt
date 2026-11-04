using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CookingStationData", menuName = "ScriptableObjects/Cooking/CookingStationData")]
public class CookingStationData : ScriptableObject
{
    public CookingMethod cookingMethod;
    public List<RecipeData> avaibleRecepies;
}
