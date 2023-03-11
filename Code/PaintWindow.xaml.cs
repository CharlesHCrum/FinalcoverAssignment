using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace FinalcoverAssignment
{
    /*
     * A window for drawing on the image
     */
    public partial class PaintWindow : Window
    {
        //various elements needed later
        private Point startPoint;
        private Rectangle? rect;
        private int color; 
        bool isPressed;
        Rectangle? ClickedRectangle; //needed to allow color selection
        int ignoreshapes; //to allow user to draw new shapes on top of shapes

        public PaintWindow(string filename)
        {
            InitializeComponent();
            icanvas.Background = new ImageBrush(new BitmapImage(new Uri(filename)));
            color = -1;
            isPressed = false;
            ignoreshapes = 0;

        }
        /*
         * Control logic for moving the mouse around.
         * 
         */
        private void mouseMove(object sender, MouseEventArgs e)
        {
            //Drag and drop functionality
            if (e.OriginalSource is Rectangle && (ignoreshapes == 0))
            {
                //find the rectangle that was clicked
                Rectangle ClickedRectangle = (Rectangle)e.OriginalSource;
                //as long as mouse button is held down, move the rectangle along with the mouse
                if (isPressed)
                {
                    Point position = e.GetPosition(icanvas);
                    double daltaY = position.Y - startPoint.Y;
                    double daltaX = position.X - startPoint.X;
                    //change rectangle location to new location as the mouse moves
                    ClickedRectangle.SetValue(Canvas.TopProperty, (double)ClickedRectangle.GetValue(Canvas.TopProperty) + daltaY);
                    ClickedRectangle.SetValue(Canvas.LeftProperty, (double)ClickedRectangle.GetValue(Canvas.LeftProperty) + daltaX);
                    startPoint = position;
                }
            }

            //if not clicking an already drawn rectangle, allow the user to draw a rectangle 
            else
            {
                //if the mouse isn't held down, do nothing
                if (e.LeftButton == MouseButtonState.Released || rect == null)
                    return;

                //draw the rectangle as the mouse moves
                var pos = e.GetPosition(icanvas);

                var x = Math.Min(pos.X, startPoint.X);
                var y = Math.Min(pos.Y, startPoint.Y);

                var w = Math.Max(pos.X, startPoint.X) - x;
                var h = Math.Max(pos.Y, startPoint.Y) - y;

                rect.Width = w;
                rect.Height = h;

                Canvas.SetLeft(rect, x);
                Canvas.SetTop(rect, y);
            }
        }

        /*
         * Control logic for when mouse button is clicked
         */
        private void mouseDown(object sender, MouseButtonEventArgs e)
        {
            ignoreshapes = 0;
            startPoint = e.GetPosition(icanvas);

            //when rectangle is clicked 
            if ((e.OriginalSource is Rectangle) && (ignoreshapes == 0))
            {
                ClickedRectangle = (Rectangle)e.OriginalSource;
                ClickedRectangle.Opacity = 0.5;
                //click twice to remove
                if (e.ClickCount == 2)
                {
                    icanvas.Children.Remove(ClickedRectangle);
                }
                else
                {
                    //for drag and drop
                    isPressed = true;
                    startPoint = e.GetPosition(icanvas);
                    ClickedRectangle.CaptureMouse();
                }
            }

            /*
             * For when mouse button is clicked somewhere that does not contain a rectangle 
             */
            else
            {
                //create a rectangle
                ignoreshapes = 1; //this allows the user to draw the shape on top of another shape, it is checked when moving the mouse so that the drag/drop/delete functionality does not interfere
                rect = new Rectangle
                //black by default
                {
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };
                
                rect.Fill = Brushes.Black;

                //The user can select a color beforehand and draw a rectangle of the desired color
                //uses the "color" variable that is set when the user clicks a color box
                switch (color)
                {
                    case 0:
                        rect = new Rectangle
                        {
                            Stroke = Brushes.Black,
                            StrokeThickness = 2
                        };
                        rect.Fill = Brushes.Black;
                        break;
                    case 1:
                        rect = new Rectangle
                        {
                            Stroke = Brushes.White,
                            StrokeThickness = 2
                        };
                        rect.Fill = Brushes.White;
                        break;
                    case 2:
                        rect = new Rectangle
                        {
                            Stroke = Brushes.Red,
                            StrokeThickness = 2
                        };
                        rect.Fill = Brushes.Red;
                        break;
                    case 3:
                        rect = new Rectangle
                        {
                            Stroke = Brushes.Yellow,
                            StrokeThickness = 2
                        };
                        rect.Fill = Brushes.Yellow;
                        break;
                    case 4:
                        rect = new Rectangle
                        {
                            Stroke = Brushes.Orange,
                            StrokeThickness = 2
                        };
                        rect.Fill = Brushes.Orange;
                        break;
                    case 5:
                        rect = new Rectangle
                        {
                            Stroke = Brushes.Green,
                            StrokeThickness = 2
                        };
                        rect.Fill = Brushes.Green;
                        break;
                }

                Canvas.SetLeft(rect, startPoint.X);
                Canvas.SetTop(rect, startPoint.Y);
                icanvas.Children.Add(rect);

            }
        }
        /*
         * Logic for when the mouse is not being pressed
         */
        private void mouseUp(object sender, MouseButtonEventArgs e)
        {
            //The "drop" part of the drag and drop, releasing the mouse button "deselects" the shape
            if (e.OriginalSource is Rectangle)
            {
                Rectangle ClickedRectangle = (Rectangle)e.OriginalSource;
                ClickedRectangle.Opacity = 1;
                ClickedRectangle.ReleaseMouseCapture();
                isPressed = false;
            }

            //otherwise do nothing (i.e. when moving the cursor around the screen)
            else
            {
                rect = null;
            }
        }

        /*
         * Functions for selecting the color by clicking on the appropriate color box on the palette
         * Uses the globally stored "ClickedRectangle" to allow the user to select an already drawn rectangle then change the color
         * Otherwise just sets the color so that the user can draw a new rectangle of that color
         */
        private void Black_Click(object sender, RoutedEventArgs e)
        {
            color = 0;
            if (ClickedRectangle != null)
            {
                ClickedRectangle.Fill = Brushes.Black;
                ClickedRectangle.Stroke = Brushes.Black;
                //set it to null, otherwise the user can keep changing that same rectangle over and over by accident
                //this makes the user click the rectangle again to change the color again
                ClickedRectangle = null;
            }
        }

        private void White_Click(object sender, RoutedEventArgs e)
        {
            color = 1;
            if (ClickedRectangle != null)
            {
                ClickedRectangle.Fill = Brushes.White;
                ClickedRectangle.Stroke = Brushes.White;
                ClickedRectangle = null;
            }
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            color = 2;
            if (ClickedRectangle != null)
            {
                ClickedRectangle.Fill = Brushes.Red;
                ClickedRectangle.Stroke = Brushes.Red;
                ClickedRectangle = null;
            }
        }

        private void Yellow_Click(object sender, RoutedEventArgs e)
        {
            color = 3;
            if (ClickedRectangle != null)
            {
                ClickedRectangle.Fill = Brushes.Yellow;
                ClickedRectangle.Stroke = Brushes.Yellow;
                ClickedRectangle = null;
            }
        }

        private void Orange_Click(object sender, RoutedEventArgs e)
        {
            color = 4;
            if (ClickedRectangle != null)
            {
                ClickedRectangle.Fill = Brushes.Orange;
                ClickedRectangle.Stroke = Brushes.Orange;
                ClickedRectangle = null;
            }
        }

        private void Green_Click(object sender, RoutedEventArgs e)
        {
            color = 5;
            if (ClickedRectangle != null)
            {
                ClickedRectangle.Fill = Brushes.Green;
                ClickedRectangle.Stroke = Brushes.Green;
                ClickedRectangle = null;
            }
        }

        /*
         * Save Button logic: Saves the Canvas with the image background to a new bitmap file
         * Does not exit the program.
         */
        private void ButtonSave(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //default extension, only allows supported file types
            saveFileDialog.DefaultExt = ".jpg";
            saveFileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                                    "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                                    "Portable Network Graphic (*.png)|*.png";
            if (saveFileDialog.ShowDialog() == true)
            {
                RenderTargetBitmap bmp = new RenderTargetBitmap((int)icanvas.ActualWidth, (int)icanvas.ActualHeight, 100.0, 100.0, PixelFormats.Default);
                bmp.Render(icanvas);

                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bmp));

                string filename = saveFileDialog.FileName;

                System.IO.FileStream stream = System.IO.File.Create(filename);
                encoder.Save(stream);
                stream.Close();
            }

        }
        //Exits the program without saving the image
        private void ButtonExit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

