using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.DAL.Contract;
using Grocery.BLL.Entities;

namespace Grocery.BLL.Activities
{
    public class GetSellerActivity : IGetSellerActivity
    {
        private ISellerRepository sellerRepository;

        public GetSellerActivity(ISellerRepository sellerRepository)
        {
            this.sellerRepository = sellerRepository;
        }

        public Seller Run(User user)
        {
            Seller seller = null;

            sellerRepository.GetNewAll();
            foreach (Seller curSeller in sellerRepository.GetAll())
            {
                if (user.Id.Equals(curSeller.User.Id))
                {
                    seller = new Seller()
                    {
                        Id = curSeller.Id,
                        Surname = curSeller.Surname,
                        FirstName = curSeller.FirstName,
                        SecondName = curSeller.SecondName,
                        PassportSeries = curSeller.PassportSeries,
                        PassportNumber = curSeller.PassportNumber,
                        TIN = curSeller.TIN,
                        BirthDate = curSeller.BirthDate,
                        PhoneNumber = curSeller.PhoneNumber,
                        Address = curSeller.Address,
                        Department = curSeller.Department,
                        User = curSeller.User,
                        Fired = curSeller.Fired,
                        FiredDate = curSeller.FiredDate
                    };
                    break;
                }
            }

            if (seller == null)
                throw new Exception("The seller is not found!");

            return seller;
        }
    }
}
