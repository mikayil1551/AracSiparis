using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracSiparis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRenk_Click(object sender, EventArgs e)
        {
            DialogResult sonuc= colorDialog2.ShowDialog();
            if (sonuc==DialogResult.OK)
            {
                btnRenk.BackColor = colorDialog2.Color;
            }
        }

        private void cmbMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbModel.Items.Clear();
            switch (cmbMarka.Text)
            {
                
               case "Wolkswagen":
                    cmbModel.Items.Add("Jetta");
                    cmbModel.Items.Add("Passat");
                    cmbModel.Items.Add("CC");
                    break;

                case "Bmw":
                    cmbModel.Items.Add("M60Coupe");
                    cmbModel.Items.Add("X6");
                    cmbModel.Items.Add("X5");
                    break;

                case "Mercedes":
                    cmbModel.Items.Add("Clio");
                    cmbModel.Items.Add("Laguna");
                    cmbModel.Items.Add("Symbol");

                    break;
                case "Hyundai":
                    cmbModel.Items.Add("Tucson");
                    cmbModel.Items.Add("Elantra");
                    cmbModel.Items.Add("I 30");

                    break;
                case "Audi":
                    cmbModel.Items.Add("Q7");
                    cmbModel.Items.Add("Q5");
                    cmbModel.Items.Add("Q3");
                    break;
                case "Fiat":
                    cmbModel.Items.Add("A2");
                    cmbModel.Items.Add("B3");
                    cmbModel.Items.Add("C4");
                    break;

                default:
                    break;

            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.UseItemStyleForSubItems = false;

            lvi.Text = cmbMarka.Text;
            lvi.SubItems.Add(cmbModel.Text);
            lvi.SubItems.Add(cmbYakitTipi.Text);
            lvi.SubItems.Add(cmbKasaTipi.Text);
            lvi.SubItems.Add(cmbVitesTipi.Text);
            lvi.SubItems.Add(cmbMotorTipi.Text);
            lvi.SubItems.Add(string.Empty);
            lvi.SubItems[6].BackColor = btnRenk.BackColor;
            lvi.SubItems.Add(dtpYıl.Text);

            listView1.Items.Add(lvi);

            foreach (Control item in this.Controls)
            {
                if (item is ComboBox)
                {
                    ((ComboBox)item).SelectedIndex = -1;

                }
                else if(item is Button)
                {
                    Button btn = (Button)item;
                    if (btn.Name=="btnRenk")
                    {
                        btn.BackColor = Color.White;
                    }
                }
                else if (item is DateTimePicker)
                {
                    ((DateTimePicker)item).Value = DateTime.Now;
                }

            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count>0)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
            
        }
        ListViewItem secili;
        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count==0)
            {
                MessageBox.Show("Lutfen Duzenlemek istediginiz kaydi seciniz!");
                return;
            }

            secili = listView1.SelectedItems[0];

            cmbMarka.Text = secili.Text;
            cmbModel.Text = secili.SubItems[1].Text;
            cmbYakitTipi.Text = secili.SubItems[2].Text;
            cmbKasaTipi.Text = secili.SubItems[3].Text;
            cmbVitesTipi.Text = secili.SubItems[4].Text;
            cmbMotorTipi.Text = secili.SubItems[5].Text;
            btnRenk.BackColor = secili.SubItems[6].BackColor;
            dtpYıl.Value = Convert.ToDateTime(string.Format("01.01.{0}", secili.SubItems[7].Text));


        }

        private void button3_Click(object sender, EventArgs e)
        {
            secili.SubItems[0].Text = cmbMarka.Text;
            secili.SubItems[1].Text = cmbModel.Text;
            secili.SubItems[2].Text = cmbYakitTipi.Text;
            secili.SubItems[3].Text = cmbKasaTipi.Text;
            secili.SubItems[4].Text = cmbVitesTipi.Text;
            secili.SubItems[5].Text = cmbMotorTipi.Text;
            secili.SubItems[6].BackColor = btnRenk.BackColor;
            secili.SubItems[7].Text = dtpYıl.Text;
            
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    listView1.Items.Remove(listView1.SelectedItems[0]);
                }
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count>0)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
        }

        private void duzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Lutfen Duzenlemek istediginiz kaydi seciniz!");
                return;
            }

            secili = listView1.SelectedItems[0];

            cmbMarka.Text = secili.Text;
            cmbModel.Text = secili.SubItems[1].Text;
            cmbYakitTipi.Text = secili.SubItems[2].Text;
            cmbKasaTipi.Text = secili.SubItems[3].Text;
            cmbVitesTipi.Text = secili.SubItems[4].Text;
            cmbMotorTipi.Text = secili.SubItems[5].Text;
            btnRenk.BackColor = secili.SubItems[6].BackColor;
            dtpYıl.Value = Convert.ToDateTime(string.Format("01.01.{0}", secili.SubItems[7].Text));



            
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            secili.SubItems[0].Text = cmbMarka.Text;
            secili.SubItems[1].Text = cmbModel.Text;
            secili.SubItems[2].Text = cmbYakitTipi.Text;
            secili.SubItems[3].Text = cmbKasaTipi.Text;
            secili.SubItems[4].Text = cmbVitesTipi.Text;
            secili.SubItems[5].Text = cmbMotorTipi.Text;
            secili.SubItems[6].BackColor = btnRenk.BackColor;
            secili.SubItems[7].Text = dtpYıl.Text;

        }
    }
}
