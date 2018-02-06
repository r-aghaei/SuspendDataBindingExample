using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuspendDataBindingExample
{
    public partial class ProductEditForm : Form
    {
        public ProductEditForm(Product p)
        {
            InitializeComponent();
            productBindingSource.DataSource = p;
        }
        private void ProductEditForm_Load(object sender, EventArgs e)
        {
            this.BindingContext[productBindingSource].Bindings.Cast<Binding>().ToList()
                .ForEach(b => b.DataSourceUpdateMode = DataSourceUpdateMode.Never);
        }

        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            this.BindingContext[productBindingSource].Bindings.Cast<Binding>().ToList()
                .ForEach(b => b.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged);
            productBindingSource.EndEdit();
            this.DialogResult = DialogResult.OK;
        }
        private void CancelChangesButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
