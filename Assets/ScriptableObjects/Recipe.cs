using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Recipe", menuName = "ScriptableObjects/Cooking")]
public class Recipe : ScriptableObject
{
    public List<Ingridient> ingridientList;
    public Item result;
}

public enum CookingMethod
{
    NONE,
    BOILING,
    FRYING,
    GRILLING
}