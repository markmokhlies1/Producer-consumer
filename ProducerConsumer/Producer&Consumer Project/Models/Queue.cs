using Producer_Consumer_Project.DTOS;
using System.Collections;

namespace Producer_Consumer_Project.Models
{
    public class Queue : Element
    {
        private Dictionary<string, Machine> outMachines = new Dictionary<string, Machine>();
        private Dictionary<string, Machine> freeMachines = new Dictionary<string, Machine>();
        private Thread thread;

        public Queue(Dto dto) : base(dto)
        {
        }
        public void AddFreeMachine(string machineID)
        {
            if (outMachines.TryGetValue(machineID, out var machine))
            {
                freeMachines[machineID] = machine; // Add or update in freeMachines
            }
        }
        public void AddToProduct(Product product)
        {
            base.Products.Add(product);
        }
        public void RemoveBusyMachine(string machineID)
        {
            if (outMachines.TryGetValue(machineID, out var machine))
            {
                freeMachines.Remove(machineID); // Remove by key
            }
        }
        public void AddToOutMachines(Machine machine)
        {
            outMachines[machine.Id] = machine; // Adds or updates the dictionary entry
        }

        public void AddToFreeMachines(Machine machine)
        {
            freeMachines[machine.Id] = machine; // Adds or updates the dictionary entry
        }
        public void Run()
        {
            if (freeMachines.Any())
            {
                var firstMachine = freeMachines.First().Value;
                firstMachine.SetProduct(base.Products[0]);
                base.Products.RemoveAt(0);
            }

        }
        public override string ToString()
        {
            return $"Queue{{products={base.Products}, freeMachines={string.Join(", ", freeMachines)}}}";
        }

    }
}
