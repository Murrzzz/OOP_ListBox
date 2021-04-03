using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OOP_ListBox
{

  

    public partial class Form1 : Form
    {

        string item;
        int UnitPrice;
        int Quantity;
        int prod;
        public int[] forTotal = new int[1000];
        public int[] container = new int[1000];
        int numArr = 0;

        int total = 0;
        int cash;
        int change;

        
        public Form1()
        {
            InitializeComponent();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtCash.Text = "0";
            txtChange.Text = "0";
            txtTotal.Text = "0";
        }

        private void btnAddtoCart_Click(object sender, EventArgs e)
        {
            
            item = txtItem.Text;
            UnitPrice = int.Parse(txtUnitPrice.Text);
            Quantity = int.Parse(txtQuantity.Text);
            prod = UnitPrice * Quantity;

            container[numArr] = prod;
            numArr++;
            //forTotal[numArr ] = prod;
          
            
            ListBox.Items.Add(item+" @ "+Quantity  +" x "+UnitPrice+".. "+prod );
             }

        private void btnComputeChange_Click(object sender, EventArgs e)
        {
             cash=int.Parse(txtCash.Text);
             change = int.Parse(txtChange.Text);
             change = cash - int.Parse (txtTotal .Text );
             txtChange.Text = change.ToString();
        }
      
      
        private void btnComputeTotal_Click(object sender, EventArgs e)
        {
            //btnVoidItems.PerformClick();

            for (int i = 0; i < numArr  ; i++)
            {
                total += container [i];
            }
            Console.WriteLine("-------------");

            txtTotal.Text = total.ToString() ;
            //txtTotal.Text = (total + int.Parse(txtTotal.Text)).ToString();
        }

       

        private void btnVoidItems_Click(object sender, EventArgs e)
        {

            if (ListBox.Items.Count >= 0)
            {
                string selected = ListBox.Items[ListBox.SelectedIndex].ToString();
                int ind = ListBox.SelectedIndex;
                //Console.WriteLine(ListBox.SelectedIndex);

                Console.WriteLine("INdex");
                Console.WriteLine(ind);
                ListBox.Items.Remove(selected);

                Console.WriteLine("Items");
                Console.WriteLine(ListBox.Items.Count);

               
                for (int i = ind; i <numArr ; i++)
                {
                    container[i] = container[i + 1];
                }
                numArr--;
            } 
        }

        private void btnNewTrans_Click(object sender, EventArgs e)
        {
         
            
            txtCash.Text = "0";
            txtChange.Text = "0";
            txtItem.Text = "";
            txtQuantity.Text = "";
            txtTotal.Text = "";
            txtUnitPrice.Text = "";
            ListBox.Items.Clear();
            Array.Clear(container  ,0,container.Length );
            total = 0;
        

        }
    }
 
}
