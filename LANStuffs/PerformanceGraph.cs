using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;

namespace LANStuffs
{
    public partial class PerformanceGraph : UserControl
    {
        int margin_x;
        int margin_text_x;
        int margin_y;
        int margin_text_y;
        int xylines_width;

        int max_x;
        int min_x;
        int max_y;
        int min_y;
        int current_value;
        int current_value_x;
        bool initialized = false;

        Graphics g;
        Pen yellow;

        Point pixel_xy;
        Point prev_pixel_xy;

        Point[] pixel_collection;
        public PerformanceGraph()
        {
            InitializeComponent();

            margin_x = 10;
            margin_text_x = 25;
            margin_y = 10;
            margin_text_y = 10;
            xylines_width = 1;

            CurrentValue = 0;
            CurrentValueX = 0;

            yellow = new Pen(Brushes.Yellow, 1);

            pixel_xy = new Point(this.Width - (margin_x), this.Height - (margin_y + margin_text_y));
            prev_pixel_xy = pixel_xy;
            
        }

        private void PerformanceGraph_Load(object sender, EventArgs e)
        {

            MaxX = this.Width - 2 * margin_x - margin_text_x;
            MinX = 0;
            MaxY = 100;
            MinY = 0;

            //initializePixelCollection();


            setPanelBounds();
            
            initializePixelCollection2();
        }

        private void setPanelBounds()
        { 
            panel1.Location = new Point(margin_x + margin_text_x, margin_y);
            panel1.Height = this.Height - 2 * margin_y - margin_text_y;
            panel1.Width = this.Width - 2 * margin_x - margin_text_x;
        }

        private void initializePixelCollection()
        {
            MaxX = this.Width - 2 * margin_x - margin_text_x;
            MinX = 0;

            int dx = MaxX - MinX;
            pixel_collection = new Point[dx / 5];
            int width = this.Width;
            int height = this.Height;
            for (int i = 0; i < pixel_collection.Length; i++)
            {
                pixel_collection[i] = new Point(width - (margin_x + i * 5), height - (margin_y + margin_text_y));
            }
        }

        private void initializePixelCollection2()
        {
            MaxX = this.panel1.Width;
            MinX = 0;

            int dx = MaxX - MinX;
            pixel_collection = new Point[dx / 5];
            int width = panel1.Width;
            int height = panel1.Height;
            for (int i = 0; i < pixel_collection.Length; i++)
            {
                pixel_collection[i] = new Point(width - i * 5, height - 1);
            }
        }

        private void PerformanceGraph_Paint(object sender, PaintEventArgs e)
        {

            g = e.Graphics;

            Pen p = new Pen(Color.Lime, xylines_width);

            Point initial_point1 = new Point(margin_x + margin_text_x, margin_y);
            Point end_point1 = new Point(margin_x + margin_text_x, this.Height - margin_y - margin_text_y);
            g.DrawLine(p, initial_point1, end_point1);

            Point initial_point2 = end_point1;
            Point end_point2 = new Point(this.Width - margin_x, initial_point2.Y);
            g.DrawLine(p, initial_point2, end_point2);

            drawHorizontalGridLines(g, 15);
            drawVerticalGridLines(g, 15);
            setText(g);
            initialized = true;
//            drawGraph(g);

        }

        private void drawHorizontalGridLines(Graphics graphics, int cell_width)
        {
            Pen p = new Pen(Brushes.Green);
            int grid_count_x = (this.Height - 2 * margin_y - margin_text_y) / cell_width;
            for (int i = 0; i < grid_count_x; i++)
            {
                Point initial_point = new Point(margin_x + margin_text_x - xylines_width, margin_y + i * cell_width);
                Point end_point = new Point(this.Width - margin_x, margin_y + i * cell_width);
                graphics.DrawLine(p, initial_point, end_point);
            }
        }

        private void drawVerticalGridLines(Graphics graphics, int cell_width)
        {
            Pen p = new Pen(Brushes.Green);
            int grid_count_y = (this.Width - 2 * margin_x - margin_text_x) / cell_width;
            for (int i = 1; i < grid_count_y + 1; i++)
            {
                Point initial_point = new Point(margin_x + margin_text_x + i * cell_width, margin_y);
                Point end_point = new Point(margin_x + margin_text_x + i * cell_width, this.Height - margin_y - margin_text_y - xylines_width);
                graphics.DrawLine(p, initial_point, end_point);
            }
        }
        public void drawPixel(Graphics graphics, int x, int y)
        {
            Point initial_point = new Point(x, y);
            Point end_point = new Point(x , y );
            graphics.DrawLine(yellow, initial_point, end_point);
        }

        private void joinPixels(Graphics graphics, Point pixel1, Point pixel2)
        {
            graphics.DrawLine(yellow, pixel1, pixel2);
        }

        int length = 3;
        public void setText(Graphics graphics)
        { 
            Point maxy_point = new Point(margin_x, margin_y);
            lbl_max_y.Text = MaxY.ToString();
            lbl_max_y.Location = maxy_point;

            Point miny_point = new Point(margin_x + (lbl_max_y.Width - lbl_min_y.Width), this.Height - margin_x - margin_text_y - Convert.ToInt32(Math.Round(lbl_min_y.Font.Size, 0)));
            lbl_min_y.Text = MinY.ToString();
            lbl_min_y.Location = miny_point;

            
            if (lbl_max_y.Text.Length > length)
            {
                margin_text_x += 10;
                length++;
                //initializePixelCollection();
                
                setPanelBounds();
                initializePixelCollection2();
                this.Refresh();
            }
        }

        private int MaxX
        {
            get
            {
                return max_x;
            }
            set
            {
                max_x = value;
            }
        }

        private int MinX
        {
            get
            {
                return min_x;
            }
            set
            {
                min_x = value;
            }
        }

        public int MaxY
        {
            get
            {
                return max_y;
            }
            set
            {
                max_y = value;
            }
        }

        public int MinY
        {
            get
            {
                return min_y;
            }
            set
            {
                min_y = value;
            }
        }

        public int CurrentValue
        {
            get
            {
                return current_value;
            }
            set
            {
                current_value = value;
            }
        }

        public int CurrentValueX
        {
            get
            {
                return current_value_x;
            }
            set
            {
                current_value_x = value;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            if (!initialized)
            {
                //this.Refresh();
            }
            this.panel1.Refresh();

            timer1.Start();
        }

        
        private void drawGraph(Graphics graphics)
        {
            int pixel_factor_y = this.Height - 2 * margin_y - margin_text_y;

            Point pixel_xy = new Point(this.Width - (margin_x), this.Height - (margin_y + margin_text_y + ((CurrentValue * pixel_factor_y) / MaxY)));

            pixel_collection[0].Y = pixel_xy.Y;
            for (int i = pixel_collection.Length - 1; i > 0 ; i--)
            {
                pixel_collection[i].Y = pixel_collection[i - 1].Y;
            }

            drawPixel(g, pixel_collection[0].X, pixel_collection[0].Y);
            for (int i = 1; i < pixel_collection.Length; i++)
            {
                drawPixel(g, pixel_collection[i].X, pixel_collection[i].Y);
                joinPixels(g, pixel_collection[i - 1], pixel_collection[i]);
            }
        }

        private void drawGraph2(Graphics graphics)
        {
            int pixel_factor_y = this.panel1.Height - 1;

            Point pixel_xy = new Point(this.panel1.Width, this.panel1.Height - ((CurrentValue * pixel_factor_y) / MaxY) - 1);

            pixel_collection[0].Y = pixel_xy.Y;
            for (int i = pixel_collection.Length - 1; i > 0; i--)
            {
                pixel_collection[i].Y = pixel_collection[i - 1].Y;
            }

            drawPixel(graphics, pixel_collection[0].X, pixel_collection[0].Y);
            for (int i = 1; i < pixel_collection.Length; i++)
            {
                drawPixel(graphics, pixel_collection[i].X, pixel_collection[i].Y);
                joinPixels(graphics, pixel_collection[i - 1], pixel_collection[i]);
            }
        }

        public void start()
        {
            timer1.Start();
        }
        public void stop()
        {
            timer1.Stop();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics p_graphics = e.Graphics;
            drawGraph2(p_graphics);
            
        }
    }
}
