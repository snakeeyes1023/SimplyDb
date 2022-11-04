using Engins.DbProvider;
using Engins.Tests.Repositories;
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarRepository carRepository = new CarRepository();

            var entity = carRepository.AddNewEntity();
            carRepository.Save();

            var entitySelected = carRepository.Entities.FillEntities().FirstOrDefault(x => x.Price > 0);

            entitySelected.Width = 100;

            carRepository.Save();
        }
    }
}