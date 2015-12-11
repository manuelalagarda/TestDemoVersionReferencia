using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestDemo
{
    public class ProcesoDemo
    {
        private AdventureWorks2008R2 context = new AdventureWorks2008R2();

        public void Ejecutar()
        {
            ActualizarPreciosDeLasLineasDeDetalle();
            //EliminarUltimaLineaDeDetalle();
            AnyadirNuevaLineaDeDetalle();
            GuardarCambios();            
        }

        private void ActualizarPreciosDeLasLineasDeDetalle()
        {
            var salesOrderDetails = context.SalesOrderDetails.Where(o => o.SalesOrderDetailID <= 1000);
            decimal increase = (decimal)1.10;
            foreach (var salesOrderDetail in salesOrderDetails)
            {
                salesOrderDetail.UnitPrice = salesOrderDetail.UnitPrice * increase;
            }
        }

        private void AnyadirNuevaLineaDeDetalle()
        {
            var salesOrderDetails = context.SalesOrderDetails;

            SalesOrderDetail newDetail = new SalesOrderDetail();
            newDetail.SalesOrderID = 75123;
            newDetail.OrderQty = 2;
            newDetail.ProductID = 712;
            newDetail.SpecialOfferID = 1;
            newDetail.UnitPrice = 1;
            newDetail.UnitPriceDiscount = 0;
            newDetail.ModifiedDate = DateTime.Now;

            salesOrderDetails.Add(newDetail);

        }

        private void EliminarUltimaLineaDeDetalle()
        {
            var salesOrderDetails = context.SalesOrderDetails;
            SalesOrderDetail lastDetail = salesOrderDetails.OrderByDescending(p => p.SalesOrderDetailID).FirstOrDefault();
            salesOrderDetails.Remove(lastDetail); 
        }

        private void GuardarCambios()
        {
            context.SaveChanges();
        }

    }
}
