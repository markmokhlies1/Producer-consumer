using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Producer_Consumer_Project.DTOS;

namespace Producer_Consumer_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class systemControllers : ControllerBase
    {
        // POST /start_simulate
        [HttpPost("start_simulate")]
        public async Task<IActionResult> StartSimulation([FromBody] Dto dto)
        {
            var simulatorFacade = new SimulatorFacad(dto.RootGraph, dto.ProductsNumberInStock);
            await simulatorFacade.StartSimulationAsync();
            return Ok();
        }

        // GET /get_changes
        [HttpGet("get_changes")]
        public IActionResult GetChanges()
        {
            var simulatorService = SimulatorService.GetInstance();
            var dtos = new List<Dto>();

            foreach (var entry in simulatorService.elements)
            {
                var dto = new Dto
                {
                    Id = entry.Value.Id,
                    Color = entry.Value.Color,
                    NumberOfProducts = entry.Value.Products.Count
                };
                dtos.Add(dto);
            }

            var responseDto = new Dto
            {
                RootGraph = dtos
            };

            return Ok(responseDto);
        }

        // PUT /add_product
        [HttpPut("add_product")]
        public IActionResult AddProduct()
        {
            var simulatorService = SimulatorService.GetInstance();
            simulatorService.AddProduct();
            return NoContent(); // No content as a response
        }
    }
}
