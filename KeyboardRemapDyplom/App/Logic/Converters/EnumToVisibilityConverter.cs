using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows;

namespace App.Logic.Converters
{
    [MarkupExtensionReturnType(typeof(IValueConverter))]
    [ValueConversion(typeof(Enum), typeof(Visibility))]
    public class EnumToVisibilityConverter : MarkupExtension, IValueConverter
    {
        private static EnumToVisibilityConverter _converter;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _converter ?? (_converter = new EnumToVisibilityConverter());
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null)
            {
                // Проверяем, является ли значение перечисления равным параметру
                return !value.Equals(parameter) ? Visibility.Visible : Visibility.Collapsed;
            }
            else
            {
                // Проверяем, является ли значение перечисления отличным от нуля
                return !value.Equals(0) ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class EnumToInvertedVisibilityConverter : MarkupExtension, IValueConverter
    {
        private static EnumToInvertedVisibilityConverter _converter;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _converter ?? (_converter = new EnumToInvertedVisibilityConverter());
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null)
            {
                // Проверяем, является ли значение перечисления равным параметру
                return !value.Equals(parameter) ? Visibility.Collapsed : Visibility.Visible;
            }
            else
            {
                // Проверяем, является ли значение перечисления отличным от нуля
                return !value.Equals(0) ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class EnumToBooleanConverter : MarkupExtension, IValueConverter
    {
        private static EnumToBooleanConverter _converter;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _converter ?? (_converter = new EnumToBooleanConverter());
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null)
            {
                // Проверяем, является ли значение перечисления равным параметру
                return !value.Equals(parameter) ? true : false;
            }
            else
            {
                // Проверяем, является ли значение перечисления отличным от нуля
                return !value.Equals(0) ? true : false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class EnumToInvertedBooleanConverter : MarkupExtension, IValueConverter
    {
        private static EnumToInvertedBooleanConverter _converter;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _converter ?? (_converter = new EnumToInvertedBooleanConverter());
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null)
            {
                // Проверяем, является ли значение перечисления равным параметру
                return !value.Equals(parameter) ? false : true;
            }
            else
            {
                // Проверяем, является ли значение перечисления отличным от нуля
                return !value.Equals(0) ? false : true;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
