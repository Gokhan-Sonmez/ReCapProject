using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class FindeksCheckManager : IFindeksCheckService
    {
        ICustomerService _customerService;
        ICarService _carService;

        public FindeksCheckManager(ICustomerService customerService, ICarService carService)
        {
            _customerService = customerService;
            _carService = carService;
        }

        public bool CheckIfFindeksEnough(int customerId,int carId)
        {
            var carFindex = 0;

            var customerFindex = 0;
            var cars = _carService.GetCarDetailById(carId).Data;
            var customers = _customerService.GetCustomersDetailById(customerId).Data;

            foreach (var findex in cars)
            {
               carFindex = carFindex + findex.FindexScore;
            }

            foreach (var findex in customers)
            {
                customerFindex = customerFindex + findex.Findeks;
            }

            if (carFindex<= customerFindex)
            {

                return true;

            }
            else
            {
                return false;
            }
            
        }
    }
}
