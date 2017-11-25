using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace test_form
{
    public partial class Form1 : Form
    {
        string[] com = { "процессор", "видеокарта", "оперативная память", "материнская плата" };
        string[] cup = { "Intel Xeon E5-2679", "Intel Xeon E5-2699", "Intel Xeon E5-2699" };
        string[] video = { "GeForce GTX TITAN Z", "Radeon R9 295X2", "GeForce GTX 1080" };
        string[] memory = { "2", "4", "8", "12" };
        string[] motherboard = { "ASRock FM2A68M-HD+", "ASUS Z170-DELUXE", "ASUS PRIME X299-A", "MSI X299 TOMAHAWK" };
        Int32[] prise_cup;
        Int32[] prise_video;
        Int32[] prise_memory;
        Int32[] prise_motherboard;
        Int32 count = 0;
        DirectoryInfo di = new DirectoryInfo("DataTime");
        string path_cup = @"DataTime\\cup.txt";
        string path_video = @"DataTime\\video.txt";
        string path_memory = @"DataTime\\memory.txt";
        string path_motherboard = @"DataTime\\motherboard.txt";
        string path_prise_cup = @"DataTime\\prise_cup.txt";
        string path_prise_video = @"DataTime\\prise_video.txt";
        string path_prise_memory = @"DataTime\\prise_memory.txt";
        string path_prise_motherboard = @"DataTime\\prise_motherboard.txt";
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(com);
            comboBox2.Items.AddRange(com);
            comboBox1.Text = "комплектующие";
            comboBox2.Text = "выберите тип";
            label1.Text = "Цена:";
            button1.Text = "добавить";
            listBox1.Update();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                di.Create();
                StreamWriter sw_cup = new StreamWriter(path_cup, true); sw_cup.Close();
                StreamWriter sw_video = new StreamWriter(path_video, true); sw_video.Close();
                StreamWriter sw_memory = new StreamWriter(path_memory, true); sw_memory.Close();
                StreamWriter sw_motherboard = new StreamWriter(path_motherboard, true); sw_motherboard.Close();
                StreamWriter sw_prise_cup = new StreamWriter(path_prise_cup, true); sw_prise_cup.Close();
                StreamWriter sw_prise_video = new StreamWriter(path_prise_video, true); sw_prise_video.Close();
                StreamWriter sw_prise_memory = new StreamWriter(path_prise_memory, true); sw_prise_memory.Close();
                StreamWriter sw_prise_motherboard = new StreamWriter(path_prise_motherboard, true); sw_prise_motherboard.Close();
                cup = File.ReadAllLines(path_cup);
                video = File.ReadAllLines(path_video);
                memory = File.ReadAllLines(path_memory);
                motherboard = File.ReadAllLines(path_motherboard);
                prise_cup = sortTxt(path_prise_cup);
                prise_video = sortTxt(path_prise_video);
                prise_memory = sortTxt(path_prise_memory);
                prise_motherboard = sortTxt(path_prise_motherboard);
                Console.WriteLine("функция");
                for (int i = 0; i < prise_cup.Length; i++)
                {
                    Console.WriteLine(prise_cup[i]);
                }
                for (int i = 0; i < cup.Length; i++)
                {
                    Console.WriteLine(cup[i]);
                }


            }
            catch (Exception)
            {

               // throw;
            }
        }
        private int[] sortTxt(string path)
        {

                StreamReader objReader = new StreamReader(path);
                string sLine = "";
                List<string> arrText = new List<string>();
                while (sLine != null)
                {
                    sLine = objReader.ReadLine();
                    if (sLine != null)
                        arrText.Add(sLine);
                }
                objReader.Close();
                int[] arr = new int[arrText.Count];
                for (int i = 0; i < arrText.Count; i++)
                {
                    arr[i] = Int32.Parse(arrText[i]);
                }
                return arr;
            }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                for (int i = 0; i < cup.Length; i++)
                    if (listBox1.SelectedIndex == i)
                    {
                        listBox2.Items.Add(cup[i]);
                        listBox1.Items.Clear();
                        count += prise_cup[i];
                        break;
                    }
                for (int i = 0; i < video.Length; i++)
                    if (listBox1.SelectedIndex == i)
                    {
                        listBox2.Items.Add(video[i]);
                        listBox1.Items.Clear();
                        count += prise_video[i];
                        break;
                    }
                for (int i = 0; i < memory.Length; i++)
                    if (listBox1.SelectedIndex == i)
                    {
                        listBox2.Items.Add(memory[i]);
                        listBox1.Items.Clear();
                        count += prise_memory[i];
                        break;
                    }
                for (int i = 0; i < motherboard.Length; i++)
                    if (listBox1.SelectedIndex == i)
                    {
                        listBox2.Items.Add(motherboard[i]);
                        listBox1.Items.Clear();
                        count += prise_motherboard[i];
                        break;
                    }
                label2.Text = count.ToString();
            }
            catch (Exception)
            {

                // throw;
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    listBox1.Items.AddRange(cup);
                }
                if (comboBox1.SelectedIndex == 1)
                {
                    listBox1.Items.AddRange(video);
                }
                if (comboBox1.SelectedIndex == 2)
                {
                    listBox1.Items.AddRange(memory);
                }
                if (comboBox1.SelectedIndex == 3)
                {
                    listBox1.Items.AddRange(motherboard);
                }
            }
            catch (Exception)
            {
                //throw;
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

                StreamWriter sw_cup = new StreamWriter(path_cup, true);
                StreamWriter sw_video = new StreamWriter(path_video, true);
                StreamWriter sw_memory = new StreamWriter(path_memory, true);
                StreamWriter sw_motherboard = new StreamWriter(path_motherboard, true);
                StreamWriter sw_prise_cup = new StreamWriter(path_prise_cup, true);
                StreamWriter sw_prise_video = new StreamWriter(path_prise_video, true);
                StreamWriter sw_prise_memory = new StreamWriter(path_prise_memory, true);
                StreamWriter sw_prise_motherboard = new StreamWriter(path_prise_motherboard, true);
                if (comboBox2.SelectedIndex == 0)
                {
                    sw_cup.WriteLine(textBox1.Text);
                    sw_prise_cup.WriteLine(textBox2.Text);
                    sw_cup.Close();
                    sw_prise_cup.Close();
                }
                if (comboBox2.SelectedIndex == 1)
                {
                    sw_video.WriteLine(textBox1.Text);
                    sw_prise_video.WriteLine(textBox2.Text);
                    sw_video.Close();
                    sw_prise_video.Close();
                }
                if (comboBox2.SelectedIndex == 2)
                {
                    sw_memory.WriteLine(textBox1.Text);
                    sw_prise_memory.WriteLine(textBox2.Text);
                    sw_memory.Close();
                    sw_prise_memory.Close();
                }
                if (comboBox2.SelectedIndex == 3)
                {
                    sw_motherboard.WriteLine(textBox1.Text);
                    sw_prise_motherboard.WriteLine(textBox2.Text);
                    sw_motherboard.Close();
                    sw_prise_motherboard.Close();
                }
        }
        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}

