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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Sliding_Puzzle
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(OKP);
        }

        Random r = new Random();
        Image[] rectangle = new Image[25];
        BitmapImage[] bi = new BitmapImage[25];
        int[] num = new int[25];
        Border myBorder = new Border();
        DoubleAnimation da = new DoubleAnimation();
        int topBorder = 0;
        int leftBorder = 0;
        int width = 0;
        int height = 0;
        int limit = 0;
        int pointer = 0;
        bool blinking = false;
        

        private void gameBigin()
        {
            easy.Visibility = Visibility.Hidden;
            medium.Visibility = Visibility.Hidden;
            hard.Visibility = Visibility.Hidden;
            int top = 0;
            int left = 0;

            mainWindow.Width = width * pointer + pointer / 2;
            mainWindow.Height = height * pointer + pointer / 2;
            for (int i = 0; i < limit; i++)
            {
                //num[i] = i + 1;
                bool b = false;
                while (!b)
                {
                    int count = 0;
                    num[i] = r.Next(1, limit + 1);

                    for (int j = 0; j < i; j++)
                    {
                        if (num[j] == num[i])
                        {
                            count++;
                            break;
                        }

                    }
                    if (count != 1)
                    {
                        b = true;
                    }
                }

            }

            for (int i = 0; i < limit; i++)
            {
                rectangle[i] = new Image();

                rectangle[i].Width = width;
                rectangle[i].Height = height;
                Canvas.SetTop(rectangle[i], top);
                Canvas.SetLeft(rectangle[i], left);
                rectangle[i].Source = bi[num[i]];
                canvas.Children.Add(rectangle[i]);
                if ((i + 1) % pointer == 0)
                {
                    left = 0;
                    top += height;
                }
                else
                {
                    left += width;
                }
            }            
        }
             
        private void OKP(object sender, KeyEventArgs e)
        {
            bool track;
            int xspace;
            int yspace;
            int count;
            switch (e.Key.ToString())
            {
                case "Right":                    
                    track = false;
                    xspace = 0;
                    yspace = 0;
                    count = 0;
                    for (int i = 0; i <= limit; i++)
                    {                        
                        for (int j = 0; j < limit; j++)
                        {
                            double yimage = Canvas.GetTop(rectangle[j]);
                            double ximage = Canvas.GetLeft(rectangle[j]);                            
                            if (yimage == yspace && ximage == xspace)
                            {
                                track = false;
                                
                                break;
                            }                       
                            track = true;                                                          
                        }
                        
                        if (track)
                        {
                            int xxspace = xspace - width;
                            int yyspace = yspace;
                            for (int k = 0; k < limit; k++)
                            {
                                double yimage = Canvas.GetTop(rectangle[k]);
                                double ximage = Canvas.GetLeft(rectangle[k]);
                                if (xxspace == ximage && yyspace == yimage)
                                {
                                    Canvas.SetLeft(rectangle[k], xspace);
                                    Canvas.SetTop(rectangle[k], yspace);
                                    break;
                                }
                            }
                            break;
                        }
                        if ((i + 1) % pointer == 0)
                        {
                            xspace = 0;
                            yspace += height;
                        }
                        else
                        {
                            xspace += width;
                        }
                    }                    
                    break;


                case "Down":
                    track = false;
                    xspace = 0;
                    yspace = 0;
                    count = 0;
                    for (int i = 0; i <= limit; i++)
                    {
                        for (int j = 0; j < limit; j++)
                        {
                            double yimage = Canvas.GetTop(rectangle[j]);
                            double ximage = Canvas.GetLeft(rectangle[j]);
                            if (yimage == yspace && ximage == xspace)
                            {
                                track = false;

                                break;
                            }
                            track = true;
                        }

                        if (track)
                        {
                            int xxspace = xspace;
                            int yyspace = yspace - height;
                            for (int k = 0; k < limit; k++)
                            {
                                double yimage = Canvas.GetTop(rectangle[k]);
                                double ximage = Canvas.GetLeft(rectangle[k]);
                                if (xxspace == ximage && yyspace == yimage)
                                {
                                    Canvas.SetLeft(rectangle[k], xspace);
                                    Canvas.SetTop(rectangle[k], yspace);
                                    break;
                                }
                            }
                            break;
                        }
                        if ((i + 1) % pointer == 0)
                        {
                            xspace = 0;
                            yspace += height;
                        }
                        else
                        {
                            xspace += width;
                        }
                    }
                    break;

                case "Left":
                    track = false;
                    xspace = 0;
                    yspace = 0;
                    count = 0;
                    for (int i = 0; i <= limit; i++)
                    {
                        for (int j = 0; j < limit; j++)
                        {
                            double yimage = Canvas.GetTop(rectangle[j]);
                            double ximage = Canvas.GetLeft(rectangle[j]);
                            if (yimage == yspace && ximage == xspace)
                            {
                                track = false;

                                break;
                            }
                            track = true;
                        }

                        if (track)
                        {
                            int xxspace = xspace + width;
                            int yyspace = yspace;
                            for (int k = 0; k < limit; k++)
                            {
                                double yimage = Canvas.GetTop(rectangle[k]);
                                double ximage = Canvas.GetLeft(rectangle[k]);
                                if (xxspace == ximage && yyspace == yimage)
                                {
                                    Canvas.SetLeft(rectangle[k], xspace);
                                    Canvas.SetTop(rectangle[k], yspace);
                                    break;
                                }
                            }
                            break;
                        }
                        if ((i + 1) % pointer == 0)
                        {
                            xspace = 0;
                            yspace += height;
                        }
                        else
                        {
                            xspace += width;
                        }
                    }
                    break;

                case "Up":
                    track = false;
                    xspace = 0;
                    yspace = 0;
                    count = 0;
                    for (int i = 0; i <= limit; i++)
                    {
                        for (int j = 0; j < limit; j++)
                        {
                            double yimage = Canvas.GetTop(rectangle[j]);
                            double ximage = Canvas.GetLeft(rectangle[j]);
                            if (yimage == yspace && ximage == xspace)
                            {
                                track = false;

                                break;
                            }
                            track = true;
                        }

                        if (track)
                        {
                            int xxspace = xspace;
                            int yyspace = yspace + height;
                            for (int k = 0; k < limit; k++)
                            {
                                double yimage = Canvas.GetTop(rectangle[k]);
                                double ximage = Canvas.GetLeft(rectangle[k]);
                                if (xxspace == ximage && yyspace == yimage)
                                {
                                    Canvas.SetLeft(rectangle[k], xspace);
                                    Canvas.SetTop(rectangle[k], yspace);
                                    break;
                                }
                            }
                            break;
                        }
                        if ((i + 1) % pointer == 0)
                        {
                            xspace = 0;
                            yspace += height;
                        }
                        else
                        {
                            xspace += width;
                        }
                    }
                    break;
            }
        }

        private void easy_Click(object sender, RoutedEventArgs e)
        {
            width = 150;
            height = 232;
            limit = 8;
            pointer = 3;
            bi[1] = new BitmapImage(new Uri("/Resourses/yaqHc9Wtqxs_01.jpg", UriKind.Relative));
            bi[2] = new BitmapImage(new Uri("/Resourses/yaqHc9Wtqxs_02.jpg", UriKind.Relative));
            bi[3] = new BitmapImage(new Uri("/Resourses/yaqHc9Wtqxs_03.jpg", UriKind.Relative));
            bi[4] = new BitmapImage(new Uri("/Resourses/yaqHc9Wtqxs_04.jpg", UriKind.Relative));
            bi[5] = new BitmapImage(new Uri("/Resourses/yaqHc9Wtqxs_05.jpg", UriKind.Relative));
            bi[6] = new BitmapImage(new Uri("/Resourses/yaqHc9Wtqxs_06.jpg", UriKind.Relative));
            bi[7] = new BitmapImage(new Uri("/Resourses/yaqHc9Wtqxs_07.jpg", UriKind.Relative));
            bi[8] = new BitmapImage(new Uri("/Resourses/yaqHc9Wtqxs_08.jpg", UriKind.Relative));
            
            gameBigin();
        }

        private void medium_Click(object sender, RoutedEventArgs e)
        {
            width = 150;
            height = 190;
            limit = 15;
            pointer = 4;
            bi[1] = new BitmapImage(new Uri("/Resourses/1.jpg", UriKind.Relative));
            bi[2] = new BitmapImage(new Uri("/Resourses/2.jpg", UriKind.Relative));
            bi[3] = new BitmapImage(new Uri("/Resourses/3.jpg", UriKind.Relative));
            bi[4] = new BitmapImage(new Uri("/Resourses/4.jpg", UriKind.Relative));
            bi[5] = new BitmapImage(new Uri("/Resourses/5.jpg", UriKind.Relative));
            bi[6] = new BitmapImage(new Uri("/Resourses/6.jpg", UriKind.Relative));
            bi[7] = new BitmapImage(new Uri("/Resourses/7.jpg", UriKind.Relative));
            bi[8] = new BitmapImage(new Uri("/Resourses/8.jpg", UriKind.Relative));
            bi[9] = new BitmapImage(new Uri("/Resourses/9.jpg", UriKind.Relative));
            bi[10] = new BitmapImage(new Uri("/Resourses/10.jpg", UriKind.Relative));
            bi[11] = new BitmapImage(new Uri("/Resourses/11.jpg", UriKind.Relative));
            bi[12] = new BitmapImage(new Uri("/Resourses/12..jpg", UriKind.Relative));
            bi[13] = new BitmapImage(new Uri("/Resourses/13.jpg", UriKind.Relative));
            bi[14] = new BitmapImage(new Uri("/Resourses/14.jpg", UriKind.Relative));
            bi[15] = new BitmapImage(new Uri("/Resourses/15.jpg", UriKind.Relative));
            
            gameBigin();
        }

        private void hard_Click(object sender, RoutedEventArgs e)
        {
            width = 256;
            height = 171;
            limit = 24;
            pointer = 5;
            bi[1] = new BitmapImage(new Uri("/Resourses/jVccW_79pMY_01.jpg", UriKind.Relative));
            bi[2] = new BitmapImage(new Uri("/Resourses/jVccW_79pMY_02.jpg", UriKind.Relative));
            bi[3] = new BitmapImage(new Uri("/Resourses/jVccW_79pMY_03.jpg", UriKind.Relative));
            bi[4] = new BitmapImage(new Uri("/Resourses/jVccW_79pMY_04.jpg", UriKind.Relative));
            bi[5] = new BitmapImage(new Uri("/Resourses/jVccW_79pMY_05.jpg", UriKind.Relative));
            bi[6] = new BitmapImage(new Uri("/Resourses/jVccW_79pMY_06.jpg", UriKind.Relative));
            bi[7] = new BitmapImage(new Uri("/Resourses/jVccW_79pMY_07.jpg", UriKind.Relative));
            bi[8] = new BitmapImage(new Uri("/Resourses/jVccW_79pMY_08.jpg", UriKind.Relative));
            bi[9] = new BitmapImage(new Uri("/Resourses/jVccW_79pMY_09.jpg", UriKind.Relative));
            bi[10] = new BitmapImage(new Uri("/Resourses/jVccW_79pMY_10.jpg", UriKind.Relative));
            bi[11] = new BitmapImage(new Uri("/Resourses/jVccW_79pMY_11.jpg", UriKind.Relative));
            bi[12] = new BitmapImage(new Uri("/Resourses/jVccW_79pMY_12.jpg", UriKind.Relative));
            bi[13] = new BitmapImage(new Uri("/Resourses/jVccW_79pMY_13.jpg", UriKind.Relative));
            bi[14] = new BitmapImage(new Uri("/Resourses/jVccW_79pMY_14.jpg", UriKind.Relative));
            bi[15] = new BitmapImage(new Uri("/Resourses/jVccW_79pMY_15.jpg", UriKind.Relative));
            bi[16] = new BitmapImage(new Uri("/Resourses/jVccW_79pMY_16.jpg", UriKind.Relative));
            bi[17] = new BitmapImage(new Uri("/Resourses/jVccW_79pMY_17.jpg", UriKind.Relative));
            bi[18] = new BitmapImage(new Uri("/Resourses/jVccW_79pMY_18.jpg", UriKind.Relative));
            bi[19] = new BitmapImage(new Uri("/Resourses/jVccW_79pMY_19.jpg", UriKind.Relative));
            bi[20] = new BitmapImage(new Uri("/Resourses/jVccW_79pMY_20.jpg", UriKind.Relative));
            bi[21] = new BitmapImage(new Uri("/Resourses/jVccW_79pMY_21.jpg", UriKind.Relative));
            bi[22] = new BitmapImage(new Uri("/Resourses/jVccW_79pMY_22.jpg", UriKind.Relative));
            bi[23] = new BitmapImage(new Uri("/Resourses/jVccW_79pMY_23.jpg", UriKind.Relative));
            bi[24] = new BitmapImage(new Uri("/Resourses/jVccW_79pMY_24.jpg", UriKind.Relative));
            
            gameBigin();
        }
    }
}
