using Microsoft.AspNetCore.Mvc;
using PizzaStore.Models;
using PizzaStore.Data;

namespace PizzaStore.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() => PizzaDb.Pizzas;

    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = PizzaDb.Pizzas.FirstOrDefault(p => p.Id == id);
        if (pizza == null)
            return NotFound();
        return pizza;
    }

    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        PizzaDb.Pizzas.Add(pizza);
        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        if (id != pizza.Id)
            return BadRequest();

        var existingPizza = PizzaDb.Pizzas.FirstOrDefault(p => p.Id == id);
        if (existingPizza == null)
            return NotFound();

        existingPizza.Name = pizza.Name;
        existingPizza.IsGlutenFree = pizza.IsGlutenFree;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = PizzaDb.Pizzas.FirstOrDefault(p => p.Id == id);
        if (pizza == null)
            return NotFound();

        PizzaDb.Pizzas.Remove(pizza);
        return NoContent();
    }
}