using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SQLConnectionAPP
{
    public partial class frmCnctionStudent : Form
    {
        
        public frmCnctionStudent()
        {
            InitializeComponent();
            
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                DisplayData();
            }
            else
            {
                string eq = txtID.Text;

                datagrviewStudent.DataSource = CRUD.Read(eq);
                datagrviewStudent.Visible = true;

            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            HideData();
        }


        // Formun Yenilənməsi zamanı bütün fokusun yaratdığımız fokus labelində olmasını təmin edirik.
        private void frmCnctionStudent_Load(object sender, EventArgs e)
        {
            ActiveControl = lblFocus;
            DisplayData();
            cmboxGender.Text = "---SELECT---";
        }


        
        /* DataGridView-nun göstər düyməsinə sıxdığımız zaman aktiv olması üçün yaratdığımız metod.
         * Bu metod sayəsində məlumatların silinməsi, yüklənməsi və yenilənməsi zamanı kod təkrarlanması
         * problemini yaşamırıq və kodumuz daha aydın və səliqəli hal alır.
         */
        private void DisplayData()
        {
            datagrviewStudent.DataSource = CRUD.Show();
        }

        /* DisplayData metodumuzun əksinə bu metod isə DataGridView-nu istədiyimiz zaman bağlamağa və kod 
        * təkrarından qaçmağa imkan yaradır.
        */
        private void HideData()
        {
            datagrviewStudent.Visible = false;
        }


        /* Mətn qutularına daxil etdiyimiz məlumatların müvafiq düymələrə sıxdığımız zaman databazamıza 
        *  qeyd edilib, eyni zamanda həmin mətn qutularındakı daxil edilən məlumatların silinməsinə şərait 
        *  yaradan metodumuzdur.
        */
        private void ClearData()
        {
            txtName.Text = "";
            txtSurname.Text = "";
            txtID.Text = "";
            txtFatherName.Text = "";
            cmboxGender.Text = "";
            txtEmail.Text = "";
            txtStatus.Text = "";
            txtBirthDate.Text = "";
            txtAdress.Text = "";
            txtGroupNumber.Text = "";

        }


        /* AddWithData - demək olar ki, ən önəmli metodumuzdur. Biz bu metod sayəsində 
         * istifadə zamanı əlavə etdiyimiz hər yeni bir təkmil düyməsinə görə təkrar-təkrar
         * kopyala-yapışdır əməliyyatı yerinə yetirməkdən azad oluruq.
         */
        private void AddWithData()
        {
            
        }


        /* Insert düyməsinə sıxdığımız zaman kodlarımızın databazamıza uğurlu bir şəkildə 
         * yerləşdirilməsi üçün istifadə olunan kod sətirləri aşağıdakılardır.
         */
        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtName.Text != "" || txtSurname.Text != "" ||
                    txtID.Text != "" || txtFatherName.Text != "" ||
                    cmboxGender.Text != "" || txtEmail.Text != "" ||
                    txtBirthDate.Text != "" || txtStatus.Text != "" ||
                    txtAdress.Text != "" || txtGroupNumber.Text != "")
                {

                    bool result = CRUD.Add(int.Parse(txtID.Text), txtName.Text, txtSurname.Text,
                     txtFatherName.Text,
                    cmboxGender.Text, txtEmail.Text,
                     txtStatus.Text,
                    txtBirthDate.Text,
                    txtAdress.Text, txtGroupNumber.Text.ToString());
                    if (result)
                    {
                        MessageBox.Show("Success!!! All data inserted!!!");
                    }
                    else
                    {
                        MessageBox.Show("Error while inserting data!");
                    }
                    DisplayData();
                    ClearData();
                }
                else
                {
                    MessageBox.Show("Please Fill Blanks!!!");
                }
            }
            catch
            {
                MessageBox.Show("Errorr!", "There is an exception case in program 1", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }


        /* Update düyməsinə sıxdığımız zaman kodlarımızın databazamızda uğurlu bir şəkildə 
         * yenilənməsi (dəyişdirilməsi) üçün istifadə olunan kod sətirləri aşağıdakılardır.
         */
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text != "" || txtSurname.Text != "" ||
                    txtID.Text != "" || txtFatherName.Text != "" ||
                    cmboxGender.Text != "" || txtEmail.Text != "" ||
                    txtBirthDate.Text != "" || txtStatus.Text != "" ||
                    txtAdress.Text != "" ||  txtGroupNumber.Text != "")
                {
                    bool result = CRUD.Upd(txtName.Text, txtSurname.Text,
                    txtID.Text, txtFatherName.Text,
                    cmboxGender.Text, txtEmail.Text,
                    txtBirthDate.Text, txtStatus.Text,
                    txtAdress.Text, txtGroupNumber.Text.ToString());
                    if (result)
                    {
                        MessageBox.Show("Success!!! All data updated!!!");
                    }
                    else
                    {
                        MessageBox.Show("Error while updating data!");
                    }
                    DisplayData();
                    ClearData();
                }
                else
                {
                    MessageBox.Show("Please Fill Blanks!!!");
                }
            }
            catch
            {
                MessageBox.Show("Errorr!", "There is an exception case in program 2", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        /* Delete düyməsinə sıxdığımız zaman kodlarımızın databazamızda uyğun identifikasiya 
         * nömrəsi üzrə uğurlu bir şəkildə silinməsi üçün istifadə olunan kod sətirləri aşağıdakılardır.
         */
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text != "")
                {

                    bool result = CRUD.Del(txtID.Text);
                    if (result)
                    {
                        MessageBox.Show("Success!!! All data deleted!!!");
                    }
                    else
                    {
                        MessageBox.Show("Error while deleting data!");
                    }

                    DisplayData();
                    ClearData();

                }
                else
                {
                    MessageBox.Show("Please Fill Blanks!!!");
                }
            }
            catch
            {
                MessageBox.Show("Errorr!", "There is an exception case in program 3", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        /* Və son olaraq DataGridView menyusunda databazadan xarici və ya məlumatının yenilənməsi 
         * nəzərdə tutulmuş müvafiq identifikasiya nömrəli şagirdin məlumatları üzrə əməliyyatları 
         * yerinə yetirməyimizi təmin edən kod sətirləri aşağıdakılardan ibarətdir.
         */
        private void datagrviewStudent_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtID.Text = datagrviewStudent.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = datagrviewStudent.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSurname.Text = datagrviewStudent.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtFatherName.Text = datagrviewStudent.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtBirthDate.Text = datagrviewStudent.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtAdress.Text = datagrviewStudent.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtEmail.Text = datagrviewStudent.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtGroupNumber.Text = datagrviewStudent.Rows[e.RowIndex].Cells[7].Value.ToString();
            cmboxGender.Text = datagrviewStudent.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtStatus.Text = datagrviewStudent.Rows[e.RowIndex].Cells[9].Value.ToString();

        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
