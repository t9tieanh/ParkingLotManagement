using DTO;
using ParkingLotManagementt.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingLotManagementt.UC_Controls
{
    public partial class UC_Manager : UserControl
    {
        private Manager_DTO myManager; 
        private frmManagerConductFromAdmin frmManagerConductFromAdmin;
        private void SetManager ()
        {
            try
            {
                picManager.Image = myManager.Picture != null ? Image.FromStream(myManager.Picture) : picManager.Image;
            }catch { }
            lblTypeManager.Text = myManager.ParkArea == null ? "admin" : "manager of " + myManager.ParkArea.Address;
            lblNameManager.Text = myManager.FullName;
            lblManagerID.Text = myManager.ManagerId;
        }
        public UC_Manager()
        {
            InitializeComponent();
        }
        public UC_Manager(Manager_DTO myManager,frmManagerConductFromAdmin frmManagerConductFromAdmin)
        {
            InitializeComponent();
            this.myManager = myManager; 
            this.frmManagerConductFromAdmin = frmManagerConductFromAdmin;
            SetManager();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            frmManagerConductFromAdmin.LoadDentailManager(myManager);
        }
    }
}
