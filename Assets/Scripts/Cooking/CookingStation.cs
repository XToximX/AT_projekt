using UnityEngine;
using System.Collections.Generic;
using System.Linq;

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
        if (recipe.Count !=  input.Count) return false;

        Dictionary<Ingridient, int> counts = new Dictionary<Ingridient, int>();

        foreach (Ingridient ingridient in recipe)
        {
            if (counts.ContainsKey(ingridient))
                counts[ingridient]++;
            else
                counts.Add(ingridient, 1);
        }

        foreach (Ingridient ingridient in input)
        {
            if (!counts.ContainsKey(ingridient))
                return false;

            counts[ingridient]--;

            if (counts[ingridient] < 0)
                return false;
        }
         
        return true;
    }
}
