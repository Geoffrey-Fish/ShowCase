using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CatLitterMoneyBox.Controls;

public static class ColorChangingOnClick {
    public static readonly DependencyProperty TemporaryColorProperty =
        DependencyProperty.RegisterAttached("TemporaryColor", typeof(SolidColorBrush), typeof(ColorChangingOnClick),
                                            new PropertyMetadata(new SolidColorBrush(Colors.Green)));
    public static readonly DependencyProperty OriginalColorProperty =
        DependencyProperty.RegisterAttached("OriginalColor", typeof(SolidColorBrush), typeof(ColorChangingOnClick),
                                            new PropertyMetadata(new SolidColorBrush(Colors.Red)));
    public static readonly DependencyProperty IsColorChangingOnClickEnabledProperty =
        DependencyProperty.RegisterAttached("IsColorChangingOnClickEnabled", typeof(bool), typeof(ColorChangingOnClick),
                                            new PropertyMetadata(false, OnIsColorChangingOnClickEnabledChanged));

    public static SolidColorBrush GetTemporaryColor(DependencyObject obj) {
        return (SolidColorBrush)obj.GetValue(TemporaryColorProperty);
    }

    public static void SetTemporaryColor(DependencyObject obj, SolidColorBrush value) {
        obj.SetValue(TemporaryColorProperty, value);
    }

    public static SolidColorBrush GetOriginalColor(DependencyObject obj) {
        return (SolidColorBrush)obj.GetValue(OriginalColorProperty);
    }

    public static void SetOriginalColor(DependencyObject obj, SolidColorBrush value) {
        obj.SetValue(OriginalColorProperty, value);
    }

    public static bool GetIsColorChangingOnClickEnabled(DependencyObject obj) {
        return (bool)obj.GetValue(IsColorChangingOnClickEnabledProperty);
    }

    public static void SetIsColorChangingOnClickEnabled(DependencyObject obj, bool value) {
        obj.SetValue(IsColorChangingOnClickEnabledProperty, value);
    }

    private static void OnIsColorChangingOnClickEnabledChanged(
        DependencyObject d, DependencyPropertyChangedEventArgs e) {
        if(d is Button button) {
            if((bool)e.NewValue) {
                button.PreviewMouseDown += OnButtonPreviewMouseDown;
                button.PreviewMouseUp   += OnButtonPreviewMouseUp;
            } else {
                button.PreviewMouseDown -= OnButtonPreviewMouseDown;
                button.PreviewMouseUp   -= OnButtonPreviewMouseUp;
            }
        }
    }

    private static void OnButtonPreviewMouseDown(object sender, MouseButtonEventArgs e) {
        if(sender is Button button) {
            var temporaryColor = GetTemporaryColor(button);
            button.Background = temporaryColor;
        }
    }

    private static void OnButtonPreviewMouseUp(object sender, MouseButtonEventArgs e) {
        if(sender is Button button) {
            var originalColor = GetOriginalColor(button);
            button.Background = originalColor;
        }
    }
}