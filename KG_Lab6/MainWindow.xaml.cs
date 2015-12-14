using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;

namespace KG_Lab6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //
        // Поля
        //
        // Количество отрезков
        // Список для хранения данных
        List<double[]> dataList = new List<double[]>();
        // Контейнер слоев рисунков
        DrawingGroup drawingGroup = new DrawingGroup();//послойное накопление geometrydrawing

        public MainWindow()
        {
            InitializeComponent();

            DataFill();// Заполнение списка данными
            Execute(); // Заполнение слоев

            // Отображение на экране
            image1.Source = new DrawingImage(drawingGroup);

        }

        // Генерация точек графиков
        void DataFill()
        {
            double[] p1 = new double[138]; //orig
          

            for (int i = 0; i < 138; i++)
            {
                double angle = -1.37 + (double)i * 0.02;
               

                p1[i] = Math.Tan(angle);

            }

            dataList.Add(p1);
          
        }

        // Послойное формирование рисунка в Z-последовательности
        void Execute()
        {
            BackgroundFun();    // Фон
            MyFun1();
            MyFun2();
           MyFun3();
            GridFun();        // Мелкая сетка
            MarkerFun();        // Надписи

        }

        // Фон
        private void BackgroundFun()
        {
            // Создаем объект для описания геометрической фигуры
            GeometryDrawing geometryDrawing = new GeometryDrawing();
            //описываем и сохраняем геометрию
            RectangleGeometry rectGeometry = new RectangleGeometry();
            rectGeometry.Rect = new Rect(-4, -5, 8, 10);
            geometryDrawing.Geometry = rectGeometry;

            // Настраиваем перо и кисть
            geometryDrawing.Pen = new Pen(Brushes.DarkViolet, 0.005);// Перо рамки
            geometryDrawing.Brush = Brushes.Black;// Кисть закраски

            // Добавляем готовый слой в контейнер отображения
            drawingGroup.Children.Add(geometryDrawing);
        }
        // Горизонтальная сетка
        private void GridFun()
        {
            // Создаем коллекцию для описания геометрических фигур
            GeometryGroup geometryGroup = new GeometryGroup();

            geometryGroup.Children.Add(new LineGeometry(new Point(0.0, -5.0), new Point(0.0, 5)));//верт.
            geometryGroup.Children.Add(new LineGeometry(new Point(-4, 0), new Point(4, 0)));//горизонтальная
            //верт стрелка
            geometryGroup.Children.Add(new LineGeometry(new Point(0, -5), new Point(-0.2, -4.6)));
            geometryGroup.Children.Add(new LineGeometry(new Point(0, -5), new Point(0.2, -4.6)));

            //гориз стрелка
            geometryGroup.Children.Add(new LineGeometry(new Point(4, 0), new Point(3.6, 0.2)));
            geometryGroup.Children.Add(new LineGeometry(new Point(4, 0), new Point(3.6, -0.2)));
            //штрихи
            for (int i = -3; i <= 3; i++)
            {
                geometryGroup.Children.Add(new LineGeometry(new Point(i, 0.1), new Point(i, -0.1)));//размер |
            }
            for (int i = -4; i <= 4; i++)
            {
                geometryGroup.Children.Add(new LineGeometry(new Point(-0.1, i), new Point(0.1, i)));
            }
            // Сохраняем описание геометрии
            GeometryDrawing geometryDrawing = new GeometryDrawing();
            geometryDrawing.Geometry = geometryGroup;

            // Настраиваем перо
            geometryDrawing.Pen = new Pen(Brushes.DarkViolet, 0.020);

            // Настраиваем кисть 
            //  geometryDrawing.Brush = Brushes.Chocolate;

            // Добавляем готовый слой в контейнер отображения
            drawingGroup.Children.Add(geometryDrawing);
        }
        //строим
        private void MyFun1()
        {

            GeometryGroup geometryGroup = new GeometryGroup();
            for (int i = 0; i < dataList[0].Length - 1; i++)
            {
                LineGeometry line = new LineGeometry
                    (
                    new Point(1.37 - (double)i * 0.02, dataList[0][i]),
                    new Point(1.37 - (double)(i + 1) * 0.02, dataList[0][i + 1])
                    );
                geometryGroup.Children.Add(line);
        }

            // Сохраняем описание геометрии
            GeometryDrawing geometryDrawing = new GeometryDrawing();
            geometryDrawing.Geometry = geometryGroup;

            // Настраиваем перо
            geometryDrawing.Pen = new Pen(Brushes.DarkViolet, 0.05);

            // Добавляем готовый слой в контейнер отображения
            drawingGroup.Children.Add(geometryDrawing);
        }

        private void MyFun2()
        {
            GeometryGroup geometryGroup = new GeometryGroup();
            for (int i = 0; i < 70 - 1; i++)
            {
                LineGeometry line2 = new LineGeometry
                                  (
                              new Point(-1.77 - (double)i * 0.02,
                 dataList[0][i]),
                  new Point(-1.77 - (double)(i + 1) * 0.02,
                  dataList[0][i + 1]));
            geometryGroup.Children.Add(line2);
            }

            // Сохраняем описание геометрии
            GeometryDrawing geometryDrawing = new GeometryDrawing();
            geometryDrawing.Geometry = geometryGroup;

            // Настраиваем перо
            geometryDrawing.Pen = new Pen(Brushes.DarkViolet, 0.05);

            // Добавляем готовый слой в контейнер отображения
            drawingGroup.Children.Add(geometryDrawing);

        }

        private void MyFun3()
        {

            GeometryGroup geometryGroup = new GeometryGroup();
            for (int i = 70; i < dataList[0].Length - 1; i++)
            {
                LineGeometry line3 = new LineGeometry
                                  (
                              new Point(4.51 - (double)i * 0.02,
                 dataList[0][i]),
                  new Point(4.51 - (double)(i + 1) * 0.02,
                  dataList[0][i + 1]));
                geometryGroup.Children.Add(line3);
            }

            // Сохраняем описание геометрии
            GeometryDrawing geometryDrawing = new GeometryDrawing();
            geometryDrawing.Geometry = geometryGroup;

            // Настраиваем перо
            geometryDrawing.Pen = new Pen(Brushes.DarkViolet, 0.05);

            // Добавляем готовый слой в контейнер отображения
            drawingGroup.Children.Add(geometryDrawing);
        }

        //  Надписи
        private void MarkerFun()
        {
            GeometryGroup geometryGroup = new GeometryGroup();
             for (int i = -3; i <= 3; i++)
             {
                 if (i != 0)
                 {
                     FormattedText formattedText = new FormattedText(
                                     String.Format("{0}", i), CultureInfo.InvariantCulture,
                                       FlowDirection.LeftToRight, new Typeface("Arial"), 0.4, Brushes.DarkViolet);

                     formattedText.SetFontWeight(FontWeights.Bold);

                     Geometry geometry = formattedText.BuildGeometry(new Point(i, 0));
                     geometryGroup.Children.Add(geometry);
                 }
        }
            for (int j = -4; j <= 4; j++)
             {
                 FormattedText formattedText = new FormattedText(
                      String.Format("{0}", -j), CultureInfo.InvariantCulture,
                      FlowDirection.LeftToRight, new Typeface("Arial"), 0.4, Brushes.Yellow);

                 formattedText.SetFontWeight(FontWeights.Bold);//ширина циферек меняется по вертикали

                 Geometry geometry = formattedText.BuildGeometry(new Point(-0.45, j - 0.4));
                 geometryGroup.Children.Add(geometry);
             }

            GeometryDrawing geometryDrawing = new GeometryDrawing();
            geometryDrawing.Geometry = geometryGroup;

            geometryDrawing.Brush = Brushes.LightGray;
            geometryDrawing.Pen = new Pen(Brushes.Green, 0.003);

            drawingGroup.Children.Add(geometryDrawing);
        }
    }
}