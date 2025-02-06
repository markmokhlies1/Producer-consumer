namespace Producer_Consumer_Project.DTOS
{
    public class Dto
    {
        public int X {  get; set; }
        public int Y {  get; set; }
        public int NumberOfProducts {  get; set; }
        public int ProductsNumberInStock {  get; set; }
        public string Type {  get; set; }
        public string Color {  get; set; }
        public string Id {  get; set; }
        public string Text {  get; set; }
        public List<string> MachineToQueue { get; set; }// all ids of machine that connected as input to that queue
        public List<string> QueueToMachine { get; set; }// all ids of machine that connected as output to that queue
        public List<Dto> RootGraph {  get; set; }
    }
}
