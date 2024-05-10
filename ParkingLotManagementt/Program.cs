using BUL;
using DTO;
using Emgu.CV.OCR;
using OpenTK.Graphics.OpenGL;
using ParkingLotManagementt.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingLotManagementt
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
            // Application.Run(new frmChangePriceParking());
            //Application.Run(new frmMain());
            //Application.Run(new frmStaticContract());
            //Application.Run(new frmManagerConductFromAdmin(Manager_BUL.GetManager("123")));
            /*Application.Run(new frmMain());
            Application.Run(new frmStaticContract());*/
            /*Application.Run(new frmComfirmEmail(true));
            Application.Run(new frmChangePassword("tieanh"));*/
            /* var customer = BUL.Customer_BUL.GetCustomer("1");
             Application.Run(new frmMainCustomer(customer));*/
            /*var Worker = BUL.Worker_BUL.GetWorker("123478");
            Application.Run(new frmMainWorker(Worker));*/
            //Application.Run(new frmViewContractParkArea());
            //var customer = BUL.Customer_BUL.GetCustomer("1");
            //Application.Run(new frmMainCustomer(customer));
            // var Worker = BUL.Worker_BUL.GetWorker("1478");
            // Application.Run(new frmMainWorkerPaking(Worker));
            /*//var dt = BUL.ContractDetail_BUL.GetContractDetail(new Worker_DTO("1478",""));
            Application.Run (new frmMain ());
            Application.Run(new frmLogin());
            //Application.Run(new frmProfileCustomer());
            var customer = BUL.Customer_BUL.GetCustomer("1");
           // Application.Run(new frmMainCustomer(customer));
            var Worker = BUL.Worker_BUL.GetWorker("123478");
            //Worker.ParkArea = BUL.ParkArea_BUL.GetParkArea(Worker.ParkArea.ParkAreaId, true);
            Application.Run(new frmMainWorker(Worker));
            Application.Run(new frmMainWorkerPaking(Worker));
            // Application.Run(new TestLicense());
            Application.Run(new frmScheduler());
            Application.Run(new frmViewDetailParkAreaForAdmin(BUL.ParkArea_BUL.GetParkArea("3",true)));
            //Application.Run(new frmViewVehicleEntryAndExitHistory(BUL.ParkArea_BUL.GetParkArea("3", true)));
            /*var fee = BUL.Fee_BUL.GetFee();
            fee.FeeCar = 7.8;
            BUL.Fee_BUL.UpdateFeeMoto (fee);
            MessageBox.Show(fee.ToString());*/
            // Application.Run(new frmViewDetailParkAreaForAdmin(BUL.ParkArea_BUL.GetParkArea("3", true)));
            /*var Worker = BUL.Worker_BUL.GetWorker("1980");
            Worker.ParkArea = BUL.ParkArea_BUL.GetParkArea(Worker.ParkArea.ParkAreaId, true);
            Application.Run(new frmMainWorkerPaking(Worker));*/
            // Application.Run(new frmScheduler());
            /*var Vehicle = BUL.Vehicle_BUL.GetMyVehicle("73-AG-01897");

            Application.Run(new VehicleAndContract(Vehicle));*/
            /*var Worker = BUL.Worker_BUL.GetWorker("0405");
            Worker.ParkArea = BUL.ParkArea_BUL.GetParkArea(Worker.ParkArea.ParkAreaId, true);
            Application.Run(new frmMainWorkerPaking(Worker));*/
            /*Contract_DTO myContract = Contract_BUL.GetContract("117|04|2024|10|44|06");
            Application.Run(new frmPayMentForCustomer(myContract));*/
        }
    }
}
