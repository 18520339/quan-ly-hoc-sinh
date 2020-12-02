﻿using BUS;
using DevComponents.DotNetBar;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyHocSinh
{
    public partial class frmKhoiLop : Office2007Form
    {
        public frmKhoiLop()
        {
            InitializeComponent();
        }

        private void frmKhoiLop_Load(object sender, EventArgs e)
        {
            KhoiLopBUS.Instance.HienThi(dgvKhoiLop, bindingNavigatorKhoiLop);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (dgvKhoiLop.RowCount == 0) bindingNavigatorDeleteItem.Enabled = true;
            
            BindingSource bindingSource = bindingNavigatorKhoiLop.BindingSource;
            DataTable dataTable = (DataTable)bindingSource.DataSource;
            DataRow dataRow = dataTable.NewRow();

            dataRow["MaKhoiLop"] = "";
            dataRow["TenKhoiLop"] = "";

            dataTable.Rows.Add(dataRow);
            bindingSource.MoveLast();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (dgvKhoiLop.RowCount == 0) bindingNavigatorDeleteItem.Enabled = false;
            else if (
                MessageBox.Show(
                    "Bạn có chắc chắn xóa dòng này không?",
                    "Xóa lớp học",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question
                ) == DialogResult.OK
            ) bindingNavigatorKhoiLop.BindingSource.RemoveCurrent();
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            string[] colNames = { "colMaKhoiLop", "colTenkhoiLop" };
            if (Utilities.KiemTraTruocKhiLuu(dgvKhoiLop, colNames))
            {
                bindingNavigatorPositionItem.Focus();
                BindingSource bindingSource = bindingNavigatorKhoiLop.BindingSource;
                KhoiLopBUS.Instance.LuuKhoiLop((DataTable)bindingSource.DataSource);

                MessageBox.Show(
                    "Dữ liệu đã được lưu vào CL",
                    "Cập nhật thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void bindingNavigatorExitItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
