using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        private List<Car> _cars;   // Fake database yaratıyoruz.

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id = 1,BrandId = 1,ColorId = 1,DailyPrice = 250000,Description = "Siyah Audi A3",ModelYear = 2013},
                new Car{Id = 2,BrandId = 1,ColorId = 2,DailyPrice = 200000,Description = "Beyaz Audi A3",ModelYear = 2011},
                new Car{Id = 3,BrandId = 2,ColorId = 3,DailyPrice = 150000,Description = "Gri Suzuki Vitara",ModelYear = 2015},
                new Car{Id = 4,BrandId = 3,ColorId = 1,DailyPrice = 300000,Description = "Siyah Mercedes G63 AMG",ModelYear = 2018}
            };
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void GetById(int Id)
        {
            Car getByIdToCar = _cars.SingleOrDefault(c => c.Id == Id);
            if (getByIdToCar == null)
            {
                Console.WriteLine("Seçtiğiniz id'ye göre araba bulunamadı.");
            }
            else
            {
                Console.WriteLine("{0} isimli araba getirildi.", getByIdToCar.Description);
            }
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);  // Gönderdiğim araç id'sine sahip olan
            carToUpdate.Id = car.Id;                                          //        listedeki aracı bul.
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }
    }
}
