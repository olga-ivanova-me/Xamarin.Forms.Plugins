using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using Rectangle = Windows.UI.Xaml.Shapes.Rectangle;

namespace RoundedBoxView.Forms.Plugin.Win10.ExtensionMethods
{
    public static class BorderExtensions
    {
        public static void InitializeFrom(this Border nativeControl, Abstractions.RoundedBoxView formsControl)
        {
            if (nativeControl == null || formsControl == null)
                return;

            if (formsControl.HeightRequest >= 0)
            {
                nativeControl.Height = formsControl.HeightRequest;
            }
            if (formsControl.WidthRequest >= 0)
            {
                nativeControl.Width = formsControl.WidthRequest;
            }
            nativeControl.UpdateCornerRadius(formsControl.CornerRadius);
            nativeControl.UpdateBorderColor(formsControl.BorderColor);

            var rectangle = new Rectangle();

            rectangle.InitializeFrom(formsControl);

            nativeControl.Child = rectangle;
        }

        public static void UpdateFrom(this Border nativeControl, Abstractions.RoundedBoxView formsControl,
          string propertyChanged)
        {
            if (nativeControl == null || formsControl == null)
                return;

            if (propertyChanged == VisualElement.HeightRequestProperty.PropertyName)
            {
                nativeControl.Height = formsControl.HeightRequest;

                var rect = nativeControl.Child as Rectangle;

                if (rect != null)
                {
                    rect.UpdateControlHeight(formsControl.HeightRequest);
                }
            }
            if (propertyChanged == VisualElement.WidthRequestProperty.PropertyName)
            {
                nativeControl.Width = formsControl.WidthRequest;

                var rect = nativeControl.Child as Rectangle;

                if (rect != null)
                {
                    rect.UpdateControlWidth(formsControl.WidthRequest);
                }
            }
            if (propertyChanged == Abstractions.RoundedBoxView.CornerRadiusProperty.PropertyName)
            {
                nativeControl.UpdateCornerRadius(formsControl.CornerRadius);

                var rect = nativeControl.Child as Rectangle;

                if (rect != null)
                {
                    rect.UpdateCornerRadius(formsControl.CornerRadius);
                }

            }
            if (propertyChanged == VisualElement.BackgroundColorProperty.PropertyName)
            {
                var rect = nativeControl.Child as Rectangle;

                if (rect != null)
                {
                    rect.UpdateBackgroundColor(formsControl.BackgroundColor);
                }
            }

            if (propertyChanged == Abstractions.RoundedBoxView.BorderColorProperty.PropertyName)
            {
                nativeControl.Background = formsControl.BorderColor.ToBrush();
            }

            if (propertyChanged == Abstractions.RoundedBoxView.BorderThicknessProperty.PropertyName)
            {
                var rect = nativeControl.Child as Rectangle;

                if (rect != null)
                {
                    rect.UpdateBorderThickness(formsControl.BorderThickness, formsControl.HeightRequest, formsControl.WidthRequest);
                }
            }
        }

        private static void UpdateCornerRadius(this Border nativeControl, double cornerRadius)
        {
            var relativeBorderCornerRadius = cornerRadius * 1.25;

            nativeControl.CornerRadius = new CornerRadius(relativeBorderCornerRadius);
        }

        public static void UpdateBorderColor(this Border nativeControl, Color backgroundColor)
        {
            nativeControl.Background = backgroundColor.ToBrush();
        }
    }
}