using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using System.Windows.Input;
using System.Windows;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using LoginDemo.Client.Views;
using LoginDemo.Service.Interfaces;
using LoginDemo.Share.Events;

namespace LoginDemo.Client.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        private string _title = "Login";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }


        public double PrimaryScreenWidth { get; set; }
        public double PrimaryScreenHeight { get; set; }




        public LoginViewModel()
        {
            PrimaryScreenWidth = SystemParameters.PrimaryScreenHeight * 0.3 * 9 / 4;//得到屏幕整体宽度
            PrimaryScreenHeight = SystemParameters.PrimaryScreenHeight * 0.3;//得到屏幕整体高度
        }

    }
}
