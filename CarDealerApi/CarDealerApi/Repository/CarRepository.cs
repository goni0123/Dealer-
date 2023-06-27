using CarDealerApi.Data;
using CarDealerApi.Interface;
using CarDealerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealerApi.Repository
{
    public class CarRepository : CarInterface
    {
        private readonly AppDBContext _context;
        public CarRepository(AppDBContext context) => _context = context;
        public bool CarExits(int id)
        {
            return _context.cars.Any(u => u.Id == id);
        }

        public bool CreateCar(Car car)
        {
            _context.Add(car);
            return Save();
        }

        public Car GetCar(int id)
        {
            return _context.cars.Where(u => u.Id == id).FirstOrDefault() ?? null;
        }

        public ICollection<Car> GetCars()
        {
            return _context.cars.OrderBy(u => u.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
