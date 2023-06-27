using CarDealerApi.Models;

namespace CarDealerApi.Interface
{
    public interface CarInterface
    {
        ICollection<Car> GetCars();
        Car GetCar(int id);
        bool CarExits(int id);
        bool CreateCar(Car car);
        bool Save();
    }
}
