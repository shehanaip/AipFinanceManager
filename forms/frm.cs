using AIp_Finance_Management__personal_.forms;
using AIp_Finance_Management__personal_.Models;
using Bunifu.DataViz.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiteDB;

namespace AIp_Finance_Management__personal_
{
    public partial class frm : Form
    {
        public frm()
        {
            InitializeComponent();

            Aplly_Grid_Theme(GridIncome);
            Aplly_Grid_Theme(GridExpense);
            Aplly_Grid_Theme(gridMexpense);
            Aplly_Grid_Theme(gridMincome);
            Aplly_Grid_Theme(gridMaccount);
            bunifuDataViz1.colorSet.Add(col1.BackColor);
            bunifuDataViz1.colorSet.Add(col2.BackColor);
            bunifuDataViz1.colorSet.Add(col3.BackColor);

            foreach (var item in DbContext.GetInstance().GetCollection<IncomeCategory>("income_Categories").FindAll())
            {
                gridMincome.Rows[gridMincome.Rows.Add(item.Name)].Tag=item;
            }
            foreach (var item in DbContext.GetInstance().GetCollection<IncomeCategory>("expense_Categories").FindAll())
            {
                gridMexpense.Rows[gridMincome.Rows.Add(item.Name)].Tag = item;
            }
            foreach (var item in DbContext.GetInstance().GetCollection<IncomeCategory>("accounts").FindAll())
            {
                gridMaccount.Rows[gridMincome.Rows.Add(item.Name)].Tag = item;
            }

        }
        void Aplly_Grid_Theme(Bunifu.UI.WinForms.BunifuDataGridView grid)
        {
            GridIncome.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            GridIncome.ColumnHeadersDefaultCellStyle.ForeColor = Color.DimGray;

            GridIncome.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            GridIncome.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.DimGray;
        }
        private void pnlTitle_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //main work here 
        //move indecator
        void moveIndecator(Control btn)
        {
            indecator.Left= btn.Left;
            indecator.Width= btn.Width;
        }
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            moveIndecator((Control)sender);

        }

        private void btnIncome_Click(object sender, EventArgs e)
        {
            moveIndecator((Control)sender);
            bunifuPages1.SetPage("Income");

        }

        private void btnExpenses_Click(object sender, EventArgs e)
        {
            moveIndecator((Control)sender);
            bunifuPages1.SetPage("Expenses");
        }


        private void btnReport_Click(object sender, EventArgs e)
        {
            moveIndecator((Control)sender);
            bunifuPages1.SetPage("Reports");
        }

        private void btnDashboard_Click_1(object sender, EventArgs e)
        {
            moveIndecator((Control)sender);
            bunifuPages1.SetPage("Dashboard");
      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            moveIndecator((Control)sender);
            bunifuPages1.SetPage("Setting");
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        //for plot chart
        void RenderMonthChart()
        {

            Bunifu.DataViz.WinForms.Canvas canvas = new Bunifu.DataViz.WinForms.Canvas();
            // series
            Bunifu.DataViz.WinForms.DataPoint income = new Bunifu.DataViz.WinForms.DataPoint(Bunifu.DataViz.WinForms.BunifuDataViz._type.Bunifu_column);
            Bunifu.DataViz.WinForms.DataPoint expenses = new Bunifu.DataViz.WinForms.DataPoint(Bunifu.DataViz.WinForms.BunifuDataViz._type.Bunifu_column);
            Bunifu.DataViz.WinForms.DataPoint balance = new Bunifu.DataViz.WinForms.DataPoint(Bunifu.DataViz.WinForms.BunifuDataViz._type.Bunifu_column);

            // random number
            Random ran = new Random();
            for (int i = 0; i < 30; i++)
            {
                income.addLabely(i.ToString(), ran.Next(20, 500));
                expenses.addLabely(i.ToString(), ran.Next(0, 100));
                balance.addLabely(i.ToString(), ran.Next(100, 1000));
            }

            // Add series to canvas
            canvas.addData(income);
            canvas.addData(expenses);
            canvas.addData(balance);


            bunifuDataViz1.Render(canvas);

        }
        void RenderIncomeChart()
        {

            Bunifu.DataViz.WinForms.Canvas canvas = new Bunifu.DataViz.WinForms.Canvas();
            // series
            Bunifu.DataViz.WinForms.DataPoint outlook = new Bunifu.DataViz.WinForms.DataPoint(Bunifu.DataViz.WinForms.BunifuDataViz._type.Bunifu_column);
            

            // random number
           
                outlook.addLabely("Salary",10000);
                outlook.addLabely("Commision",50000);
                outlook.addLabely("Freelancing",20000);
                outlook.addLabely("youtube",20000);

            // Add series to canvas
            canvas.addData(outlook);
            

            bunifuDataViz2.Render(canvas);
        }
        void RenderExpensesChart()
        {

            Bunifu.DataViz.WinForms.Canvas canvas = new Bunifu.DataViz.WinForms.Canvas();
            // series
            Bunifu.DataViz.WinForms.DataPoint outlook = new Bunifu.DataViz.WinForms.DataPoint(Bunifu.DataViz.WinForms.BunifuDataViz._type.Bunifu_column);


            // random data

            outlook.addLabely("Rent", 10000);
            outlook.addLabely("Food", 50000);
            outlook.addLabely("Bills", 20000);
            outlook.addLabely("Internet", 20000);
            outlook.addLabely("Airtime", 5000);

            // Add series to canvas
            canvas.addData(outlook);


            bunifuDataViz3.Render(canvas);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            RenderMonthChart();
            RenderIncomeChart();
            RenderExpensesChart();
        }

        private void frm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnAddIncome_Click(object sender, EventArgs e)
        {
            frmAddIncome frmAddIncome = new frmAddIncome();
            frmAddIncome.Show();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            frmExpenseItem expenseItem = new frmExpenseItem();
            expenseItem.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void gridMincome_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (gridMincome.Rows[e.RowIndex].Tag != null)
            {
                var incomeCategory = (IncomeCategory)gridMincome.Rows[e.RowIndex].Tag;
                if (gridMincome.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    incomeCategory.Name = gridMincome.Rows[e.RowIndex].Cells[0].Value.ToString();
                    DbContext.GetInstance().GetCollection<IncomeCategory>("income_categories").Update(incomeCategory);
                }
            }
            else
            {
                // New record
                if (gridMincome.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    int id = DbContext.GetInstance().GetCollection<IncomeCategory>("income_categories").Insert(
                        new IncomeCategory()
                        {
                            Name = gridMincome.Rows[e.RowIndex].Cells[0].Value.ToString()
                        }
                    );
                    // Update tag with the newly inserted category
                    gridMincome.Rows[e.RowIndex].Tag = DbContext.GetInstance().GetCollection<IncomeCategory>("income_categories").FindById(id);
                }
            }
        }



        private void gridMexpense_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (gridMexpense.Rows[e.RowIndex].Tag == null)
            {
                var expenseCategory = (ExpenseCategory)gridMexpense.Rows[e.RowIndex].Tag;
                expenseCategory.Name = gridMexpense.Rows[e.RowIndex].Cells[0].Value.ToString();

                DbContext.GetInstance().GetCollection<ExpenseCategory>("expense_categories").Update(expenseCategory);
            }
            else
            {
                //new record
                int id = DbContext.GetInstance().GetCollection<ExpenseCategory>("expense_categories").Insert(
                    new ExpenseCategory()
                    {
                        Name = gridMexpense.CurrentCell.Value.ToString()
                    }
            );
                //update
                gridMexpense.Rows[e.RowIndex].Tag = DbContext.GetInstance().GetCollection<ExpenseCategory>("expense_categories").FindById(id);
            }
        }

        private void gridMaccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridMaccount.Rows[e.RowIndex].Tag == null)
            {
                var account = (Account)gridMaccount.Rows[e.RowIndex].Tag;
                account.Name = gridMaccount.Rows[e.RowIndex].Cells[0].Value.ToString();

                DbContext.GetInstance().GetCollection<Account>("accounts").Update(account);
            }
            else
            {
                //new record
                int id = DbContext.GetInstance().GetCollection<Account>("accounts").Insert(
                    new Account()
                    {
                        Name = gridMaccount.CurrentCell.Value.ToString()
                    }
            );
                //update
                gridMaccount.Rows[e.RowIndex].Tag = DbContext.GetInstance().GetCollection<ExpenseCategory>("expense_categories").FindById(id);
            }

        }

    }
}
