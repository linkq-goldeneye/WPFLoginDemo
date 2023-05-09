using System.Windows;
using Prism.Ioc;
using LoginDemo.Share.Events;
using Syncfusion.Licensing;
using Hardcodet.Wpf.TaskbarNotification;
using LoginDemo.Service.Interfaces;
using LoginDemo.Service.Services;
using LoginDemo.Client.Views;

namespace LoginDemo.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public App()
        {
            //Register Syncfusion license
            SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt/QHRqVVhkX1pFdEBBXHxAd1p/VWJYdVt5flBPcDwsT3RfQF5jSH9Sd0VnXH5ecnJVQQ==;Mgo+DSMBPh8sVXJ0S0J+XE9AdVRDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS31Td0RiWH9adXVVRGhUVg==;ORg4AjUWIQA/Gnt2VVhkQlFaclxJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxQdkRiWH5edHFURmNdUUM=;OTIxNDI3QDMyMzAyZTM0MmUzME1TM2FWMjVoeW5DVWtPWXpQZFg2SHh3RnM3Z2laUGhiMlNDWkV2aTRvOTQ9;OTIxNDI4QDMyMzAyZTM0MmUzMEtTK1UzSnFUQnltZ29DM2FmOHJvaWtSR0NyYXExK05VYmZYRDZzejVRdGM9;NRAiBiAaIQQuGjN/V0Z+WE9EaFtBVmJLYVB3WmpQdldgdVRMZVVbQX9PIiBoS35RdUViWH5fcHBQR2BaUUdx;OTIxNDMwQDMyMzAyZTM0MmUzMGYrekFxV2lJNjFxZUVWMW91NnZNZ1hsLzJzclc2dkU3dnplczFBUzhmaUU9;OTIxNDMxQDMyMzAyZTM0MmUzMElEL1E5eGgrTWJTZTNVRUs3YVh0YytrR3pqTkJ1RU1SZUdaN3ZWaFJuWnM9;Mgo+DSMBMAY9C3t2VVhkQlFaclxJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxQdkRiWH5edHFURmhaVEM=;OTIxNDMzQDMyMzAyZTM0MmUzMEhzMUhFdzM3MU5HMG0wM0c0Y0xQUUFzRVJJSHU5ZVhGbGVwYVN4QnhROXc9;OTIxNDM0QDMyMzAyZTM0MmUzMEl2d2dpUU0rQWUzSXFXbnpjOVF5TG1jTjNIR3BlV25xY3hXU0N5T3JqRk09;OTIxNDM1QDMyMzAyZTM0MmUzMGYrekFxV2lJNjFxZUVWMW91NnZNZ1hsLzJzclc2dkU3dnplczFBUzhmaUU9");
        }
        protected override Window CreateShell()
        {
            return Container.Resolve<LoginView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ILoginService, LoginService>();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _taskbar = (TaskbarIcon)FindResource("Taskbar");
            base.OnStartup(e);
        }
        private TaskbarIcon _taskbar;
    }
}
