using System.Windows;

namespace ElectionSystem
{
    public class AttachedProperties : DependencyObject
    {
        public static string GetLabel(DependencyObject obj)
        {
            return (string)obj.GetValue(LabelProperty);
        }

        public static void SetLabel(DependencyObject obj, object value)
        {
            obj.SetValue(LabelProperty, value);
        }

        // Using a DependencyProperty as the backing store for Label.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(AttachedProperties), new FrameworkPropertyMetadata(""));


    }
}
