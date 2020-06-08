using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.DAL.Contract;
using Grocery.BLL.Entities;

namespace Grocery.BLL.Activities
{
    public class GetReportDetailedActivity : IGetReportDetailedActivity
    {
        private IClassRepository classRepository;
        private ISaleRepository saleRepository;
        private IProductRepository productRepository;

        public GetReportDetailedActivity(IClassRepository classRepository, ISaleRepository saleRepository, IProductRepository productRepository)
        {
            this.classRepository = classRepository;
            this.saleRepository = saleRepository;
            this.productRepository = productRepository;
        }

        public List<ReportDetailed> Run(Category category, DateTime sinceDate, DateTime toDate)
        {
            List<ReportDetailed> reportDetaileds = new List<ReportDetailed>();

            int id = 0;

            classRepository.GetNewAll();
            foreach (Class curClass in classRepository.GetAll())
            {
                id++;

                int arrivedCount = 0;
                int saledCount = 0;
                int returnedCount = 0;
                float sum = 0.0f;
                float revenue = 0.0f;
                float percentRevenue = 0.0f;

                productRepository.GetNewAll();
                foreach (Product curProduct in productRepository.GetAll())
                {
                    if (curClass.Id == curProduct.Class.Id && category.Id == curProduct.Category.Id)
                    {
                        if (sinceDate <= curProduct.ArrivedGoods.DateTime && toDate >= curProduct.ArrivedGoods.DateTime)
                        {
                            arrivedCount += curProduct.ArrivedGoods.Count;
                        }

                        if (curProduct.ReturnedDate != null)
                        {
                            if (sinceDate <= curProduct.ReturnedDate.Value && toDate >= curProduct.ReturnedDate.Value && curProduct.Returned)
                            {
                                returnedCount++;
                            }
                        }
                    }
                }

                saleRepository.GetNewAll();
                foreach (Sale curSale in saleRepository.GetAll())
                {
                    if (sinceDate <= curSale.Datetime && toDate >= curSale.Datetime && curClass.Id == curSale.Product.Class.Id && category.Id == curSale.Product.Category.Id)
                    {
                        saledCount += curSale.Count;
                        sum += curSale.Price;
                        revenue += curSale.Price - curSale.Product.PurchasePrice;
                    }
                }

                foreach (Sale curSale in saleRepository.GetAll())
                {
                    if (sinceDate <= curSale.Datetime && toDate >= curSale.Datetime && curClass.Id == curSale.Product.Class.Id && category.Id == curSale.Product.Category.Id)
                    {
                        float curRevenue = curSale.Price - curSale.Product.PurchasePrice;
                        percentRevenue = (revenue * curRevenue) / 100f;
                    }
                }

                ReportDetailed reportDetailed = new ReportDetailed()
                {
                    Id = id,
                    Category = category,
                    Class = curClass,
                    ArrivedCount = arrivedCount,
                    SaledCount = saledCount,
                    ReturnedCount = returnedCount,
                    Sum = sum,
                    Revenue = revenue,
                    PercentRevenue = percentRevenue,
                };

                reportDetaileds.Add(reportDetailed);
            }
            
            return reportDetaileds;
        }
    }
}
