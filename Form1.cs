/*Составить алгоритм и программу вычисления таблицы значений функции f(x) из задачи 1.1 для N значений
аргумента X, равномерно распределенных на отрезке [А,B].Для проверки программы задать N=10; A=0,55; B=1.*/

/*Compose an algorithm and a program for calculating the table of values of the function f(x) from problem 1.1 for N values
argument X, evenly distributed on the segment [A, B]. To test the program, set N=10; A=0.55; B=1.*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23_variant_CSharp_1_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
 
        public static double functValTable(double x)
        {
            double y;
            y = Math.Log(Math.Sqrt(Math.Pow(Math.E, 0.1 * x) + x)) / (x + Math.Pow(10.7, 1 / 3) + Math.Atan(x) + 2 / 5);
            // ln(sqrt(e ^ 0.1x + x)) / (x + pow(10.7, 1 / 3) + arctg(x) + 2 / 5)
            return y;
        }

        private void tableName_Text(object sender, EventArgs e)
        {
            tableName.Text = "Таблица значений функции";
        }

        public void button1_Click(object sender, EventArgs e)
        {
            double[,] tableXY = new double[10, 2];
            dataGridView1.RowCount = 10;
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].HeaderText = "X";
            dataGridView1.Columns[1].HeaderText = "Y";
            double a=0.55,x=a, b=1, step = 0.03;

            for (int i = 0; i < 10; i++)
            {

                for (int j = 0; j < 1; j++)                                         //заполняем значения X
                {
                   tableXY[i, j] = x;
                    dataGridView1.Rows[i].Cells[j].Value = tableXY[i, j].ToString("0.####");
                    x += step;                                                       //прибавляем шаг
                }
            }
            x=a;                                                                    //сбросить шаг
            for (int i = 0; i < 10; i++)
            {
                for (int j = 1; j < 2; j++)
                {
                    tableXY[i, j] = functValTable(x);
                    dataGridView1.Rows[i].Cells[j].Value = tableXY[i, j].ToString("0.####");
                    x += step;
                }
            }
        
        }
    }
}
