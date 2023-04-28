using Microsoft.UI.Xaml.Data;
using System;
using System.Globalization;

namespace UnoSampleApp.Converters;

public class FromNullableBoolToCustomValueConverter : IValueConverter
{
    public object NullOrFalseValue { get; set; }

    public object TrueValue { get; set; }

    object IValueConverter.Convert(object value, Type targetType, object parameter, string culture)
    {
        return Convert(value, targetType, parameter);
    }

    object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string culture)
    {
        return ConvertBack(value, targetType, parameter);
    }

    public object Convert(object value, Type targetType, object parameter)
    {
        if (parameter != null)
        {
            throw new ArgumentException($"This converter does not use any parameters. You should remove \"{parameter}\" passed as parameter.");
        }

        if (value != null && !(value is bool))
        {
            throw new ArgumentException($"Value must either be null or of type bool. Got {value} ({value.GetType().FullName})");
        }

        if (value == null)
        {
            return NullOrFalseValue;
        }
        else
        {
            return TrueValue;
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter)
    {
        if (parameter != null)
        {
            throw new ArgumentException($"This converter does not use any parameters. You should remove \"{parameter}\" passed as parameter.");
        }

        if (object.Equals(this.TrueValue, this.NullOrFalseValue))
        {
            throw new InvalidOperationException("Cannot convert back if both custom values are the same");
        }

        return this.TrueValue != null ?
            value.Equals(TrueValue) :
            !value.Equals(this.NullOrFalseValue);
    }
}
