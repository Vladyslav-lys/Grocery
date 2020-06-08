using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.DAL.Contract;
using Grocery.BLL.Entities;

namespace Grocery.BLL.Activities
{
    public class GetTareChangeActivity : IGetTareChangeActivity
    {
        private ITareChangeRepository tareChangeRepository;

        public GetTareChangeActivity(ITareChangeRepository tareChangeRepository)
        {
            this.tareChangeRepository = tareChangeRepository;
        }

        public List<TareChange> Run()
        {
            List<TareChange> tareChanges = new List<TareChange>();

            tareChangeRepository.GetNewAll();
            foreach (TareChange curTareChange in tareChangeRepository.GetAll())
            {
                TareChange tareChange = new TareChange()
                {
                    Id = curTareChange.Id,
                    Name = curTareChange.Name
                };

                tareChanges.Add(tareChange);
            }
            
            return tareChanges;
        }
    }
}
