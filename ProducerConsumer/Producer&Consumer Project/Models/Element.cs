using Producer_Consumer_Project.DTOS;

namespace Producer_Consumer_Project.Models
{
    public class Element
    {
        public string Id { get; set; }
        public int X {  get; set; }
        public int Y { get; set; }
        public string Color { get; set; }
        public string Text { get; set; }
        public List<Product> Products { get; set; }=new List<Product>();
        public Element(Dto dto)
        {
            this.Id=dto.Id;
            this.X=dto.X;
            this.Y=dto.Y;
            this.Color= "#ddd";
            this.Text=dto.Text;
        }
    }
}
