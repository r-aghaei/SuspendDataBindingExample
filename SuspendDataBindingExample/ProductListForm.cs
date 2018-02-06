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
    public partial class ProductListForm : Form
    {
        public ProductListForm()
        {
            InitializeComponent();
        }

        private void ProductListForm_Load(object sender, EventArgs e)
        {
            var list = new List<Product>();
            list.Add(new Product() { Id = 1, Name = "Product 1", Price = 100 });
            list.Add(new Product() { Id = 2, Name = "Product 2", Price = 200 });
            list.Add(new Product() { Id = 3, Name = "Product 3", Price = 300 });

            this.productBindingSource.DataSource = list;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (this.productBindingSource.Current != null)
                using (var f = new ProductEditForm((Product)this.productBindingSource.Current))
                {
                    if (f.ShowDialog() == DialogResult.OK)
                        this.productBindingSource.ResetBindings(false);
                }
        }
    }
}
