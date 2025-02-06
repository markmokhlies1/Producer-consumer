using Producer_Consumer_Project.DTOS;
using Producer_Consumer_Project.Models;

namespace Producer_Consumer_Project.SnapShotes
{
    public class SnapShot
    {
        public Dictionary<string, Element> elements { get; set; }
        public int productsNumberInStock { get; set; }
        public List<Dto> rootGraph { get; set; }
        public List<Dto> dtos { get; set; }
        public string elementtttttt { get; set; }

        public SnapShot(Dictionary<string, Element> elements, int productsNumberInStock, List<Dto> rootGraph)
        {
            elementtttttt = elements.ToString(); // Converts the dictionary to string (you can adjust this depending on the expected result)
            dtos = new List<Dto>();
            foreach (var entry in elements)
            {
                var dto = new Dto
                {
                    Id = entry.Value.Id,
                    Color = entry.Value.Color,
                    NumberOfProducts = entry.Value.Products.Count
                };
                dtos.Add(dto);
            }
        }
    }
}
