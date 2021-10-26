using System;
using System.Collections.Generic;
using System.Windows;
using AutoBinding2.Model;

namespace AutoBinding2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = new List<Car>
            {
                new Car
                {
                    Image = "Images\\Audi-A7-Sportback.jpg",
                    Model = "Audi A7 Sportback"
                },
                new Car
                {
                    Image = "Images\\BMW-6er-Gran-Coupé.jpg",
                    Model = "BMW 6er Gran Coupé"
                },
                new Car
                {
                    Image = "Images\\Mercedes-CLS.jpg",
                    Model = "Mercedes CLS"
                }
            };
        }
    }
}