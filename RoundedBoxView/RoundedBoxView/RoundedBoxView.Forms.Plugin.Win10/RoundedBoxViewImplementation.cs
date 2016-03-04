using System.ComponentModel;
using Windows.UI.Xaml.Controls;
using RoundedBoxView.Forms.Plugin.Win10;
using RoundedBoxView.Forms.Plugin.Win10.ExtensionMethods;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly:
    ExportRenderer(typeof(RoundedBoxView.Forms.Plugin.Abstractions.RoundedBoxView), typeof(RoundedBoxViewRenderer))]

namespace RoundedBoxView.Forms.Plugin.Win10
{
    /// <summary>
    ///   RoundedBoxView Renderer
    /// </summary>
    public class RoundedBoxViewRenderer : ViewRenderer<Abstractions.RoundedBoxView, Border>
    {
        /// <summary>
        ///   Used for registration with dependency service
        /// </summary>
        public static void Init()
        {
        }

        private Abstractions.RoundedBoxView _formControl
        {
            get { return Element; }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Abstractions.RoundedBoxView> e)
        {
            base.OnElementChanged(e);

            var border = new Border();
            border.InitializeFrom(_formControl);
            SetNativeControl(border);

            ClearBackgroundColor();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            Control.UpdateFrom(_formControl, e.PropertyName);

            if (e.PropertyName == VisualElement.BackgroundColorProperty.PropertyName)
            {
                ClearBackgroundColor();
            }
        }

        /// <summary>
        /// Clears the background color of BoxView that is rendered.
        /// </summary>
        /// <remarks> Without clearing background color the corner radius will be invisible.</remarks>
        private void ClearBackgroundColor()
        {
            this.Background = Color.Transparent.ToBrush();
        }
    }
}