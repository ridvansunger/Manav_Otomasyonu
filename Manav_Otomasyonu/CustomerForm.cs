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
    public partial class CustomerForm : Form
    {

        CustomerRepo customerRepo;
        ProductRepo productRepo;
        public CustomerForm()
        {
            InitializeComponent();
            customerRepo = new CustomerRepo();
            productRepo = new ProductRepo();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            FillData();

        }


        Customer selectedItem = null;
        //gride çift tıklayınca customerformu doldur.
        private void FillData()
        {
            int customerId = Convert.ToInt32(this.Tag);
            if (customerId > 0)
            {
                var customer = customerRepo.GetById(customerId);
                if (customer != null)
                {
                    selectedItem = customer;//insert update ?

                    txtFirstName.Text = customer.FirstName;
                    txtLastName.Text = customer.LastName;
                    txtCity.Text = customer.City;
                    txtRegion.Text = customer.Region;
                    txtPhone.Text = customer.Phone;


                }

            }
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
                    this.selectedItem = new Customer();
                }

                if (txtFirstName.Text == "")
                {
                    MessageBox.Show("Müşteri adı giriniz");
                    return;
                }
                else
                {
                    this.selectedItem.FirstName = txtFirstName.Text;
                }
                if (txtLastName.Text == "")
                {
                    MessageBox.Show("Müşteri soyadı giriniz");
                    return;
                }
                else
                {
                    this.selectedItem.LastName = txtLastName.Text;
                }
                if (txtCity.Text == "")
                {
                    MessageBox.Show("Şehir yazınız");
                    return;
                }
                else
                {
                    this.selectedItem.City = txtCity.Text;
                }
                if (txtRegion.Text == "")
                {
                    MessageBox.Show("Bölge giriniz");
                    return;
                }
                else
                {
                    this.selectedItem.Region = txtRegion.Text;
                }



                this.selectedItem.Phone = txtPhone.Text;


                if (Convert.ToInt32(this.Tag) == 0)
                {
                    //insert işlemi
                    this.selectedItem.CustomerId = customerRepo.Create(this.selectedItem);
                    this.Tag = this.selectedItem.CustomerId;
                }
                else
                {
                    //update
                    customerRepo.Update(this.selectedItem);
                }


                Utilities.ShowSuccessMessage(ContsMessages.RecordSuccessMessage);
            }
            catch (Exception ex)
            {

                Utilities.ShowErrorMessage(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(this.Tag);
                if (id > 0)
                {
                    var result = Utilities.ShowDialogResultInformationMessage(ContsMessages.RecordDeleteQuestionMessage);
                    if (result == DialogResult.OK)
                    {
                        customerRepo.Delete(id);
                        Utilities.ShowSuccessMessage(ContsMessages.RecordDeleteSuccessMessage);
                    }
                 
                }
            }
            catch (Exception ex)
            {

                Utilities.ShowErrorMessage(ex.Message);
            }
        }
    }
}
