﻿using DevExpress.XtraEditors;
using InspectionProcess.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InspectionProcess.Forms
{
    public partial class KeepingManagementForm : XtraForm
    {
        public KeepingManagementForm()
        {
            InitializeComponent();
        }

        protected async override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            //TODO : Asynchrous Method로 변경
            cbbWarehouse.DataSource = await DataRepository.Warehouse.GetAllAsync();
            cbbMerchandiseName.DataSource = DataRepository.Merchandise.GetAll();
            cbbMerchandiseName.SelectedItem = null;
            cbbWarehouse.SelectedItem = null;
        }



      

        private void uscSearch_SearchButtonClicked(object sender, UserControls.SearchButtonControl.SearchButtonClickedEventArgs e)
        {
          
            bdsKeeping.DataSource = DataRepository.Keeping.Search((int?)cbbWarehouse.SelectedValue, (DateTime?)dteKeepFrom.EditValue, (DateTime?)dteKeepTo.EditValue);
        }

        private void uscSearch_ResetButtonClicked(object sender, UserControls.SearchButtonControl.ResetButtonClickedEventArgs e)
        {
            //TODO : LookUpEdit로 변경
            cbbMerchandiseName.SelectedItem = null;
            cbbWarehouse.SelectedItem = null;
            dteKeepFrom.EditValue = null;
            dteKeepTo.EditValue = null;
        }

     
    }
}
