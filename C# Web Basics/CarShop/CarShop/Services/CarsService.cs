namespace CarShop.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    using CarShop.Data;
    using CarShop.Data.Models;
    using CarShop.Services.Contracts;
    using CarShop.ViewModels;
    using Microsoft.EntityFrameworkCore;
    using static CarShop.Common.GlobalConstants;

    public class CarsService : ICarsService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IUsersService usersService;

        public CarsService(
            ApplicationDbContext dbContext,
            IUsersService usersService)
        {
            this.dbContext = dbContext;
            this.usersService = usersService;
        }

        public List<string> CarValidation(CarInputModel input)
        {
            var errorList = new List<string>();

            if (string.IsNullOrWhiteSpace(input.Model) || input.Model.Length > CarModelMaxLength || input.Model.Length < CarModelMinLength)
            {
                errorList.Add(string.Format(InvalidCarModelLength, CarModelMinLength, CarModelMaxLength));
            }

            if (string.IsNullOrWhiteSpace(input.Image) || input.Model.Length > PictureUrlMaxLength)
            {
                errorList.Add(InvalidPictureUrl);
            }

            if (input.Year < MinYear || input.Year > DateTime.Now.Year)
            {
                errorList.Add(InvalidYear);
            }

            if (string.IsNullOrWhiteSpace(input.PlateNumber) || !new RegularExpressionAttribute(PlateNumberRegexPattern).IsValid(input.PlateNumber))
            {
                errorList.Add(InvalidPlateNumber);
            }

            return errorList;
        }

        public async Task AddCar(CarInputModel input)
        {
            var car = new Car
            {
                Model = input.Model,
                PictureUrl = input.Image,
                PlateNumber = input.PlateNumber,
                Year = input.Year,
                OwnerId = input.OwnerId,                
            };

            await this.dbContext.Cars.AddAsync(car);
            await this.dbContext.SaveChangesAsync();
        }

        public ICollection<CarViewModel> GetAllCars(string userId)
        {
            bool isUserMachanic = this.usersService.IsUserMechanic(userId);

            var cars = new List<CarViewModel>();

            if (!isUserMachanic)
            {
                cars = this.dbContext.Cars
                    .Include(c => c.Issues)
                    .Where(c => c.Owner.Id == userId)
                    .Select(c => new CarViewModel
                    { 
                        Id = c.Id,
                        Model = c.Model,
                        PictureUrl = c.PictureUrl,
                        PlateNumber = c.PlateNumber,
                        Issues = c.Issues,
                        Year = c.Year,
                    })
                    .ToList();
            }
            else
            {
                cars = this.dbContext.Cars
                    .Include(c => c.Issues)
                    .Where(c => c.Issues.Any(i => i.IsFixed == false))
                    .Select(c => new CarViewModel
                    {
                        Id = c.Id,
                        Model = c.Model,
                        PictureUrl = c.PictureUrl,
                        PlateNumber = c.PlateNumber,
                        Issues = c.Issues,
                        Year = c.Year,
                    })
                    .ToList();
            }

            return cars;
        }
    }
}