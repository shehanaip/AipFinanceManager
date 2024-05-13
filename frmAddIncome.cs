using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using LiteDB;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using AIp_Finance_Management__personal_.Models;

namespace AIp_Finance_Management__personal_
{
    public partial class frmAddIncome : Form
    {
        public frmAddIncome()
        {
            InitializeComponent();
        }

        public frmAddIncome(DateTime date)
        {
            InitializeComponent();

            // Clear and populate the Category ComboBox
            //txtCategory.Items.Clear(); bug fix
            foreach (var item in DbContext.GetInstance().GetCollection<IncomeCategory>("income_categories").FindAll())
            {
                txtCategory.Items.Add(item.Name);
            }
            // Set the selected index after adding all items
            txtCategory.SelectedIndex = 0;

            // Clear and populate the Account ComboBox

            //txtAccount.Items.Clear(); bug fix
            foreach (var item in DbContext.GetInstance().GetCollection<Account>("accounts").FindAll())
            {
                txtAccount.Items.Add(item.Name);
            }
            // Set the selected index after adding all items
            txtAccount.SelectedIndex = 0;

            // Set the Date control value
            txtDate.Value = date;
        }

        private void BtnAddIncome_Click(object sender, EventArgs e)
        {
            // Validate if an Account and Category are selected
            if (txtAccount.SelectedIndex == -1 || txtCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an Account and a Category.");
                return;
            }

            // Validate the amount
            if (txtFrom.Text.Trim().Length == 0)
            {
                bunifuSnackbar1.Show(this, "Invalid Amount");
                txtFrom.Focus();
                return;
            }

            double amount = 0;
            try
            {
                amount = double.Parse(txtAmount.Text.Trim());
                if (amount <= 0)
                {
                    bunifuSnackbar1.Show(this, "Invalid Amount");
                    txtFrom.Focus();
                    return;
                }
            }
            catch (Exception)
            {
                bunifuSnackbar1.Show(this, "Invalid Amount");
                txtFrom.Focus();
                return;
            }

            // Confirm the transaction
            if (MessageBox.Show($"Confirm received amount {amount} from {txtFrom.Text}?", "AIP Finance", MessageBoxButtons.YesNoCancel) != DialogResult.Yes)
            {
                bunifuSnackbar1.Show(this, "This transaction is cancelled");
                return;
            }

            // Complete transaction
            IncomeTransaction incomeTransaction = new IncomeTransaction()
            {
                Account = DbContext.GetInstance().GetCollection<Account>("accounts").FindAll().ToList()[txtAccount.SelectedIndex],
                Category = DbContext.GetInstance().GetCollection<IncomeCategory>("income_categories").FindAll().ToList()[txtCategory.SelectedIndex],
                Amount = amount,
                Date = txtDate.Value,
                Description = txtDesc.Text.Trim(),
                PaymentFrom = txtFrom.Text.Trim(),
                TransactionCode = txtCode.Text.Trim(),
            };
            DbContext.GetInstance().GetCollection<IncomeTransaction>("income_transactions").Insert(incomeTransaction);
            bunifuSnackbar1.Show(this, "Successful");
            closeForm.Start();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closeForm_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
