using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFprice
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //打開視窗
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //開啟檔案
            string[] lines = System.IO.File.ReadAllLines(@"D:\data.txt");

            // 解析每一行
            foreach (string line in lines)
            {
                // 用 | 符號分開
                string[] parts = line.Split('|');

                // 建立 TodoItem
                item item = new item();

                //分別讀取不同部份
                item.date.Text = parts[0];
                item.itemName.Text = parts[1];
                item.itemPrice.Text = parts[2];

                // 放到清單
                toDoList.Children.Add(item);
            }
        }

        //關閉視窗
        private void Window_Closed(object sender, EventArgs e)
        {
            List<string> Texts = new List<string>();

            foreach (item item in toDoList.Children)
            {
                //設置一個空的字串
                string data = "";

                //每一種資料以"|"分隔加入Texts字串
                data += item.date.Text + "|" + item.itemName.Text + "|" + item.itemPrice.Text;

                //加入Texts的陣列
                Texts.Add(data);
            }
            //儲存到D:\
            System.IO.File.WriteAllLines(@"D:\data.txt", Texts);
        }

     
        private void Window_KeyDown_1(object sender, KeyEventArgs e)
        {
            //設定總支出的初始值
            int totalprice = 0;
            
            //按Enter之後計算總支出
            if (e.Key == Key.Return)
            {
            
                foreach (item item in toDoList.Children)
                {
                    totalprice += item.itemPriceValue;
                }

                //顯示價格
                total.Text = totalprice.ToString();
            }
            
        }


        //增加項目
        private void addItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // 產生項目
            item item = new item();

            //放到清單中
            toDoList.Children.Add(item);

        }
    }
}
