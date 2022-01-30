using Manav_Otomasyonu.Entities;
using Manav_Otomasyonu.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manav_Otomasyonu
{
    public partial class Form1 : Form
    {
        ProductRepo productRepo;
        CategoryRepo categoryRepo;
        CustomerRepo customerRepo;
        public Form1()
        {
            InitializeComponent();
            productRepo = new ProductRepo();
            categoryRepo = new CategoryRepo();
            customerRepo = new CustomerRepo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillProductGrid();
            FillCategoriesGrid();
            FillCustomerGrid();
        }

        private void FillCustomerGrid()
        {
            grdCustomers.DataSource = customerRepo.Get();
        }

        private void FillCategoriesGrid()
        {
            grdCategories.DataSource = categoryRepo.Get();
        }

        private void FillProductGrid()
        {
            grdProducts.DataSource = productRepo.Get();
        }

        

        private void btnProduct_Click(object sender, EventArgs e)
        {
            ProductForm form = new ProductForm();
            form.ShowDialog();
            FillProductGrid();
        }

        private void grdProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            var product = (grdProducts.DataSource as List<Product>)[e.RowIndex];

            ProductForm form = new ProductForm();
            form.Tag = product.ProductId;
            form.ShowDialog();
            FillProductGrid();
        }




        private void btnCategory_Click(object sender, EventArgs e)
        {
            CategoryForm form = new CategoryForm();
            form.ShowDialog();
            FillCategoriesGrid();
        }

        private void grdCategories_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            var category = (grdCategories.DataSource as List<Category>)[e.RowIndex];

            CategoryForm form = new CategoryForm();
            form.Tag = category.CategoryID;
            form.ShowDialog();
            FillCategoriesGrid();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            CustomerForm form = new CustomerForm();
            form.ShowDialog();
            FillCustomerGrid();
        }

        private void grdCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            var customer = (grdCustomers.DataSource as List<Customer>)[e.RowIndex];

            CustomerForm form = new CustomerForm();
            form.Tag = customer.CustomerId;
            form.ShowDialog();
            FillCustomerGrid();
        }
    }
}
