using PizzaStore.Models;

namespace PizzaStore.Data;

public static class PizzaDb
{
    public static List<Pizza> Pizzas = new List<Pizza>
    {
        new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
        new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true },
        new Pizza { Id = 3, Name = "Pepperoni", IsGlutenFree = false },
        new Pizza { Id = 4, Name = "Mediterranean Delight", IsGlutenFree = false },
        new Pizza { Id = 5, Name = "BBQ Chicken Supreme", IsGlutenFree = false },
        new Pizza { Id = 6, Name = "Quattro Formaggi", IsGlutenFree = false }
    };
}