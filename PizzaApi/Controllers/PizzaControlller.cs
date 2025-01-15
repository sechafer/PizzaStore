using Microsoft.AspNetCore.Mvc;
using PizzaApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace PizzaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        // Lista estática de pizzas predefinidas
        private static List<Pizza> _pizzas = new List<Pizza>
        {
            new Pizza { Id = 1, Name = "Italiana Clasica", IsGlutenFree = false, Price = 10.99m },
            new Pizza { Id = 2, Name = "Vegana", IsGlutenFree = true, Price = 11.99m },
            new Pizza { Id = 3, Name = "Paulista Clasica", IsGlutenFree = false, Price = 12.99m },
            new Pizza { Id = 4, Name = "Pepperoni Supreme", IsGlutenFree = false, Price = 13.99m },
            new Pizza { Id = 5, Name = "Cinco Quesos", IsGlutenFree = false, Price = 25.99m }
        };

        // Método GET para obtener todas las pizzas
        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() => _pizzas;

        // Método GET para obtener una pizza por su ID
        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = _pizzas.FirstOrDefault(p => p.Id == id);
            if (pizza == null)
                return NotFound(); // Devuelve 404 si la pizza no se encuentra
            return pizza;
        }

        // Método POST para crear una nueva pizza
        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {
            _pizzas.Add(pizza);
            return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza); // Devuelve 201 Created con la URL de la nueva pizza
        }

        // Método PUT para actualizar una pizza existente por su ID
        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza)
        {
            var existingPizza = _pizzas.FirstOrDefault(p => p.Id == id);
            if (existingPizza == null)
                return NotFound(); // Devuelve 404 si la pizza no se encuentra

            existingPizza.Name = pizza.Name;
            existingPizza.IsGlutenFree = pizza.IsGlutenFree;
            existingPizza.Price = pizza.Price;

            return NoContent(); // Devuelve 204 No Content
        }

        // Método DELETE para eliminar una pizza por su ID
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pizza = _pizzas.FirstOrDefault(p => p.Id == id);
            if (pizza == null)
                return NotFound(); // Devuelve 404 si la pizza no se encuentra

            _pizzas.Remove(pizza);
            return NoContent(); // Devuelve 204 No Content
        }
    }
}