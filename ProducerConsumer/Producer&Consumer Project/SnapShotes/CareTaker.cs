using Producer_Consumer_Project.Controllers;

namespace Producer_Consumer_Project.SnapShotes
{
    public class CareTaker
    {
        public static CareTaker careTaker { get; set; } = null;
        public static SimulatorService simulatorService { get; set; }

        public static CareTaker GetInstance()
        {
            if (careTaker == null)
            {
                careTaker = new CareTaker();
                simulatorService = SimulatorService.GetInstance();
            }
            return careTaker;
        }

        private List<SnapShot> snapshots = new List<SnapShot>();

        public void AddSnapshot()
        {
            snapshots.Add(MakeSnapshot());
        }

        public SnapShot GetSnapshot(int index)
        {
            return snapshots[index];
        }

        public SnapShot MakeSnapshot()
        {
            return new SnapShot(
                SimulatorService.GetInstance().elements,
                SimulatorService.GetInstance().productsNumberInStock,
                SimulatorService.GetInstance().RootGraph);
        }

    }
}
