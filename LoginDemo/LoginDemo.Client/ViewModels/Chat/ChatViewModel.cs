using DryIoc;
using LoginDemo.Client.Views;
using LoginDemo.Client.Tools;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;

namespace LoginDemo.Client.ViewModels.Chat
{
    public class ChatViewModel : BindableBase
    {
        public IContainerExtension Container;
        public SaveOptions saveOptions { get; set; }

        public ICommand ReLoginCommand
        {
            get => new DelegateCommand<object>(OnReLogin);
        }
        public ICommand MinimizeCommand
        {
            get => new DelegateCommand<object>(OnMinimize);
        }
        public ICommand CloseCommand
        {
            get => new DelegateCommand<object>(OnClose);
        }

        public ChatViewModel(BackgroundWorker backgroundWorker, IEventAggregator aggregator, IContainerExtension container)
        {
            Container = container;
            CheckSaveFiles();
        }


        private void OnReLogin(object obj)
        {
            using (var stream = File.Open("SaveOptions.xml", FileMode.Create))
            {
                saveOptions.AutoLogin = false;
                var serializer = new XmlSerializer(typeof(SaveOptions));
                serializer.Serialize(stream, saveOptions);
                stream.Close();
            }
            Application.Current.Shutdown();
            Thread thread = new Thread(new ThreadStart(reStart));
            thread.Start();
        }
        private void OnMinimize(object obj)
        {
            (obj as Window).Visibility = Visibility.Hidden;
        }
        private void OnClose(object obj)
        {
            Application.Current.Shutdown();
            Environment.Exit(0);
        }
        private void CheckSaveFiles()
        {
            if (saveOptions == null)
            {
                //确定指定的文件是否存在
                if (File.Exists("SaveOptions.xml"))
                {
                    using (var stream = File.OpenRead("SaveOptions.xml"))
                    {
                        var serializer = new XmlSerializer(typeof(SaveOptions));
                        saveOptions = serializer.Deserialize(stream) as SaveOptions;
                    }
                }
                else
                    saveOptions = new SaveOptions();
            }
        }
        private void reStart()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "LoginDemo.Client.exe";
            Process.Start(path);
        }
    }
}
