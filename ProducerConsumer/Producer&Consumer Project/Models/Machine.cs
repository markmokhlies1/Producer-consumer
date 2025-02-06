using Producer_Consumer_Project.DTOS;

namespace Producer_Consumer_Project.Models
{
    public class Machine : Element
    {
        public int OperatingTime { get; set; }
        public List<Queue> inQueues { get; set; } = new List<Queue>();
        public Queue outQueue { get; set; }

        private Product product = null;
        public Machine(Dto dto, int operatingTime) : base(dto)
        {
            this.OperatingTime = operatingTime;
        }

        public void addToInQueues(Queue queue)
        {
            inQueues.Add(queue);
        }
        public void machineNotifyFree()
        {
            this.Color="#ddd";
            foreach (Queue queue in inQueues) 
            {
                queue.AddFreeMachine(this.Id);
            }
        }
        public  void SetProduct(Product product)
        {
            this.product = product;
            machineNotifyBusy();
            this.Color=product.Color;
        }
        public void machineNotifyBusy()
        {
            foreach (Queue queue in inQueues)
            {
                queue.RemoveBusyMachine(this.Id);
            }
        }
        public void Run()
        {
            outQueue.AddToProduct(product);
            product = null;
            machineNotifyFree();
        }
        public override string ToString()
        {
            return $"Machine{{product={product}}}";
        }

    }
}
