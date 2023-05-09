using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Xml.Serialization;
using System.IO;
using DryIoc;
using LoginDemo.Share.Events;
using LoginDemo.Service.Interfaces;
using LoginDemo.Client.Tools;
using LoginDemo.Client.Views;

namespace LoginDemo.Client.ViewModels.Login
{
    public class LoginControlViewModel : BindableBase
    {
        private ILoginService LoginService;
        private readonly IDialogService dialogService;
        private IEventAggregator aggregator;
        public IContainerExtension Container;
        BackgroundWorker BackgroundWorker;
        public SaveOptions saveOptions { get; set; }

        private string errorMsg;
        public string ErrorMsg
        {
            get { return errorMsg; }
            set { SetProperty(ref errorMsg, value); }
        }

        private bool enabledLogin;
        public bool EnabledLogin
        {
            get { return enabledLogin; }
            set { SetProperty(ref enabledLogin, value); }
        }


        bool isLogin = false;

        private Visibility isLoading;
        public Visibility IsLoading
        {
            get { return isLoading; }
            set { SetProperty(ref isLoading, value); }
        }

        public Window main;


        public ICommand LoginCommand
        {
            get => new DelegateCommand<object>(OnLogin);
        }
        public ICommand MinimizeCommand
        {
            get => new DelegateCommand<object>(OnMinimize);
        }
        public ICommand CloseCommand
        {
            get => new DelegateCommand<object>(OnClose);
        }



        public LoginControlViewModel(ILoginService loginService, IDialogService dialogService, IEventAggregator aggregator, IContainerExtension container, BackgroundWorker backgroundWorker)
        {
            EnabledLogin = true;
            LoginService = loginService;
            this.dialogService = dialogService;
            this.aggregator = aggregator;
            Container = container;
            CheckSaveFiles();

            BackgroundWorker = backgroundWorker;
            //异步取消
            BackgroundWorker.WorkerSupportsCancellation = true;
            //注册任务
            BackgroundWorker.DoWork += LoginAsync;
            //任务完毕触发
            BackgroundWorker.RunWorkerCompleted += LoginAsyncCompleted;

            IsLoading = Visibility.Collapsed;
            ShowLoading();

            AutoLogin();
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

        private void OnClose(object obj)
        {
            Application.Current.Shutdown();
            Environment.Exit(0);
        }

        private void LoginAsyncCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            aggregator.GetEvent<LoadingEvent>().Publish(Visibility.Hidden);
            EnabledLogin = true;
            try
            {
                ErrorMsg = string.Empty;
                if (isLogin)
                {
                    Skip2MainView();
                    SaveOptionsXml();
                }
                else
                {
                    aggregator.GetEvent<LoadingEvent>().Publish(Visibility.Hidden);
                    throw new Exception("用户名或密码错误");
                }

            }
            catch (Exception ex)
            {
                ErrorMsg = "登录失败！" + ex.Message;
                ErrorMessageShow();
                SaveOptionsXml();
            }

        }

        private void LoginAsync(object sender, DoWorkEventArgs e)
        {
            isLogin = LoginService.Login(saveOptions.SaveLoginID, saveOptions.SaveLoginPSW);
        }

        private void ShowLoading()
        {
            aggregator.GetEvent<LoadingEvent>().Subscribe(OnShowLoading);
        }

        private void OnShowLoading(Visibility obj)
        {
            IsLoading = obj;
        }

        private void OnMinimize(object obj)
        {
            (obj as Window).WindowState = WindowState.Minimized;
        }

        private void OnLogin(object obj)
        {
            try
            {
                ErrorMsg = string.Empty;
                if (string.IsNullOrEmpty(saveOptions.SaveLoginID))
                {
                    throw new Exception("请输入用户名");
                }
                if (string.IsNullOrEmpty(saveOptions.SaveLoginPSW))
                {
                    throw new Exception("请输入密码");
                }
            }
            catch (Exception ex)
            {
                ErrorMsg = "登录失败！" + ex.Message;
                ErrorMessageShow();
                return;
            }

            aggregator.GetEvent<LoadingEvent>().Publish(Visibility.Visible);
            EnabledLogin = false;
            BackgroundWorker.RunWorkerAsync();
        }

        private void ErrorMessageShow()
        {
            //DialogParameters par = new DialogParameters();
            //par.Add("Title", "提醒");
            //par.Add("Message", this.ErrorMsg);
            //par.Add("IsCancel", false);
            //dialogService.ShowDialog("MsgDialogView", par, DialogClosedCallback);
            MessageBox.Show(ErrorMsg);
        }

        private void DialogClosedCallback(IDialogResult obj)//什么也没做
        {
            if (obj.Result == ButtonResult.OK)//点击了确定按键
            {
                //接收传入参数
                //string result = obj.Parameters.GetValue<string>("Value");
            }
        }

        private void Skip2MainView()
        {

            Application.Current.MainWindow.Close();
            main = Container.Resolve<MainView>();
            main.Show();
            Application.Current.MainWindow = main;
        }


        private void SaveOptionsXml()
        {
            using (var stream = File.Open("SaveOptions.xml", FileMode.Create))
            {
                if (saveOptions.SaveUser == false)
                {
                    saveOptions.SaveLoginID = "";
                    saveOptions.SaveLoginPSW = "";
                }
                var serializer = new XmlSerializer(typeof(SaveOptions));
                serializer.Serialize(stream, saveOptions);
            }
        }

        private void AutoLogin()
        {
            if (saveOptions.AutoLogin)
            {
                OnLogin(main);
            }
        }
    }
}
