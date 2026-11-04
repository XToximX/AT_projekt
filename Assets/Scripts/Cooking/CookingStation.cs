using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class CookingStation : MonoBehaviour
{
    [SerializeField] private CookingStationData stationData;

    [SerializeField] private List<Transform> slotsPos;
    private List<GameObject> ingridients;
    private int occupiedSlotsCount = 0;

    [SerializeField] FoodObject resultFood;

    private void Start()
    {
        ingridients = new List<GameObject>();

        for(int i = 0; i < slotsPos.Count; i++)
            ingridients.Add(null);
    }

    public void Cook()
    {
        foreach (RecipeData recipe in stationData.avaibleRecepies)
        {
            if (MatchesRecipe(recipe.IngridientList))
            {
                resultFood.SetFood(recipe.result);
                ClearIngridients();
                //return recipe.result;
            }
        }

        //return null;
    }

    private bool MatchesRecipe(List<FoodData> recipe)
    {
        List<FoodData> input = new List<FoodData>();

        foreach(GameObject ingridient in ingridients)
        {
            if (ingridient == null)
                continue;
            input.Add(ingridient.GetComponent<FoodObject>().FoodData);
        }

        if (recipe.Count != input.Count) return false;

        Dictionary<FoodData, int> counts = new Dictionary<FoodData, int>();

        foreach (FoodData ingridient in recipe)
        {
            if (counts.ContainsKey(ingridient))
                counts[ingridient]++;
            else
                counts.Add(ingridient, 1);
        }

        foreach (FoodData ingridient in input)
        {
            if (!counts.ContainsKey(ingridient))
                return false;

            counts[ingridient]--;

            if (counts[ingridient] < 0)
                return false;
        }
         
        return true;
    }

    public bool TryPlaceItem(GameObject item)
    {
        if (occupiedSlotsCount == slotsPos.Count)
            return false;

        ingridients[occupiedSlotsCount] = item;

        item.transform.position = slotsPos[occupiedSlotsCount].position;

        occupiedSlotsCount++;

        return true;
    }

    private void ClearIngridients()
    {
        occupiedSlotsCount = 0;

        for(int i = 0; i < ingridients.Count; i++)
        {
            if( ingridients[i] != null )
            {
                Destroy(ingridients[i]);
                
            }
        }
    }
}
