using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;
using System.Windows.Media.Effects;

namespace DubVisionWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        BlurEffect blur = new BlurEffect();

        //Store lorem ipsum somewhere out of the way so its not cluttering up a function
        string lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
            "Fusce vitae neque id tortor pulvinar tincidunt. Pellentesque eleifend facilisis ex ornare molestie. " +
            "Fusce varius arcu quis erat condimentum bibendum. Duis rhoncus diam id cursus gravida. Quisque lacinia, ex sit amet scelerisque gravida, est lacus tempus nibh, " +
            "fermentum egestas ex metus rutrum dui. Maecenas congue varius dolor, sed molestie dui porttitor vel. " +
            "Cras lacinia elementum mauris ultricies porta. Quisque interdum eget risus " +
            "vel condimentum. Pellentesque facilisis tortor urna, sit amet vehicula dolor dignissim eu. " +
            "Pellentesque vel nisl mi. Praesent interdum est nulla, at ullamcorper elit blandit eget. " +
            "Morbi in enim efficitur, bibendum augue eget, imperdiet nisi. Interdum et malesuada fames ac ante ipsum primis in faucibus. " +
            "Proin ut dui nec arcu finibus congue.";

        public MainWindow()
        {
            InitializeComponent();
        }

        //set font size to value from slider when slider moves
        private void fontSizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            sampleText.FontSize = fontSizeSlider.Value;
            ghostText.FontSize = fontSizeSlider.Value;
        }

        //set text colour to value from color picker when color picker value changes
        private void colourCanvas_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            sampleText.Foreground = new SolidColorBrush(colourCanvas.SelectedColor.Value);
            ghostText.Foreground = new SolidColorBrush(colourCanvas.SelectedColor.Value);
        }

        //set background colour to value from color picker when color picker value changes
        private void bgColCanvas_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            Background = new SolidColorBrush(bgColCanvas.SelectedColor.Value);
        }

        //checkbox for ghosting enabled
        private void ghostCheck_Checked(object sender, RoutedEventArgs e)
        {
            //turn on ghost text
            ghostText.Visibility = Visibility.Visible;

            //enable the ghost settings sliders and give full opacity rather than faded out
            ghostOpacitySlider.IsEnabled = true;
            ghostOffsetSlider.IsEnabled = true;
            blurSlider.IsEnabled = true;

            ghostOpacitySlider.Opacity = 1;
            ghostOffsetSlider.Opacity = 1;
            blurSlider.Opacity = 1;
        }
    
        //opposite of checked function but also set values back to default
        private void ghostCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            ghostText.Visibility = Visibility.Hidden;

            ghostOpacitySlider.IsEnabled = false;
            ghostOffsetSlider.IsEnabled = false;
            blurSlider.IsEnabled = false;

            ghostOpacitySlider.Opacity = 0.5;
            ghostOffsetSlider.Opacity = 0.5;
            blurSlider.Opacity = 0.5;

            ghostOffsetSlider.Value = 0;
            ghostOpacitySlider.Value = 1;
            blurSlider.Value = 0;
        }

        //use margin to create an offset between the two text blocks with the value controlled by a slider, sims the 2x vision
        private void ghostOffsetSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ghostText.Margin = new Thickness(10, 10, 10, 10 + ghostOffsetSlider.Value);
        }

        //opacity value of ghost from slider
        private void ghostOpacitySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ghostText.Opacity = ghostOpacitySlider.Value;
        }

        //blur amount from slider
        private void blurSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            blur.Radius = blurSlider.Value;
            ghostText.Effect = blur;
        }

        //choose what text is shown in textboxes
        private void textSelectDropDown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (textSelectDropDown.SelectedIndex == 0)
            {
                sampleText.Text = "Sample Text";
                ghostText.Text = "Sample Text";
            }
            else if (textSelectDropDown.SelectedIndex == 1)
            {
                sampleText.Text = lorem;
                ghostText.Text = lorem;
            }
        }
    }
}
