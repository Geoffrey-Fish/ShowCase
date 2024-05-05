using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

using Color = System.Windows.Media.Color;

namespace CatLitterMoneyBox.Commands;

public class ColorToBrushConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        if(value is Color color) return new SolidColorBrush(Color.FromArgb(color.A, color.R, color.G, color.B));
        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotSupportedException();
    }
}
/*Discussion with my boy:
 I understand your concern. Working with colors and brushes in XAML can require a bit more effort, especially when using the MVVM pattern. However, the reason for using a Brush instead of a Color directly is that the Background property of the TextBox expects a Brush object.

To simplify the process, you can create a simple value converter that converts a Color to a Brush object. Here's an example:
Although it may seem like a bit of additional work, creating a converter allows you to adhere to the expected data types in the XAML bindings and keep the separation of concerns between the View and ViewModel.

Alternatively, if you prefer a simpler solution without converters, you can consider using a framework that provides built-in support for more direct color-to-brush bindings, such as the MVVM frameworks MahApps.Metro or DevExpress, which offer additional controls with extended functionality.

Remember, the added complexity of using a Brush instead of a Color is to accommodate the flexible styling options provided by WPF and XAML. This allows for more advanced customization in the future if needed.*/