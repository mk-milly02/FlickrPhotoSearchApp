using PhotoApp.Domain.Models;
using System.Windows;
using System.Windows.Controls;

namespace PhotoApp.UI.CustomControls
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:PhotoApp.UI.CustomControls"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:PhotoApp.UI.CustomControls;assembly=PhotoApp.UI.CustomControls"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:PhotoElement/>
    ///
    /// </summary>
    public class PhotoElement : Control
    {
        public PhotoElement(Photo photo)
        {
            Title = photo.Title;
            Published = photo.Published.ToShortDateString();
            Time = photo.Published.ToShortTimeString();
            ImageSource = photo.Media.M;
        }

        static PhotoElement()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PhotoElement), 
                new FrameworkPropertyMetadata(typeof(PhotoElement)));
        }

        #region Properties

        public string ImageSource
        {
            get { return (string)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(string), typeof(PhotoElement));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(PhotoElement));

        public string Published
        {
            get { return (string)GetValue(PublishedProperty); }
            set { SetValue(PublishedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Published.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PublishedProperty =
            DependencyProperty.Register("Published", typeof(string), typeof(PhotoElement));

        public string Time
        {
            get { return (string)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Time.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TimeProperty =
            DependencyProperty.Register("Time", typeof(string), typeof(PhotoElement));

        #endregion
    }
}
