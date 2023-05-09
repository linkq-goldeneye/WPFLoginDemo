using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace LoginDemo.Share.Behaviors
{
    public class PasswordBoxAttached
    {
        public static readonly DependencyProperty PasswordProperty = DependencyProperty.RegisterAttached("Password", typeof(string), typeof(PasswordBoxAttached),
            new PropertyMetadata(new PropertyChangedCallback(OnPropertyChanged)));

        public static string GetPassword(DependencyObject d)
        {
            return (string)d.GetValue(PasswordProperty);
        }
        public static void SetPassword(DependencyObject d, string value)
        {
            d.SetValue(PasswordProperty, value);
        }

        public static readonly DependencyProperty AttachProperty = DependencyProperty.RegisterAttached("Attach", typeof(string), typeof(PasswordBoxAttached),
            new PropertyMetadata(new PropertyChangedCallback(OnAttachChanged)));

        public static string GetAttach(DependencyObject d)
        {
            return (string)d.GetValue(AttachProperty);
        }
        public static void SetAttach(DependencyObject d, string value)
        {
            d.SetValue(AttachProperty, value);
        }

        static bool _isUpdating = false;
        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox pb = d as PasswordBox;
            pb.PasswordChanged -= Pb_PasswordChanged;
            if (!_isUpdating)
                (d as PasswordBox).Password = e.NewValue.ToString();
            pb.PasswordChanged += Pb_PasswordChanged;
        }

        private static void OnAttachChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox pb = d as PasswordBox;
            pb.PasswordChanged += Pb_PasswordChanged;
        }

        private static void Pb_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox pb = sender as PasswordBox;
            _isUpdating = true;
            SetPassword(pb, pb.Password);
            _isUpdating = false;
        }
        /*/// <summary>
		/// 密文内容属性
		/// </summary>
		public static readonly DependencyProperty PasswordProperty = DependencyProperty.RegisterAttached(
                "Password", typeof(string), typeof(PasswordBoxAttached),
                new PropertyMetadata("", PasswordPropertyChangedCallback));

        /// <summary>
        /// Get密文字段
        /// </summary>
        [AttachedPropertyBrowsableForType(typeof(PasswordBox))]
        public static string GetPassword(DependencyObject obj)
        {
            return (string)obj.GetValue(PasswordProperty);
        }

        /// <summary>
        /// Set密文字段
        /// </summary>
        public static void SetPassword(DependencyObject obj, string value)
        {
            obj.SetValue(PasswordProperty, value);
        }

        static bool _isUpdating = false;

        /// <summary>
        /// 密文回调事件
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void PasswordPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox pb = (d as PasswordBox);
            pb.PasswordChanged -= Pb_PasswordChanged;
            if (!_isUpdating)
                (d as PasswordBox).Password = e.NewValue.ToString();
            pb.PasswordChanged += Pb_PasswordChanged;
        }

        private static void Pb_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox pb = (sender as PasswordBox);
            _isUpdating = true;
            SetPassword(pb, pb.Password);
            _isUpdating = false;
        }*/
    }
}
