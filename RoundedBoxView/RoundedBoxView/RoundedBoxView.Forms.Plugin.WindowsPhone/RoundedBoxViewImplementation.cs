using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using RoundedBoxView.Forms.Plugin.WindowsPhone;
using RoundedBoxView.Forms.Plugin.WindowsPhone.ExtensionMethods;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;
using Color = Xamarin.Forms.Color;
using Rectangle = System.Windows.Shapes.Rectangle;

[assembly:
  ExportRenderer(typeof (RoundedBoxView.Forms.Plugin.Abstractions.RoundedBoxView), typeof (RoundedBoxViewRenderer))]

namespace RoundedBoxView.Forms.Plugin.WindowsPhone
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