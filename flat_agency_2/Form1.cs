using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flat_agency_2
{
    public partial class Form1 : Form
    {
        Manager m;
        IEnumerable<Flat> res1, res2, res3, res4, res5;
        string region;

        public Form1()
        {
            InitializeComponent();
            
            m = new Manager();
            m.LoadData();
            
            listBox1.Items.Clear();
            comboBox1.Items.Clear();
            comboBox1.Items.Add("All");
            
            foreach (Flat f in m.list)
            {
                listBox1.Items.Add(String.Format("{0} - {1} / {2} - {3} uah", f.Address, f.Floor, f.Rooms, f.Price));
                comboBox1.Items.Add(f.Region);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int k1 = listBox1.SelectedIndex;
            if (k1 == -1)
                MessageBox.Show("Вы не выбрали ни одной квартиры");
            else
            {
                listBox2.Items.Add(listBox1.Items[k1]);
                
            }
                

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string k = listBox2.SelectedItem.ToString();
            listBox2.Items.Remove(k);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            string k = listBox2.SelectedItem.ToString();
            if (k!=listBox2.SelectedItem.ToString())
            {
                
                MessageBox.Show("Вы не выбрали квартиру", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                listBox2.Items.Remove(k);
                
                MessageBox.Show("Вы оформили заявку на квартиру", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            



        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {            
            region = comboBox1.SelectedItem.ToString();
            res1 = m.list.Where(f => f.Region == region);

            listBox1.Items.Clear();
            if (region == "All")
            {
                res1 = m.list;
                foreach (Flat f in m.list)
                {
                    listBox1.Items.Add(String.Format("{0} - {1} / {2} - {3} uah",
                        f.Address, f.Floor, f.Rooms, f.Price));
                }
            }
            else
            {
                foreach (Flat f in res1)
                {
                    listBox1.Items.Add(String.Format("{0} - {1} / {2}  -{3}",
                        f.Address, f.Floor, f.Rooms, f.Price));
                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            decimal price1 = trackBar1.Value;                                   
            res2 = res1.Where(f => f.Price > price1);

            listBox1.Items.Clear();
            foreach (Flat f in res2)
                listBox1.Items.Add(String.Format("{0} - {1} / {2} - {3} uah",
                    f.Address, f.Floor, f.Rooms, f.Price));

            textBox1.Text = price1 + " uah";
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            decimal price1 = trackBar2.Value;
            res3 = res1.Where(f => f.Price < price1);

            listBox1.Items.Clear();
            foreach (Flat f in res3)
                listBox1.Items.Add(String.Format("{0} - {1} / {2} - {3} uah", f.Address, f.Floor, f.Rooms, f.Price));
            textBox2.Text = price1 + " uah";
 

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            decimal room = numericUpDown1.Value;
            res4 = res1.Where(f => f.Rooms >= room);
            listBox1.Items.Clear();
            foreach (Flat f in res4)
                listBox1.Items.Add(String.Format("{0} - {1} / {2} - {3} uah", f.Address, f.Floor, f.Rooms, f.Price));

           
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            decimal floor = numericUpDown2.Value;
            res5 = res1.Where(f => f.Floor >= floor);
            listBox1.Items.Clear();
            foreach (Flat f in res5)
                listBox1.Items.Add(String.Format("{0} - {1} / {2} - {3} uah", f.Address, f.Floor, f.Rooms, f.Price));

        }

        private void button5_Click(object sender, EventArgs e)
        {
            m.list.Add(new Flat("Троещина", "Молодежная 12, кв.7", 3500, 1, 1));
            m.list.Add(new Flat("Вокзальная", "Петлюры 15, кв.25", 7500, 2, 4));
            m.list.Add(new Flat("Дорогожичи", "Телиги 57, кв.68", 4500, 1, 7));
            m.list.Add(new Flat("Дорогожичи", "Гарматная 3, кв.12", 8500, 3, 9));
            m.list.Add(new Flat("Левобережная", "Харьковская 10, кв.100", 9700, 3, 5));
            m.list.Add(new Flat("Нивки", "Житомирская 5, кв.1", 7300, 2, 3));
            m.list.Add(new Flat("Петровка", "Черниговская 33, кв.88", 4900, 1, 2));

            m.SaveData();
        }
    }
}
