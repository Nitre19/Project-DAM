using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<ColorItem> ColorList;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btClear_Click(object sender, RoutedEventArgs e)
        {
            inkCanvasMain.Strokes.Clear();
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void windowMain_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void windowMain_Activated(object sender, EventArgs e)
        {
            PopulateColorList();
            SetSizeControls();            
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "imatge"; 
            dlg.DefaultExt = ".jpg"; 
            dlg.Filter = "Image (.jpg)|*.jpg"; 

            // Mostrar show file dialog
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                // Guardar document
                string filename = dlg.FileName;

                //Relacionar el ink Canvas a un bitmap per poder-lo guardar
                BitmapSource rtb = CaptureScreen(inkCanvasMain, 96d, 96d);

                using (FileStream fs = new FileStream(filename, FileMode.Create))
                {
                    BmpBitmapEncoder encoder = new BmpBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(rtb));
                    encoder.Save(fs);
                }
            }
        }

        // Normalment, al guardar la imatge el dibuix esta mogut cap a l'esquerra uns 10 pixels perque el grid pare
        // aplica uns canvis automatics a la mida dels seus fills. Aquest mètode és un workaround per solucionar aquest problema.
        private static BitmapSource CaptureScreen(Visual target, double dpiX, double dpiY)
        {
            if (target == null)
            {
                return null;
            }
            Rect bounds = VisualTreeHelper.GetDescendantBounds(target);
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)(bounds.Width * dpiX / 96.0),
                                                            (int)(bounds.Height * dpiY / 96.0),
                                                            dpiX,
                                                            dpiY,
                                                            PixelFormats.Pbgra32);
            DrawingVisual dv = new DrawingVisual();
            using (DrawingContext ctx = dv.RenderOpen())
            {
                VisualBrush vb = new VisualBrush(target);
                ctx.DrawRectangle(vb, null, new Rect(new Point(), bounds.Size));
            }
            rtb.Render(dv);
            return rtb;
        }
        /*
        private void ClrPckerInk_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            inkCanvasMain.DefaultDrawingAttributes.Color = ClrPckerInk.SelectedColor.Value;
            
        }
        */
        private void btDecreaseSize_Click(object sender, RoutedEventArgs e)
        {
            if (inkCanvasMain.DefaultDrawingAttributes.Width > 1)
            {
                inkCanvasMain.DefaultDrawingAttributes.Width -= 1;
                inkCanvasMain.DefaultDrawingAttributes.Height -= 1;
                ellTamany.Width = inkCanvasMain.DefaultDrawingAttributes.Width;
                ellTamany.Height = inkCanvasMain.DefaultDrawingAttributes.Height;
            }
        }

        private void btSize2_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btIncreaseSize_Click(object sender, RoutedEventArgs e)
        {
            if(inkCanvasMain.DefaultDrawingAttributes.Width < 20)
            {
                inkCanvasMain.DefaultDrawingAttributes.Width += 1;
                inkCanvasMain.DefaultDrawingAttributes.Height += 1;
                ellTamany.Width = inkCanvasMain.DefaultDrawingAttributes.Width;
                ellTamany.Height = inkCanvasMain.DefaultDrawingAttributes.Height;
            }
            
        }

        private void btErase_Click(object sender, RoutedEventArgs e)
        {
            inkCanvasMain.EditingMode = InkCanvasEditingMode.EraseByPoint;
        }

        private void btDraw_Click(object sender, RoutedEventArgs e) 
        {
            inkCanvasMain.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void PopulateColorList()
        {
            btColor1.Background = Brushes.Black;
            btColor1.BorderBrush = Brushes.Black;
            btColor2.Background = Brushes.Red;
            btColor3.Background = Brushes.Green;
            btColor4.Background = Brushes.Yellow;
            btColor5.Background = Brushes.Pink;
            btColor6.Background = Brushes.Blue;
        }

        private void SetSizeControls()
        {
            inkCanvasMain.Height = gridMain.ActualHeight - 200;
            inkCanvasMain.Width = gridMain.ActualWidth - 30;

            borderInkCanvas.Height = inkCanvasMain.Height;
            borderInkCanvas.Width = inkCanvasMain.Width;

            btColorPicker.Margin = new Thickness(inkCanvasMain.Margin.Left + btClear.Width * 3, inkCanvasMain.Height + 20 + btClear.Height, 0, 0);

            btClear.Margin = new Thickness(inkCanvasMain.Margin.Left + btClear.Width * 0, inkCanvasMain.Height + 20, 0, 0);
            btClose.Margin = new Thickness(inkCanvasMain.Margin.Left + btClear.Width * 10, inkCanvasMain.Height + 20 + btClear.Height, 0, 0);
            btSave.Margin = new Thickness(inkCanvasMain.Margin.Left + btClear.Width * 0, inkCanvasMain.Height + 20 + btClear.Height, 0, 0);

            btDecreaseSize.Margin = new Thickness(inkCanvasMain.Margin.Left + btClear.Width * 6, inkCanvasMain.Height + 20, 0, 0);
            btTamany.Margin = new Thickness(inkCanvasMain.Margin.Left + btClear.Width * 7, inkCanvasMain.Height + 20, 0, 0);
            btIncreaseSize.Margin = new Thickness(inkCanvasMain.Margin.Left + btClear.Width * 8, inkCanvasMain.Height + 20, 0, 0);

            btDraw.Margin = new Thickness(inkCanvasMain.Margin.Left + btClear.Width * 3, inkCanvasMain.Height + 20, 0, 0);
            btErase.Margin = new Thickness(inkCanvasMain.Margin.Left + btClear.Width * 4, inkCanvasMain.Height + 20, 0, 0);

            btColorPicker.Height = btClear.Height;
            btColorPicker.Width = btClear.Width * 2;

            spColors.Margin = new Thickness(btColorPicker.Margin.Right - 387, 0, 0, -410);
            spColors.Width = btColorPicker.Width;
            spColors.Visibility = Visibility.Collapsed;
        }

        private void btColorPicker_MouseEnter(object sender, MouseEventArgs e)
        {
            spColors.Visibility = Visibility.Visible;
        }

        private void btColorPicker_MouseLeave(object sender, MouseEventArgs e)
        {
            spColors.Visibility = Visibility.Collapsed;
        }

        private void spColors_MouseEnter(object sender, MouseEventArgs e)
        {
            spColors.Visibility = Visibility.Visible;
        }

        private void spColors_MouseLeave(object sender, MouseEventArgs e)
        {
            spColors.Visibility = Visibility.Collapsed;
        }

        private void btColor1_Click(object sender, RoutedEventArgs e)
        {
            btColorPicker.Background = Brushes.Black;
            btColorPicker.BorderBrush = Brushes.Black;
            inkCanvasMain.DefaultDrawingAttributes.Color = Colors.Black;

        }

        private void btColor2_Click(object sender, RoutedEventArgs e)
        {
            btColorPicker.Background = Brushes.Red;
            btColorPicker.BorderBrush = Brushes.Red;
            inkCanvasMain.DefaultDrawingAttributes.Color = Colors.Red;
        }

        private void btColor3_Click(object sender, RoutedEventArgs e)
        {
            btColorPicker.Background = Brushes.Green;
            btColorPicker.BorderBrush = Brushes.Green;
            inkCanvasMain.DefaultDrawingAttributes.Color = Colors.Green;
        }

        private void btColor4_Click(object sender, RoutedEventArgs e)
        {
            btColorPicker.Background = Brushes.Yellow;
            btColorPicker.BorderBrush = Brushes.Yellow;
            inkCanvasMain.DefaultDrawingAttributes.Color = Colors.Yellow;
        }

        private void btColor5_Click(object sender, RoutedEventArgs e)
        {
            btColorPicker.Background = Brushes.Pink;
            btColorPicker.BorderBrush = Brushes.Pink;
            inkCanvasMain.DefaultDrawingAttributes.Color = Colors.Pink;
        }

        private void btColor6_Click(object sender, RoutedEventArgs e)
        {
            btColorPicker.Background = Brushes.Blue;
            btColorPicker.BorderBrush = Brushes.Blue;
            inkCanvasMain.DefaultDrawingAttributes.Color = Colors.Blue;
        }

        private void btSize_Click(object sender, RoutedEventArgs e)
        {
            inkCanvasMain.DefaultDrawingAttributes.Width = Convert.ToDouble(((Button)sender).Tag.ToString());
            inkCanvasMain.DefaultDrawingAttributes.Height = Convert.ToDouble(((Button)sender).Tag.ToString());
            ellTamany.Width = inkCanvasMain.DefaultDrawingAttributes.Width;
            ellTamany.Height = inkCanvasMain.DefaultDrawingAttributes.Height;
        }

        private void btTamany_MouseEnter(object sender, MouseEventArgs e)
        {
            spSize.Visibility = Visibility.Visible;
        }

        private void btTamany_MouseLeave(object sender, MouseEventArgs e)
        {
            spSize.Visibility = Visibility.Collapsed;
        }

        private void StackPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            spSize.Visibility = Visibility.Visible;
        }

        private void StackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            spSize.Visibility = Visibility.Collapsed;
        }
    }


}
