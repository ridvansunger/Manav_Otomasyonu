using Manav_Otomasyonu.Core;
using Manav_Otomasyonu.Entities;
using Manav_Otomasyonu.Helper;
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
    public partial class ProductForm : Form
    {
        CategoryRepo categoryRepo;
        ProductRepo productRepo;
        

        public ProductForm()
        {
            InitializeComponent();

            categoryRepo = new CategoryRepo();
            productRepo = new ProductRepo();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            FillData();
            FillControl();
        }


        Product selectedItem = null;

        //burası çift tıklayınca product formu tage göre doldurur.
        private void FillData()
        {
            int productID = Convert.ToInt32(this.Tag);
            if(productID>0)
            {
                var product = productRepo.GetById(productID);
                if(product!=null)
                {
                    selectedItem = product;

                    txtProductName.Text = product.ProductName;
                    cmbCategoryId.SelectedValue = product.CategoryId;
                    txtQuantityPerUnit.Text = product.QuantityPerUnit;
                    nuUnitPrice.Value = Convert.ToDecimal(product.UnitPrice);
                    nuUnitsInStock.Value = Convert.ToInt16(product.UnitsInStock);
                    nuUnitsOnOrder.Value = Convert.ToInt16(product.UnitsOnOrder);
                    chkDiscontinued.Checked = product.Discontinued;
                }
            }
        }


        private void FillControl()
        {
            FillCategory();
        }

        private void FillCategory()
        {
            var categories = categoryRepo.Get();
            cmbCategoryId.DisplayMember = "CategoryName";
            cmbCategoryId.ValueMember = "CategoryId";
            cmbCategoryId.DataSource = categories;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FormSave();
        }
        private void FormSave()
        {
            try
            {
                if (this.selectedItem == null)
                {
                    this.selectedItem = new Product();
                }

                if (txtProductName.Text == "")
                {
                    MessageBox.Show("Ürün Adı Giriniz.");
                    return;
                }
                else
                {
                    this.selectedItem.ProductName = txtProductName.Text;
                }


                this.selectedItem.CategoryId = Convert.ToInt32(cmbCategoryId.SelectedValue);

                if (nuUnitPrice.Value == 0)
                {
                    MessageBox.Show("Ürün Fiyatı Giriniz");
                    return;
                }
                else
                {
                    this.selectedItem.UnitPrice = nuUnitPrice.Value;
                }
                if (txtQuantityPerUnit.Text == "")
                {
                    MessageBox.Show("Birim türü giriniz.");
                    return;
                }
                else
                {
                    this.selectedItem.QuantityPerUnit = txtQuantityPerUnit.Text;
                }

                if (nuUnitsInStock.Value == 0)
                {
                    MessageBox.Show("Stok adedi giriniz.");
                    return;
                }
                else
                {
                    this.selectedItem.UnitsInStock = Convert.ToInt16(nuUnitsInStock.Value);
                }
                if (nuUnitsOnOrder.Value == 0)
                {
                    MessageBox.Show("Sipariş adeti giriniz");
                    return;
                }
                else
                {
                    this.selectedItem.UnitsOnOrder = Convert.ToInt16(nuUnitsOnOrder.Value);
                }




                this.selectedItem.Discontinued = chkDiscontinued.Checked;

                if (Convert.ToInt32(this.Tag) == 0)
                {
                    this.selectedItem.ProductId = productRepo.Create(this.selectedItem);
                    this.Tag = this.selectedItem.ProductId;
                }

                else
                {
                    productRepo.Update(this.selectedItem);
                }

                Utilities.ShowSuccessMessage(ContsMessages.RecordSuccessMessage);
            }
            catch (Exception ex)
            {

                Utilities.ShowErrorMessage(ex.Message);
            }
                
        }

      



        private void DeleteProduct()
        {
            try
            {
                int id = Convert.ToInt32(this.Tag);
                if (id > 0)
                {
                    var result = Utilities.ShowDialogResultInformationMessage(ContsMessages.RecordDeleteQuestionMessage);
                    if (result == DialogResult.OK)
                    {
                        productRepo.Delete(id);
                        Utilities.ShowSuccessMessage(ContsMessages.RecordDeleteSuccessMessage);
                    }

                }
            }
            catch (Exception ex)
            {


                Utilities.ShowErrorMessage(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteProduct();
        }
    }
}
