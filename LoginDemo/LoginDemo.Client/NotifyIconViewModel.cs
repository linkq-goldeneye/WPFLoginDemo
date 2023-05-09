using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using System.Windows.Input;
using System.Windows;
using Prism.Ioc;
using LoginDemo.Client.Views;

namespace LoginDemo.Client
{
    public class NotifyIconViewModel
    {
        /// <summary>
        /// 显示窗口
        /// </summary>
        public ICommand ShowWindowCommand
        {
            get => new DelegateCommand<object>(ShowWindow);
        }
        private void ShowWindow(object obj)
        {
            Application.Current.MainWindow.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// 退出程序
        /// </summary>
        public ICommand ExitApplicationCommand
        {
            get => new DelegateCommand<object>(OnExit);
        }

        private void OnExit(object obj)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// 隐藏窗口
        /// </summary>
        public ICommand HideWindowCommand
        {
            get => new DelegateCommand<object>(OnHideWindow);
        }

        private void OnHideWindow(object obj)
        {
            Application.Current.MainWindow.Visibility = Visibility.Hidden;
        }

    }
}
