using Bakery.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Bakery.ImportConsole
{
    public class ImportController
    {
        private const string ProductFileName = "Products.csv";
        private const string OrderItemFileName = "OrderItems.csv";
        public static IEnumerable<Product> ReadFromCsv()
        {
            string[][] productMatrix = MyFile.ReadStringMatrixFromCsv(ProductFileName, true);

            var products = productMatrix.GroupBy(line => line[0] + ';' +
                                                         line[1] + ';' +
                                                         line[2] + ';')
                                        .Select(grp => new Product
                                        {
                                            ProductNr = grp.Key.Split(';')[0],
                                            Name = grp.Key.Split(';')[1],
                                            Price = Convert.ToDouble(grp.Key.Split(';')[2])
                                        })
                                        .ToArray();

            string[][] orderMatrix = MyFile.ReadStringMatrixFromCsv(OrderItemFileName, true);


            throw new NotImplementedException();
        }
    }
}
