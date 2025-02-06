using Producer_Consumer_Project.DTOS;

namespace Producer_Consumer_Project.Controllers
{
    public class SimulatorFacad
    {
        private SimulatorService simulatorService;

        public SimulatorFacad(List<Dto> dtos, int productsNumberInStock)
        {
            simulatorService = SimulatorService.GetInstance();
            simulatorService.RootGraph=dtos;
            simulatorService.productsNumberInStock = productsNumberInStock;
        }

        public async Task StartSimulationAsync()
        {
            simulatorService.BuildElements();
            simulatorService.MakeRelations();
            await simulatorService.RunSimulationAsync();
        }

        public SimulatorService GetSimulatorService()
        {
            return simulatorService;
        }

    }
}
