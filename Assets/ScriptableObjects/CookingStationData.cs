using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CookingStationData", menuName = "ScriptableObjects/Cooking")]
public class CookingStationData : ScriptableObject
{
    public CookingMethod cookingMethod;
    public List<Recipe> avaibleRecepies;
}
