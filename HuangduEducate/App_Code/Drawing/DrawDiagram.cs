
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DrawWithCSharp
{
    static public class QYDPens
    {
        static public Pen redPen = new Pen(Color.Red);//红笔
        static public Pen grayPen = new Pen(Color.Gray);//灰笔
        static public Pen orangePen = new Pen(Color.Orange);
        static public Pen bluePen = new Pen(Color.Blue);
        static public Pen blackPen = new Pen(Color.Black);
        static public Brush orangeBrush = new Pen(Color.Orange).Brush;
        static public Brush blackBrush = new Pen(Color.Black).Brush;
    }
    
    public class DrawDiagramInt
    {

        static public int partDraw = 0;
        static public int allDraw = 0;
        static public Rectangle RectZero = new Rectangle(0, 0, 0, 0);
        static public Rectangle RectMinus = new Rectangle(-1, -1, -1, -1);
        //图形属性型数据
        //初始化之后基本不变的数据
        private int[] originalData;//原始数据
        private int[] YofEachPoint;//数据转换后的Y值
        private Rectangle drawingRegion;//绘图范围
        private Point[] currentPointSet;//当前点集
        private int edgeL, edgeR,zeroLinePosition;//左边界，右边界 零点线位置
        private int valueRange;//值域
        //实时刷新的数据
        private int zoomNum;
        private Point perviousMousePoistion;//上一次刷新时鼠标的点
        private double skip;//两点间横向距离
        //画笔，每个实体初始化一组画笔太占用空间，静态变量吧
        

        public DrawDiagramInt(int[] inputData, Rectangle inputRect,Point currentMousePosition)
        {
            //rect 为初始的画板大小，整个类的以后均会在此区域内作图。
            //inputData为输入的数据，此类根据加载的数据自动调整坐标轴。
            
            drawingRegion = inputRect;
            int maxInData = inputData.Max();
            int minInData = inputData.Min();
            valueRange= maxInData - minInData;
            zoomNum = 1;

            this.perviousMousePoistion = currentMousePosition; 
            if (maxInData * minInData < 0)
            {
                zeroLinePosition = inputRect.Bottom + inputRect.Height * minInData / valueRange;
                //初始化零刻度线位置
            }
            else 
            {
                zeroLinePosition = -65536;
                //初始化零刻度线位置
            }
            originalData = new int[inputData.Length];
            currentPointSet = new Point[inputData.Length];
            YofEachPoint = new int[inputData.Length];

            skip = ((double)inputRect.Width) / (inputData.Length-1);
            for (int i = 0; i < originalData.Length; i++)
            {
                originalData[i]=inputData[i];
                //复制数据
                YofEachPoint[i]=inputRect.Bottom-inputRect.Height*( originalData[i]-minInData )/(valueRange==0?2:valueRange);
                //确定每一个点的y值（像素）
                currentPointSet[i] = new Point((int)(i * skip + inputRect.Left), YofEachPoint[i]);
                //生成当前每一个点
            }
            edgeL = 0;
            edgeR = inputData.Length;
            
            
        }

        public KeyValuePair<int,string> Refesh(Point mousePosition,Graphics g,bool redrawAll)
        {
            //鼠标横坐标位移量在作图区域扫过的区域
            Rectangle mouseScanRang = new Rectangle((int)(Math.Min(perviousMousePoistion.X, mousePosition.X) - (2 * skip)-1), drawingRegion.Top,
                Math.Max(perviousMousePoistion.X, mousePosition.X) - Math.Min(perviousMousePoistion.X, mousePosition.X) + (int)(4 * skip)+2,
                drawingRegion.Height);
            Rectangle drawingRegionForThisTime = Rectangle.Intersect(mouseScanRang, this.drawingRegion);//为了避免左右出界而与原画区去了并集
            //Console.WriteLine(drawingRegionForThisTime.ToString());
            if (redrawAll)
            {
                drawPointsAndZeroLine(g, RectMinus);
            }
            else 
            {
                drawPointsAndZeroLine(g, drawingRegionForThisTime);
            }

            int Xpoistion = (int)Math.Round((double)(mousePosition.X - drawingRegion.Left+0.5*skip)/ this.skip  + edgeL,4,MidpointRounding.ToEven);
            if (Xpoistion >=edgeL && Xpoistion < edgeR)
            {
                string strToShow = originalData [Xpoistion].ToString();
                g.DrawLine(QYDPens.orangePen, currentPointSet[Xpoistion - edgeL].X, drawingRegion.Top, currentPointSet[Xpoistion - edgeL].X, drawingRegion.Bottom);//画竖线  
                
            }
            this.perviousMousePoistion = mousePosition;//！！！！刷新过去鼠标位置，此举之后不允许对过去鼠标位置再次访问
            //关于返回值的说明
            //返回点X是所画竖线的坐标
            //返回点Y是此数据的值
            //Console.WriteLine("left" + edgeL.ToString() + "|right:" + edgeR.ToString() + "|X:" + Xpoistion.ToString() + "," + currentPointSet[Xpoistion - edgeL].ToString());
            return new KeyValuePair<int, string>(Xpoistion < edgeR && Xpoistion >= edgeL ? currentPointSet[Xpoistion - edgeL].X : int.MaxValue
                , (Xpoistion < edgeR && Xpoistion >= edgeL ? originalData[Xpoistion] : int.MinValue).ToString());
        }

        public double zoomIn(Point mousePosition,Graphics g)
        {
            Console.WriteLine("zoom in");
            if (skip * 4 >= this.drawingRegion.Width)
            {
                return double.MinValue;
            }
            ++zoomNum;
            int Xpoistion = (int)Math.Round((double)(mousePosition.X - drawingRegion.Left + 0.5 * skip) / this.skip + edgeL, 4, MidpointRounding.ToEven);
            //左边界越界
            if (((int)(Xpoistion - originalData.Length / Math.Pow(2, zoomNum)))<0)
            {
                Console.WriteLine("low edge");
                this.edgeL = 0;
                this.edgeR = (int)(originalData.Length / Math.Pow(2, zoomNum - 1));
            }
            else if (((int)(Xpoistion + originalData.Length / Math.Pow(2, zoomNum))) > originalData.Length)
            {
                Console.WriteLine("high edge");
                this.edgeL = this.originalData.Length - (int)(originalData.Length / Math.Pow(2, zoomNum - 1)); ;
                this.edgeR = this.originalData.Length;
            }
            else
            {
                edgeL = (int)(Xpoistion - originalData.Length / Math.Pow(2, zoomNum));
                edgeR = (int)(Xpoistion + originalData.Length / Math.Pow(2, zoomNum));
            }
            int numOfCurrentPoints=edgeR - edgeL;
            currentPointSet = new Point[numOfCurrentPoints];
            this.skip=((double)this.drawingRegion.Width)/(numOfCurrentPoints-1);
            for (int i = 0; i < numOfCurrentPoints; i++)
            {
                currentPointSet[i] = new Point((int)(i * skip)+this.drawingRegion.Left, YofEachPoint[i + edgeL]);

            }
            this.Refesh(mousePosition, g, true);
            return double.NaN;
        }

        public double zoomOut(Point mousePosition, Graphics g)
        {
            if (zoomNum <= 1)
            {
                zoomNum = 1;
                return double.NaN;
            }
            --zoomNum;
            --zoomNum;
            double res=zoomIn(mousePosition, g);
            if (res == double.MinValue)
            {
                this.skip = 1;
            }
            return double.NaN;
        }

        public int moveLeft(Point mousePosition, Graphics g)
        {
            if (edgeL <= 0) 
            {
                return -1;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public int Right(Point mousePosition, Graphics g)
        {
            if (edgeL >= this.originalData.Length)
            {
                return -1;
            }
            else
            {
                throw new NotImplementedException();
            }
        }


        private void drawPointsAndZeroLine(Graphics grph,Rectangle drawingRegionForThisTime)
        {
            Console.WriteLine(drawingRegionForThisTime == RectMinus);
            if (drawingRegionForThisTime==RectMinus)
            {
                grph.SetClip(this.drawingRegion);
                
            }
            else if (drawingRegionForThisTime == RectZero)
            {
                return;
            }
            else
            {
                grph.SetClip(drawingRegionForThisTime);
                ++partDraw;
            }
            //设定初始化的范围
            grph.Clear(Color.White);//清屏
            grph.DrawLine(QYDPens.grayPen, drawingRegion.Left, zeroLinePosition, drawingRegion.Right, zeroLinePosition);//画零线
            grph.DrawLines(QYDPens.redPen, currentPointSet);//画折线
        }

    }

    public class DrawDiagramFloat
    {

        static public int partDraw = 0;
        static public int allDraw = 0;
        static public Rectangle RectZero = new Rectangle(0, 0, 0, 0);
        static public Rectangle RectMinus = new Rectangle(-1, -1, -1, -1);
        //图形属性型数据
        //初始化之后基本不变的数据
        private float[] originalData;//原始数据
        private float[] subData;//另一个与值域有关的数据
        private int[] YofEachPoint;//数据转换后的Y值
        private Rectangle drawingRegion;//绘图范围
        private Point[] currentPointSet;//当前点集
        private int edgeL, edgeR, zeroLinePosition;//左边界，右边界 零点线位置
        private float valueRange;//值域
        //实时刷新的数据
        private int zoomNum;
        private Point perviousMousePoistion;//上一次刷新时鼠标的点
        private double skip;//两点间横向距离

        private double threshold;//阈值
        private double subThreshold;//第二阈值
        private bool subDataEnable;
        public double SubThreshold
        {
            get { return subThreshold; }
            set { subThreshold = value; }
        }

        public double Threshold
        {
            get { return threshold; }
            set { threshold = value; }
        }
        //画笔，每个实体初始化一组画笔太占用空间，静态变量吧


        public DrawDiagramFloat(float[] inputData, Rectangle inputRect, Point currentMousePosition)
        {
            //rect 为初始的画板大小，整个类的以后均会在此区域内作图。
            //inputData为输入的数据，此类根据加载的数据自动调整坐标轴。

            drawingRegion = inputRect;
            float maxInData = inputData.Max();
            float minInData = inputData.Min();
            valueRange = maxInData - minInData;
            zoomNum = 1;

            subData = null;
            subDataEnable = false;

            this.perviousMousePoistion = currentMousePosition;
            if (maxInData * minInData < 0)
            {
                zeroLinePosition = (int)(inputRect.Bottom + inputRect.Height * minInData / valueRange);
                //初始化零刻度线位置
            }
            else
            {
                zeroLinePosition = -65536;
                //初始化零刻度线位置
            }
            originalData = new float[inputData.Length];
            currentPointSet = new Point[inputData.Length];
            YofEachPoint = new int[inputData.Length];

            skip = ((double)inputRect.Width-1) / (inputData.Length-1);
            for (int i = 0; i < originalData.Length; i++)
            {
                originalData[i] = inputData[i];
                //复制数据
                if (valueRange != 0)
                {
                    YofEachPoint[i] = (int)(inputRect.Bottom - inputRect.Height * (originalData[i] - minInData) / valueRange);
                }
                else
                {
                    YofEachPoint[i] = (int)(inputRect.Bottom - inputRect.Height / 2);
                }
                //确定每一个点的y值（像素）
                currentPointSet[i] = new Point((int)(i * skip + inputRect.Left), YofEachPoint[i]);
                //生成当前每一个点
            }
            edgeL = 0;
            edgeR = inputData.Length;
            threshold = double.MaxValue;
            subThreshold = double.MaxValue;

        }

        public bool setSubData(float[] iptSubData)
        {
            if (iptSubData.Length == originalData.Length)
            {
                this.subData = new float[originalData.Length];
                for (int ic = 0; ic < originalData.Length; ic++)
                {
                    subData[ic] = iptSubData[ic];
                }
                this.subDataEnable = true;
            }
            else 
            {
                return false;
            }
            return true;
        }

        public KeyValuePair<int,string> Refesh(Point mousePosition, Graphics g, bool redrawAll)
        {
            //鼠标横坐标位移量在作图区域扫过的区域
            Rectangle mouseScanRang = new Rectangle((int)(Math.Min(perviousMousePoistion.X, mousePosition.X) - (2 * skip)), drawingRegion.Top,
                Math.Max(perviousMousePoistion.X, mousePosition.X) - Math.Min(perviousMousePoistion.X, mousePosition.X) + (int)(4 * skip+3),
                drawingRegion.Height);
            Rectangle drawingRegionForThisTime = Rectangle.Intersect(mouseScanRang, this.drawingRegion);//为了避免左右出界而与原画区去了并集
            //Console.WriteLine(drawingRegionForThisTime.ToString());
            if (redrawAll)
            {
                drawPointsAndZeroLine(g, RectMinus);
            }
            else
            {
                drawPointsAndZeroLine(g, drawingRegionForThisTime);
            }

            int Xpoistion = (int)Math.Round((double)(mousePosition.X - drawingRegion.Left + 0.5 * skip) / this.skip + edgeL, 4, MidpointRounding.ToEven);
            if (Xpoistion >= edgeL && Xpoistion < edgeR)
            {
                string strToShow = originalData[Xpoistion].ToString();
                g.DrawLine(QYDPens.orangePen, currentPointSet[Xpoistion - edgeL].X, drawingRegion.Top, currentPointSet[Xpoistion - edgeL].X, drawingRegion.Bottom);//画竖线  

            }
            this.perviousMousePoistion = mousePosition;//！！！！刷新过去鼠标位置，此举之后不允许对过去鼠标位置再次访问
            //关于返回值的说明
            //返回点X是所画竖线的坐标
            //返回点Y是此数据的值
            //Console.WriteLine("left" + edgeL.ToString() + "|right:" + edgeR.ToString() + "|X:" + Xpoistion.ToString() + "," + currentPointSet[Xpoistion - edgeL].ToString());
            return new KeyValuePair<int,string>(Xpoistion < edgeR && Xpoistion >= edgeL ? Xpoistion : -1
                , (Xpoistion < edgeR && Xpoistion >= edgeL ? originalData[Xpoistion] : float.NaN ).ToString());
        }

        public KeyValuePair<int, string> zoomIn(Point mousePosition, Graphics g)
        {
            if (skip * 4 >= this.drawingRegion.Width)
            {
                return new KeyValuePair<int,string>(-2,"");
            }
            ++zoomNum;
            int Xpoistion = (int)Math.Round((double)(mousePosition.X - drawingRegion.Left + 0.5 * skip) / this.skip + edgeL, 4, MidpointRounding.ToEven);
            //左边界越界
            if (((int)(Xpoistion - originalData.Length / Math.Pow(2, zoomNum))) < 0)
            {
                Console.WriteLine("low edge");
                this.edgeL = 0;
                this.edgeR = (int)(originalData.Length / Math.Pow(2, zoomNum - 1));
            }
            else if (((int)(Xpoistion + originalData.Length / Math.Pow(2, zoomNum))) > originalData.Length)
            {
                Console.WriteLine("high edge");
                this.edgeL = this.originalData.Length - (int)(originalData.Length / Math.Pow(2, zoomNum - 1)); ;
                this.edgeR = this.originalData.Length;
            }
            else
            {
                edgeL = (int)(Xpoistion - originalData.Length / Math.Pow(2, zoomNum));
                edgeR = (int)(Xpoistion + originalData.Length / Math.Pow(2, zoomNum));
            }
            int numOfCurrentPoints = edgeR - edgeL;
            currentPointSet = new Point[numOfCurrentPoints];
            this.skip = ((double)this.drawingRegion.Width) / (numOfCurrentPoints-1);
            for (int i = 0; i < numOfCurrentPoints; i++)
            {
                currentPointSet[i] = new Point((int)(i * skip) + this.drawingRegion.Left, YofEachPoint[i + edgeL]);

            }
            return this.Refesh(mousePosition, g, true);
            
        }

        public KeyValuePair<int, string> zoomOut(Point mousePosition, Graphics g)
        {
            if (zoomNum <= 1)
            {
                zoomNum = 1;
                return new KeyValuePair<int,string>(-1,"");
            }
            --zoomNum;
            --zoomNum;
            KeyValuePair<int, string> res = zoomIn(mousePosition, g);
            if (res.Key == -2)
            {
                this.skip = 1;
            }
            return res;
        }

        public KeyValuePair<int, string> moveLeft(Point mousePosition, Graphics g)
        {
            Console.WriteLine(this.edgeL + ":" + this.edgeR);
            if (edgeL <= 0)
            {
                return new KeyValuePair<int, string>(-1, "");
            }
            else
            {
                --this.edgeL;
                --this.edgeR;
                
                for (int i = 0; i < edgeR - edgeL; i++)
                {
                    this.currentPointSet[i] = new Point(this.currentPointSet[i].X, this.YofEachPoint[i + this.edgeL]);
                }
          
            }
            return this.Refesh(mousePosition, g, true);
            
        }

        public KeyValuePair<int, string> moveRight(Point mousePosition, Graphics g)
        {
            if (edgeR >= this.originalData.Length)
            {
                return new KeyValuePair<int,string>(-1,"");
            }
            else
            {
                ++this.edgeL;
                ++this.edgeR;

                for (int i = 0; i < edgeR - edgeL; i++)
                {
                    this.currentPointSet[i] = new Point(this.currentPointSet[i].X, this.YofEachPoint[i + this.edgeL]);
                }

            }
            return this.Refesh(mousePosition, g, true);
            
        }


        private void drawPointsAndZeroLine(Graphics grph, Rectangle drawingRegionForThisTime)
        {
            //Console.WriteLine(drawingRegionForThisTime == RectMinus);
            //Console.WriteLine(drawingRegionForThisTime.ToString());
            if (drawingRegionForThisTime == RectMinus)
            {
                grph.SetClip(this.drawingRegion);

            }
            else if (drawingRegionForThisTime == RectZero)
            {
                return;
            }
            else
            {
                grph.SetClip(drawingRegionForThisTime);
                ++partDraw;
            }//设定初始化的范围
            if (drawingRegionForThisTime.Width == 0 && drawingRegionForThisTime.Height == 0)
            {
                return;
            }
            grph.Clear(Color.White);//清屏
            if (zeroLinePosition > 0)
            {
                grph.DrawLine(QYDPens.grayPen, drawingRegion.Left, zeroLinePosition, drawingRegion.Right, zeroLinePosition);//画零线
            }
            for(int icounter=0;icounter<this.edgeR-this.edgeL;icounter++)
            {
                if (subDataEnable)
                {
                    if (Math.Abs(subData[edgeL + icounter]) > this.subThreshold)
                    {
                        grph.DrawLine(QYDPens.orangePen, currentPointSet[icounter].X, this.drawingRegion.Top,
                            currentPointSet[icounter].X, this.drawingRegion.Bottom);
                    }   
                }
                if(Math.Abs( originalData[edgeL+icounter])>this.threshold)
                {
                    grph.DrawLine(QYDPens.redPen,currentPointSet[icounter].X,this.drawingRegion.Top,
                        currentPointSet[icounter].X,this.drawingRegion.Bottom);
                }
            }
            
            grph.DrawLines(QYDPens.bluePen, currentPointSet);//画折线
        }

    }
}
