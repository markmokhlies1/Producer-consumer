namespace Producer_Consumer_Project.Models
{
    public class Product
    {
        public string Color {  get; set; }
        public static int Index { get; set; } = 0;

        private static List<string> colores = new List<string>()
        {
            "red","green","yellow","pink","blue","#ffba00", "orange", "purple", "#224B0C" ,"#CE49BF"
        };
        public Product()
        {
            int min = 0;
            int max = colores.Count - 1;
            int randomId = (Index++) % 10;
            this.Color = colores[randomId];
        }

    }
}
