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
    using Repository;
    using Entities;
    using Manav_Otomasyonu.Helper;
    using Manav_Otomasyonu.Core;

    public partial class CategoryForm : Form
    {


        CategoryRepo categoryRepo;
        public CategoryForm()
        {
            InitializeComponent();
            categoryRepo = new CategoryRepo();
        }



        private void CategoryForm_Load(object sender, EventArgs e)
        {
            FillData();
            FillControl();
        }

        private void FillControl()
        {
            FillUStCategoryId();
        }

        private void FillUStCategoryId()
        {
            var categories = categoryRepo.Get();
            cmbCategoryId.DisplayMember = "CategoryName";
            cmbCategoryId.ValueMember = "CategoryId";
            cmbCategoryId.DataSource = categories;

        }


        //çift tıklaınca formu doldur
        Category selectedItem = null;
        private void FillData()
        {
            int categoryId = Convert.ToInt32(this.Tag);
            if(categoryId>0)
            {
                var category = categoryRepo.GetById(categoryId);
                if(category!=null)
                {
                    selectedItem = category;

                    txtCategoryName.Text = category.CategoryName;
                    cmbCategoryId.SelectedValue = category.UstCategoryId;
                    rchtxtDescription.Text = category.Description;
                }
            }
        }

        private void brnSave_Click(object sender, EventArgs e)
        {
            FormSave();
            
        }

        private void FormSave()
        {
            try
            {
                if (this.selectedItem == null)
                {
                    this.selectedItem = new Category();
                }


                if (txtCategoryName.Text == "")
                {
                    MessageBox.Show("Ketegori adı giriniz");
                    return;
                }
                else
                {
                    this.selectedItem.CategoryName = txtCategoryName.Text;
                }


                this.selectedItem.UstCategoryId = Convert.ToInt32(cmbCategoryId.SelectedValue);
                this.selectedItem.Description = rchtxtDescription.Text;




                if (Convert.ToInt32(this.Tag) == 0)
                {
                    this.selectedItem.CategoryID = categoryRepo.Create(this.selectedItem);
                    this.Tag = this.selectedItem.CategoryID;
                }
                else
                {
                    categoryRepo.Update(this.selectedItem);
                }
                Utilities.ShowSuccessMessage(ContsMessages.RecordSuccessMessage);
            }
            catch (Exception ex)
            {

                Utilities.ShowErrorMessage(ex.Message);
            }
                    
        }

        private void brnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(this.Tag);
                if (id > 0)
                {
                    var result = Utilities.ShowDialogResultInformationMessage(ContsMessages.RecordDeleteQuestionMessage);
                    if(result==DialogResult.OK)
                    {
                        categoryRepo.Delete(id);
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
