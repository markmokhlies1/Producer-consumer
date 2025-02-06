using Producer_Consumer_Project.DTOS;
using Producer_Consumer_Project.Models;

namespace Producer_Consumer_Project.Controllers
{
    public class objectFactory
    {
        public static Element GetObject(Dto dto)
        {
            switch (dto.Type)
            {
                case "machine":
                    int min = 3;
                    int max = 8;
                    int randomTime = new Random().Next(min, max + 1); // Generates a random number between min and max (inclusive)
                    return new Machine(dto, randomTime);

                case "queue":
                    return new Queue(dto);

                default:
                    return null;
            }
        }
    }
}
