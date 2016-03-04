﻿using Xamarin.Forms;
using Rectangle = Windows.UI.Xaml.Shapes.Rectangle;

namespace RoundedBoxView.Forms.Plugin.Win10.ExtensionMethods
{
    public static class RectangleExtensions
    {
        public static void InitializeFrom(this Rectangle nativeControl, Abstractions.RoundedBoxView formsControl)
        {
            if (nativeControl == null || formsControl == null)
                return;

            nativeControl.UpdateCornerRadius(formsControl.CornerRadius);
            nativeControl.UpdateBackgroundColor(formsControl.BackgroundColor);
            nativeControl.UpdateBorderThickness(formsControl.BorderThickness, formsControl.HeightRequest, formsControl.WidthRequest);
        }

        public static void UpdateCornerRadius(this Rectangle nativeControl, double cornerRadius)
        {
            var relativeBorderCornerRadius = cornerRadius * 1.25;

            nativeControl.RadiusX = relativeBorderCornerRadius;
            nativeControl.RadiusY = relativeBorderCornerRadius;
        }

        public static void UpdateBackgroundColor(this Rectangle nativeControl, Color backgroundColor)
        {
            nativeControl.Fill = backgroundColor.ToBrush();
        }

        public static void UpdateControlHeight(this Rectangle nativeControl, double formsControlHeightRequest)
        {
            nativeControl.Height = formsControlHeightRequest;
        }

        public static void UpdateControlWidth(this Rectangle nativeControl, double formsControlWidthRequest)
        {
            nativeControl.Width = formsControlWidthRequest;
        }

        /// <summary>
        /// Changes the border size by changing the height and width of the rectangle
        /// </summary>
        /// <param name="nativeControl"></param>
        /// <param name="borderThickness"></param>
        /// <param name="formsControlHeightRequest"></param>
        /// <param name="formsControlWidthRequest"></param>
        public static void UpdateBorderThickness(this Rectangle nativeControl, int borderThickness, double formsControlHeightRequest, double formsControlWidthRequest)
        {
            if (formsControlHeightRequest >= 0 && formsControlWidthRequest >= 0)
            {
                var relativeBorderThickness = borderThickness * 1.7;

                var rectHeight = formsControlHeightRequest - relativeBorderThickness;
                var rectWidth = formsControlWidthRequest - relativeBorderThickness;

                nativeControl.Height = rectHeight;
                nativeControl.Width = rectWidth;
            }
        }
    }
}