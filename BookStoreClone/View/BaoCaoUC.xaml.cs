using BookStoreClone.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace BookStoreClone.View
{
    /// <summary>
    /// Interaction logic for BaoCaoUC.xaml
    /// </summary>
    /// 

    public partial class BaoCaoUC : UserControl
    {
        public struct sachs
        {
            public string tensach { get; set; }
            public int soluongban { get; set; }
            public int soluongnhap { get; set; }
        }
        private ObservableCollection<CTHD> _listCTHD;
        private ObservableCollection<Sach> sach;

        private ObservableCollection<HoaDon> _listHD;
        private ObservableCollection<PhieuThuTien> _listPTT;
        private ObservableCollection<CTPhieuNhap> _listCTPN;
        private ObservableCollection<CTBaoCaoCongNo> _listCTBaoCaoCongNo;
        private ObservableCollection<CTBaoCaoTon> _listCTBaoCaoTon;
        private List<Category> Categories { get; set; }
        private List<sachs> n { get; set; }

        public BaoCaoUC()
        {
            InitializeComponent();
            //change();
            //void change()
            float pieWidth = 200, pieHeight = 200, centerX = pieWidth / 2, centerY = pieHeight / 2, radius = pieWidth / 2;
            mainCanvas.Width = pieWidth;
            mainCanvas.Height = pieHeight;
          
            Categories = new List<Category>()
            {
                #region test #1
                //new Category
                //{
                //    Title = "Category#01",
                //    Percentage = 10,
                //    ColorBrush = Brushes.Gold,
                //},

                //new Category
                //{
                //    Title = "Category#02",
                //    Percentage = 30,
                //    ColorBrush = Brushes.Pink,
                //},

                //new Category
                //{
                //    Title = "Category#03",
                //    Percentage = 60,
                //    ColorBrush = Brushes.CadetBlue,
                //}, 
                #endregion

                #region test #2
                //new Category
                //{
                //    Title = "Category#01",
                //    Percentage = 20,
                //    ColorBrush = Brushes.Gold,
                //},

                //new Category
                //{
                //    Title = "Category#02",
                //    Percentage = 80,
                //    ColorBrush = Brushes.LightBlue,
                //}, 
                #endregion

                #region test #3
                //new Category
                //{
                //    Title = "Category#01",
                //    Percentage = 50,
                //    ColorBrush = Brushes.Gold,
                //},

                //new Category
                //{
                //    Title = "Category#02",
                //    Percentage = 50,
                //    ColorBrush = Brushes.LightBlue,
                //}, 
                #endregion

                #region test #4
                //new Category
                //{
                //    Title = "Category#01",
                //    Percentage = 30,
                //    ColorBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4472C4")),
                //},

                //new Category
                //{
                //    Title = "Category#02",
                //    Percentage = 30,
                //    ColorBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ED7D31")),
                //},

                //new Category
                //{
                //    Title = "Category#03",
                //    Percentage = 20,
                //    ColorBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC000")),
                //},

                //new Category
                //{
                //    Title = "Category#04",
                //    Percentage = 20,
                //    ColorBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5B9BD5")),
                //},

                //new Category
                //{
                //    Title = "Category#05",
                //    Percentage = 10,
                //    ColorBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#A5A5A5")),
                //}, 
                #endregion

                #region test #5
                //new Category
                //{
                //    Title = "Category#01",
                //    Percentage = 20,
                //    ColorBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4472C4")),
                //},

                //new Category
                //{
                //    Title = "Category#02",
                //    Percentage = 30,
                //    ColorBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ED7D31")),
                //},

                //new Category
                //{
                //    Title = "Category#03",
                //    Percentage = 20,
                //    ColorBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC000")),
                //},

                //new Category
                //{
                //    Title = "Category#04",
                //    Percentage = 20,
                //    ColorBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5B9BD5")),
                //},

                //new Category
                //{
                //    Title = "Category#05",
                //    Percentage = 10,
                //    ColorBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#A5A5A5")),
                //}, 
                #endregion

                #region test #6
                
                new Category
                {
                    Title = "Category#01",
					Percentage = 20,
                    ColorBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4472C4")),
                },

                new Category
                {
                    Title = "Category#02",
                    Percentage = 60,
                    ColorBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ED7D31")),
                },

                new Category
                {
                    Title = "Category#03",
                    Percentage = 5,
                    ColorBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC000")),
                },

                new Category
                {
                    Title = "Category#04",
                    Percentage = 10,
                    ColorBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5B9BD5")),
                },

                new Category
                {
                    Title = "Category#05",
                    Percentage = 5,
                    ColorBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#A5A5A5")),
                }, 
                #endregion
            };

            detailsItemsControl.ItemsSource = Categories;

            // draw pie
            float angle = 0, prevAngle = 0;
            foreach (var category in Categories)
            {
                double line1X = (radius * Math.Cos(angle * Math.PI / 180)) + centerX;
                double line1Y = (radius * Math.Sin(angle * Math.PI / 180)) + centerY;

                angle = category.Percentage * (float)360 / 100 + prevAngle;
                Debug.WriteLine(angle);

                double arcX = (radius * Math.Cos(angle * Math.PI / 180)) + centerX;
                double arcY = (radius * Math.Sin(angle * Math.PI / 180)) + centerY;

                var line1Segment = new LineSegment(new Point(line1X, line1Y), false);
                double arcWidth = radius, arcHeight = radius;
                bool isLargeArc = category.Percentage > 50;
                var arcSegment = new ArcSegment()
                {
                    Size = new Size(arcWidth, arcHeight),
                    Point = new Point(arcX, arcY),
                    SweepDirection = SweepDirection.Clockwise,
                    IsLargeArc = isLargeArc,
                };
                var line2Segment = new LineSegment(new Point(centerX, centerY), false);

                var pathFigure = new PathFigure(
                    new Point(centerX, centerY),
                    new List<PathSegment>()
                    {
                        line1Segment,
                        arcSegment,
                        line2Segment,
                    },
                    true);

                var pathFigures = new List<PathFigure>() { pathFigure, };
                var pathGeometry = new PathGeometry(pathFigures);
                var path = new Path()
                {
                    Fill = category.ColorBrush,
                    Data = pathGeometry,
                };
                mainCanvas.Children.Add(path);

                prevAngle = angle;


                // draw outlines
                var outline1 = new Line()
                {
                    X1 = centerX,
                    Y1 = centerY,
                    X2 = line1Segment.Point.X,
                    Y2 = line1Segment.Point.Y,
                    Stroke = Brushes.White,
                    StrokeThickness = 5,
                };
                var outline2 = new Line()
                {
                    X1 = centerX,
                    Y1 = centerY,
                    X2 = arcSegment.Point.X,
                    Y2 = arcSegment.Point.Y,
                    Stroke = Brushes.White,
                    StrokeThickness = 5,
                };

                mainCanvas.Children.Add(outline1);
                mainCanvas.Children.Add(outline2);
            }
        }
    
        private void Button_xuat_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(pnlpnl, "Báo Cáo");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }

        }

        private void ComboBox_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        int sachnhap;
        sachs b;
        int q;

        private void Button_Click(object sender, RoutedEventArgs e)
		{
			_listCTHD = new ObservableCollection<CTHD>(DataProvider.Ins.DB.CTHDs.Where(x => x.HoaDon.NgayBan.Value.Month == int.Parse(Thang.SelectedItem.ToString()) && x.HoaDon.NgayBan.Value.Year == int.Parse(Nam.Text.ToString())));
            //a1 = new sachs() { tensach = 0; };
            n = new List<sachs>();
			 b=new sachs();
            foreach (CTHD a in _listCTHD)
			{
                bool k=false;
                for(int i=0;i<n.Count();i++) /*( var s in n)*/
                { 
                    if (a.Sach.TenSach == n[i].tensach)
                    {
                        k = true;
      //                  n[i].soluongban += (int)a.SoLuong;
						//n[i].soluongban += (int)a.SoLuong;
                    }
                    
                }
                //n[q].soluongban+= (int)a.SoLuong;
                sachnhap += (int)a.SoLuong;
			}
		}
    }
	public class Category
    {
        public float Percentage { get; set; }
        public string Title { get; set; }
        public Brush ColorBrush { get; set; }
    }
    
}


