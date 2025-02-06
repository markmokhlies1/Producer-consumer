using Producer_Consumer_Project.DTOS;
using Producer_Consumer_Project.Models;
using Producer_Consumer_Project.SnapShotes;

namespace Producer_Consumer_Project.Controllers
{
    public class SimulatorService
    {
        public Dictionary<string, Element> elements { get; set; } = new Dictionary<string, Element>();
        public static SimulatorService simulatorService = null;
        public int productsNumberInStock { get; set; }
        public List<Dto> RootGraph { get; set; }

        public static SimulatorService GetInstance()
        {
            if (simulatorService == null)
            {
                simulatorService = new SimulatorService();
            }
            return simulatorService;
        }

        public void AddProduct()
        {
            productsNumberInStock++;
        }

        // Build the elements
        public void BuildElements()
        {
            foreach (var dto in RootGraph)
            {
                elements[dto.Id] = objectFactory.GetObject (dto); // Assumes a static factory method
            }
        }

        // Make the relation of the graph
        public void MakeRelations()
        {
            foreach (var dto in RootGraph)
            {
                if (dto.Type == "queue")
                {
                    foreach (var machineId in dto.MachineToQueue)
                    {
                        ((Machine)elements[machineId]).outQueue=((Queue)elements[dto.Id]);
                    }
                    foreach (var machineId in dto.QueueToMachine)
                    {
                        ((Machine)elements[machineId]).addToInQueues((Queue)elements[dto.Id]);
                        ((Queue)elements[dto.Id]).AddToOutMachines((Machine)elements[machineId]);
                        ((Queue)elements[dto.Id]).AddToFreeMachines((Machine)elements[machineId]);
                    }
                }
            }
        }

        // Start simulation
        public async Task RunSimulationAsync()
        {
            int allCounts = productsNumberInStock;

            while (true)
            {
                int min = 1;
                int max = 5;
                int randomTime = new Random().Next(min, max + 1);
                await Task.Delay(randomTime * 1000); // Sleep for randomTime seconds

                if (productsNumberInStock > 0)
                {
                    ((Queue)elements["0"]).AddToProduct(new Product());
                    productsNumberInStock--;
                }

                CareTaker.GetInstance().AddSnapshot();
            }
        }

    }
}
