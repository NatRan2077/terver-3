using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace terver_3
{
    public partial class Form1 : Form
    {
        private List<double> u_distr;
        private List<double> norm_distr;
        private Random random;
        int istype = 0;
        int sample = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            istype = 2;
            sample = 50;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            istype = 1;
            sample = 500;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            u_distr = new List<double>();  //равномерное распределение


            norm_distr = new List<double>();   //нормальное распределение
            random = new Random();
            double z, v = 0; 
            double n = 20; // n - параметр
            double deviation = 6;  //среднеквадратичное отклонение
            double expectation = 13;  //мат. ожидание
            double variance = 36;   // дисперсия 
           



            for (int i = 0; i < sample; i++)
            {
                double x = random.NextDouble();
                u_distr.Add(x);
            }

            for (int i = 0; i <= (20 * sample); i++)
            {
                double x = random.NextDouble();
                if (i % 20 == 0) u_distr.Add(x);
            }











            switch (istype)
            {
                case 1:
                    {
                        for (int i = 0; i < 500; i++)
                        {                                                                                                   //штука для нормального распредления 
                            for (int j = 0; j < n; j++)
                            {
                                double r = random.NextDouble();
                                v += r;
                            }
                            z = (v - (n / 2)) / Math.Sqrt(n / 12);
                            norm_distr.Add(z * deviation + expectation);  //моделирование СВ с нормальным законом распределения
                            v = 0;
                        } 
                        // Мера надёжности 0.95:

                        //пункт 1 - подсчёт мат. ожидания при известной дисперсии.Квантили стандартного нормального распределения вычислены через таблицы Excel

                        double intervMin500_095 = Math.Round(norm_distr.Sum() / norm_distr.Count - Math.Sqrt(variance / 500) * 1.95996398454005, 3),  
                               intervMax500_095 = Math.Round(norm_distr.Sum() / norm_distr.Count + Math.Sqrt(variance / 500) * 1.95996398454005, 3);
                        textBox1.Text = intervMin500_095.ToString();
                        textBox2.Text = intervMax500_095.ToString();


                        //пункт 2 - подсчёт мат. ожидания при неизвестной дисперсии.Квантили распределения Стьюдента вычислены через таблицы Excel

                        double tempSum2 = 0;
                        for (int i = 0; i < 500; i++)
                        {
                            tempSum2 += (norm_distr[i] - norm_distr.Sum() / norm_distr.Count) * (norm_distr[i] - norm_distr.Sum() / norm_distr.Count);
                        }
                        double S = Math.Sqrt(tempSum2 / 499);
                        double intervMin500_095_1 = Math.Round(norm_distr.Sum() / norm_distr.Count - S / Math.Sqrt(500) * 1.96472939098768, 3),   
                               intervMax500_095_1 = Math.Round(norm_distr.Sum() / norm_distr.Count + S / Math.Sqrt(500) * 1.96472939098768, 3);
                        textBox5.Text = intervMin500_095_1.ToString();
                        textBox6.Text = intervMax500_095_1.ToString();


                        //пункт 3 - подсчёт дисперсии при известном мат. ожидании.Квантили распределения ХИ - квадрат вычислены через таблицы Excel

                        double tempSum3 = 0;
                        for (int i = 0; i < 500; i++)
                        {
                            tempSum3 += (norm_distr[i] - expectation) * (norm_distr[i] - expectation);
                        }
                        double intervMin500_095_2 = Math.Round(tempSum3 / 563.851529344285, 3); 
                        double intervMax500_095_2 = Math.Round(tempSum3 / 439.935991261875, 3);
                        textBox9.Text = intervMin500_095_2.ToString();
                        textBox10.Text = intervMax500_095_2.ToString();

                        //пункт 4 - подсчёт дисперсии при неизвестном мат. ожидании

                        double tempSum4 = 0;
                        for (int i = 0; i < 500; i++)
                        {
                            tempSum4 += (norm_distr[i] - norm_distr.Sum() / norm_distr.Count) * (norm_distr[i] - norm_distr.Sum() / norm_distr.Count);
                        }
                        double S2 = tempSum2 / 499;
                        double intervMin500_095_4 = Math.Round(499 * S2 / 562.789495993598, 3);
                        double intervMax500_095_4 = Math.Round(499 * S2 / 438.99802242274, 3);
                        textBox13.Text = intervMin500_095_4.ToString();
                        textBox14.Text = intervMax500_095_4.ToString();



                        // Мера надёжности 0.85:

                        //пункт 1 - подсчёт мат. ожидания при известной дисперсии.Квантили стандартного нормального распределения вычислены через таблицы Excel

                        double intervMin500_085_1 = Math.Round(norm_distr.Sum() / norm_distr.Count - Math.Sqrt(variance / 500) * 1.43953147093846, 3);   
                        double intervMax500_085_1 = Math.Round(norm_distr.Sum() / norm_distr.Count + Math.Sqrt(variance / 500) * 1.43953147093846, 3);
                        textBox3.Text = intervMin500_085_1.ToString();
                        textBox4.Text = intervMax500_085_1.ToString();

                        //пункт 2  - подсчёт мат. ожидания при неизвестной дисперсии.Квантили распределения Стьюдента вычислены через таблицы Excel

                        tempSum2 = 0;
                        for (int i = 0; i < 500; i++) tempSum2 += (norm_distr[i] - norm_distr.Sum() / norm_distr.Count) * (norm_distr[i] - norm_distr.Sum() / norm_distr.Count);
                        S = Math.Sqrt(tempSum2 / 499);
                        double intervMin500_085_2 = Math.Round(norm_distr.Sum() / norm_distr.Count - S / Math.Sqrt(500) * 1.44175067755033, 3);   
                        double intervMax500_085_2 = Math.Round(norm_distr.Sum() / norm_distr.Count + S / Math.Sqrt(500) * 1.44175067755033, 3);
                        textBox7.Text = intervMin500_085_2.ToString();
                        textBox8.Text = intervMax500_085_2.ToString();

                        //пункт 3 - подсчёт дисперсии при известном мат. ожидании

                        tempSum3 = 0;
                        for (int i = 0; i < 500; i++) tempSum3 += (norm_distr[i] - expectation) * (norm_distr[i] - expectation);
                        double intervMin500_085_3 = Math.Round(tempSum3 / 546.211781347504, 3);
                        double intervMax500_085_3 = Math.Round(tempSum3 / 455.217661070988, 3);
                        textBox11.Text = intervMin500_085_3.ToString();
                        textBox12.Text = intervMax500_085_3.ToString();

                        //пункт 4 - подсчёт дисперсии при неизвестном мат. ожидании

                        tempSum4 = 0;
                        for (int i = 0; i < 500; i++) tempSum4 += (norm_distr[i] - norm_distr.Sum() / norm_distr.Count) * (norm_distr[i] - norm_distr.Sum() / norm_distr.Count);
                        S2 = tempSum2 / 499;
                        double intervMin500_085_4 = Math.Round(499 * S2 / 545.16621140109, 3);
                        double intervMax500_085_4 = Math.Round(499 * S2 / 454.26323056485, 3);
                        textBox15.Text = intervMin500_085_4.ToString();
                        textBox16.Text = intervMax500_085_4.ToString();
                        break;

                    }
                case 2:
                    {
                        /*Выборка 50*/

                        for (int i = 0; i < 50; i++)
                        {                                                                                                   //штука для нормального распредления 
                            for (int j = 0; j < n; j++)
                            {
                                double r = random.NextDouble();
                                v += r;
                            }
                            z = (v - (n / 2)) / Math.Sqrt(n / 12);
                            norm_distr.Add(z * deviation + expectation);  //моделирование СВ с нормальным законом распределения
                            v = 0;
                        }
                        // Мера надёжности 0.95:

                        //пункт 1 - подсчёт мат. ожидания при известной дисперсии.Квантили стандартного нормального распределения вычислены через таблицы Excel

                        double intervMin50_095_1 = Math.Round(norm_distr.Sum() / norm_distr.Count - Math.Sqrt(variance / 50) * 1.95996398454005, 3);  
                        double intervMax50_095_1 = Math.Round(norm_distr.Sum() / norm_distr.Count + Math.Sqrt(variance / 50) * 1.95996398454005, 3);
                        textBox1.Text = intervMin50_095_1.ToString();
                        textBox2.Text = intervMax50_095_1.ToString();

                        //пункт 2 - подсчёт мат. ожидания при неизвестной дисперсии.Квантили распределения Стьюдента вычислены через таблицы Excel
                        double tempSum2 = 0;
                        for (int i = 0; i < 50; i++)
                        {
                            tempSum2 += (norm_distr[i] - norm_distr.Sum() / norm_distr.Count) * (norm_distr[i] - norm_distr.Sum() / norm_distr.Count);
                        }
                        double S = Math.Sqrt(tempSum2 / 49);
                        double intervMin50_095_2 = Math.Round(norm_distr.Sum() / norm_distr.Count - S / Math.Sqrt(50) * 2.00957523712924, 3);   
                        double intervMax50_095_2 = Math.Round(norm_distr.Sum() / norm_distr.Count + S / Math.Sqrt(50) * 2.00957523712924, 3);
                        textBox5.Text = intervMin50_095_2.ToString();
                        textBox6.Text = intervMax50_095_2.ToString();


                        ////пункт 3 - подсчёт дисперсии при известном мат. ожидании.Квантили распределения ХИ - квадрат вычислены через таблицы Excel

                        double tempSum3 = 0;
                        for (int i = 0; i < 50; i++)
                        {
                            tempSum3 += (norm_distr[i] - expectation) * (norm_distr[i] - expectation);
                        }
                        double intervMin50_095_3 = Math.Round(tempSum3 / 71.4201951875064, 3); 
                        double intervMax50_095_3 = Math.Round(tempSum3 / 32.3573636956586, 3);
                        textBox9.Text = intervMin50_095_3.ToString();
                        textBox10.Text = intervMax50_095_3.ToString();

                        ////пункт 4 - подсчёт дисперсии при неизвестном мат. ожидании.Квантили распределения ХИ - квадрат вычислены через таблицы Excel
                        double tempSum4 = 0;
                        for (int i = 0; i < 50; i++)
                        {
                            tempSum4 += (norm_distr[i] - norm_distr.Sum() / norm_distr.Count) * (norm_distr[i] - norm_distr.Sum() / norm_distr.Count);
                        }
                        double S2 = tempSum2 / 49;
                        double intervMin50_095_4 = Math.Round(49 * S2 / 70.2224135664345, 3); 
                        double intervMax50_095_4 = Math.Round(49 * S2 / 31.5549164626671, 3);
                        textBox13.Text = intervMin50_095_4.ToString();
                        textBox14.Text = intervMax50_095_4.ToString();


                        // Мера надёжности 0.85:

                        ////пункт 1 - подсчёт мат. ожидания при известной дисперсии

                        double intervMin50_085_1 = Math.Round(norm_distr.Sum() / norm_distr.Count - Math.Sqrt(variance / 50) * 1.43953147093846, 3);   //Квантили стандартного нормального распределения вычислены через таблицы Excel
                        double intervMax50_085_1 = Math.Round(norm_distr.Sum() / norm_distr.Count + Math.Sqrt(variance / 50) * 1.43953147093846, 3);
                        textBox3.Text = intervMin50_085_1.ToString();
                        textBox4.Text = intervMax50_085_1.ToString();

                        ////пункт 2 - подсчёт мат. ожидания при неизвестной дисперсии
                        tempSum2 = 0;
                        for (int i = 0; i < 50; i++)
                        {
                            tempSum2 += (norm_distr[i] - norm_distr.Sum() / norm_distr.Count) * (norm_distr[i] - norm_distr.Sum() / norm_distr.Count);
                        }
                        S = Math.Sqrt(tempSum2 / 49);
                        double intervMin50_085_2 = Math.Round(norm_distr.Sum() / norm_distr.Count - S / Math.Sqrt(50) * 1.46245979014046, 3);   //Квантили распределения Стьюдента вычислены через таблицы Excel
                        double intervMax50_085_2 = Math.Round(norm_distr.Sum() / norm_distr.Count + S / Math.Sqrt(50) * 1.46245979014046, 3);
                        textBox7.Text = intervMin50_085_2.ToString();
                        textBox8.Text = intervMax50_085_2.ToString();


                        ////пункт 3 - подсчёт дисперсии при известном мат. ожидании

                        tempSum3 = 0;
                        for (int i = 0; i < 50; i++)
                        {
                            tempSum3 += (norm_distr[i] - expectation) * (norm_distr[i] - expectation);
                        }
                        double intervMin50_085_3 = Math.Round(tempSum3 / 65.0302694535051, 3);
                        double intervMax50_085_3 = Math.Round(tempSum3 / 36.3971047755992, 3);
                        textBox11.Text = intervMin50_085_3.ToString();
                        textBox12.Text = intervMax50_085_3.ToString();



                        ////пункт 4 - подсчёт дисперсии при неизвестном мат. ожидании
                        tempSum4 = 0;
                        for (int i = 0; i < 50; i++)
                        {
                            tempSum4 += (norm_distr[i] - norm_distr.Sum() / norm_distr.Count) * (norm_distr[i] - norm_distr.Sum() / norm_distr.Count);
                        }
                        S2 = tempSum2 / 49;
                        double intervMin50_085_4 = Math.Round(49 * S2 / 63.8847679320253, 3);
                        double intervMax50_085_4 = Math.Round(49 * S2 / 35.5425585551258, 3);
                        textBox15.Text = intervMin50_085_4.ToString();
                        textBox16.Text = intervMax50_085_4.ToString();
                        break;
                     
                    }

            }
            chart1.Series[0].Points.Clear();
            int intervals = (int)Math.Ceiling(1 + Math.Log(sample, 2)); //количество интервалов по правилу Стёрджеса 
            textBox17.Text = sample.ToString();
            norm_distr.Sort();//сортировка списка значений СВ 

            double intervalLength = (norm_distr.Max() - norm_distr.Min()) / intervals, //длина интервала (ширина столбика гистограммы)
                   rightBorder = norm_distr.Min() + intervalLength; //правая граница столбика гистограммы

            for (int j = 0, i = 0, counter = 0; i < norm_distr.Count; i++, counter++)  //counter - счётчик значений, входящих в диапазон
            {
                if (norm_distr[i] > rightBorder || i + 1 >= u_distr.Count)  //если число не вошло в диапазон 
                {
                    double y = (1 / (deviation * Math.Sqrt(2 * Math.PI))) * Math.Exp((norm_distr[i] - expectation) * (norm_distr[i] - expectation) * (-1) / (2 * variance));  //(double)counter / newNormalNumb.Count / intervalLength; // частота появления СВ

                    chart1.Series[0].Points.AddXY(Math.Round(norm_distr[i], 3), y);

                    j++;   //прибавляем j постфиксным инкрементом
                    rightBorder = norm_distr.Min() + (j + 1) * intervalLength;  // вычисляем следующую границу
                    counter = 0; //зануляем счётчик
                }
            }
        }
            private void textBox1_TextChanged(object sender, EventArgs e)
            {

            }

            private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
            {

            }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
