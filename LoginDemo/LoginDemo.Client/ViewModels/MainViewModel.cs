using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using RestSharp;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Text.Json.Nodes;
using System.Windows;
using System.Windows.Input;

namespace LoginDemo.Client.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private string _title = "LoginDemo Client";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public double PrimaryScreenWidth { get; set; }
        public double PrimaryScreenHeight { get; set; }
        public MainViewModel()
        {
            PrimaryScreenWidth = SystemParameters.PrimaryScreenHeight * 0.5 * 9 / 4;//得到屏幕整体宽度
            PrimaryScreenHeight = SystemParameters.PrimaryScreenHeight * 0.5;//得到屏幕整体高度
        }

    }


}
