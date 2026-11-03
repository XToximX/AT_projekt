using UnityEngine;
using System.Collections.Generic;

public class CookingStation : MonoBehaviour
{
    [SerializeField] private CookingStationData stationData;

    public Item Cook(List<Ingridient> input)
    {
        foreach (Recipe recipe in stationData.avaibleRecepies)
        {
            if (MatchesRecipe(recipe.ingridientList, input))
                return recipe.result;
        }

        return null;
    }

    private bool MatchesRecipe(List<Ingridient> recipe, List<Ingridient> input)
    {
        return true;
    }
}
