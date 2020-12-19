using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using model;
using petshop.api.services;

namespace petshop.api.Controllers
{
    [Route("api/[controller]")]

    [ApiController] 
        public class AnimalController : Controller
    {
        public readonly MongoDbService _mongoDbService;
        

         public AnimalController(){
            _mongoDbService = new MongoDbService("AnimalDatabase", "Animal", "mongodb://127.0.0.1:27017");        }
  
        [HttpPost]

          public async Task Cadastrar ([FromBody] Animal animal){
            await _mongoDbService.Insere(animal);
          }

          [HttpGet]
          public async Task<JsonResult> PegarTodosAnimais(){
              var todosAnimais = await _mongoDbService.GetAllAnimals();
              return Json(todosAnimais);
         }
            [HttpGet("{id}", Name = "PegarAnimal")]
          public ActionResult<Animal> PegarAnimalPorId (string id){
              var animal = _mongoDbService.Get (id);
              if(animal == null){
                  return NotFound();
              }
              return animal;
          }

    }
}