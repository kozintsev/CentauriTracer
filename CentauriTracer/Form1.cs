using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
     const int WORKSPACE_WIDTH = 15;    // константы, определяющие количество ячеек
     const int WORKSPACE_HEIGHT = 15;   // рабочего поля. С нулевой по 14-ю, всего 15
     Cell [,] cellSpaceArr = new Cell [WORKSPACE_WIDTH, WORKSPACE_HEIGHT];
     bool workSpaceredrawFlag = true;
     Cell startCell;                    // ввод начальной ячейки
     int startCellX;                    // координата X начальной ячейки
     int startCellY;                    // координата Y начальной ячейки
     Cell endCell;                      // ввод целевой ячейки
     int endCellX;
     int endCellY;
     restrictedCells[] restricted = new restrictedCells[WORKSPACE_WIDTH * WORKSPACE_HEIGHT / 20];// массив запрещенных ячеек
     
        public  struct restrictedCells //хранит координаты запрещенных ячеек
        {
           public int x, y;
      public restrictedCells(int p1, int p2)
           {
               x = p1;
               y = p2;
           }
        }
     
        private void Form1_Load(object sender, EventArgs e)
        {
          
           
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
         
               Graphics g = Graphics.FromHwnd(Handle); //объект рисования
            // Create font and brush.
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Red);
            PointF drawPoint = new PointF(10, 10);

            Brush whiteBrush = new SolidBrush(Color.White); // кисть для заливки ячейки 
            if (workSpaceredrawFlag)
            {
                // заполняем массив объектами Cell и рисуем рабочую область
                for (int i = 0; i <= cellSpaceArr.GetUpperBound(0); i++)
                {
                    for (int j = 0; j <= cellSpaceArr.GetUpperBound(1); j++)
                    {
                        cellSpaceArr[i, j] = new Cell(whiteBrush, g, 10 + 20 * i, 10 + 20 * j);

                    }
                }

            }
            else
            {
                for (int i = 0; i <= cellSpaceArr.GetUpperBound(0); i++)
                {
                    for (int j = 0; j <= cellSpaceArr.GetUpperBound(1); j++)
                    {
                        cellSpaceArr[i, j].Repaint(g);

                    }
                }

            }

      
        }
        private void Form_Resize(object sender, EventArgs e)
        { 
            Invalidate();
        }

        private void mkStartButt_Click(object sender, EventArgs e)
        {

            inputData();
        }

        private void inputData()
        {
            startCellX = 2;
            startCellY = 1;
            startCell = cellSpaceArr[startCellX, startCellY]; // ввод начальной ячейки

            endCellX = 14;
            endCellY = 13;
            endCell = cellSpaceArr[endCellX, endCellY]; // ввод целевой ячейки

            restrictedCells[] restricted = new restrictedCells[WORKSPACE_WIDTH * WORKSPACE_HEIGHT/20 + 4];// массив запрещенных ячеек

            workSpaceredrawFlag = false; // отключаем перерисовку всей рабочей области
            Graphics g = Graphics.FromHwnd(Handle);
            //заполняем массив запрещенных ячеек их координатами и помечаем их
            for (int i = 0; i <= restricted.GetUpperBound(0); i++)
            {
                restricted[i] = new restrictedCells(WORKSPACE_WIDTH/2, i);
                cellSpaceArr[restricted[i].x, restricted[i].y].MakeRestrictedCell(g);
                
            }
            // помечаем начальную и конечную точки
            startCell.MakeStartCell(g);
            endCell.MakeEndCell(g);
        }

        private void FrontWaveButt_Click(object sender, EventArgs e)
        {
            frontWave(startCellX, startCellY, endCellX, endCellY);
        }

        private bool frontWave(int startX, int startY, int endX, int endY)
        {
            int[] dx = new int[4] {1, 0, -1, 0}; // смещения, соответствующие соседям ячейки
            int[] dy = new int[4] {0, 1, 0, -1}; // справа, снизу, слева и сверху
            int q, x,y,k;
            bool stop; //конец достигнут
            bool deadEnd; // алгоритм волна уперлась в тупик
            Graphics g = Graphics.FromHwnd(Handle);
            Font font = new Font("Arial", 12);
            Brush brush = new SolidBrush(Color.Red);
            PointF drawPoint = new PointF(0,0);

         q = 1; // счетчик итераций распространения волны

         cellSpaceArr[startX, startY].distance = 0;

         do
         {
            stop = false;
            deadEnd = false;
             if (q == 1) // первый гребень волны
             {
                 for (k = 0; k <= dx.GetUpperBound(0); k++)
                 {
                     cellSpaceArr[startX + dx[k], startY + dy[k]].distance = q;
                     
                     
                 }
                 q++;

             }
             for (x=0; x<= cellSpaceArr.GetUpperBound (0); x++) // следующие гребни
             {
                 if (stop == true) { break; }
                 for (y = 0; y <= cellSpaceArr.GetUpperBound(1); y++)
                 {
                     if (stop == true) { break; }
                     if (cellSpaceArr[x, y].distance == q-1) // если найдена ячейка, в которую уже дошла волна
                     {
                         for (k = 0; k <= dx.GetUpperBound(0); k++) // пройти соседние и пустить в них волну
                         {
                             int ix = x + dx[k];
                             int iy = y + dy[k];
                             if (ix >=0 && ix <= cellSpaceArr.GetUpperBound(0) &&
                                 iy >= 0 && iy <= cellSpaceArr.GetUpperBound(1) &&
                                 (cellSpaceArr[ix, iy].type != 3 & cellSpaceArr[ix, iy].type != 1) &&
                                 cellSpaceArr[ix, iy].distance == 0)
                             {
                                 cellSpaceArr[ix, iy].distance = q;
                                 PointF point = new PointF(cellSpaceArr[ix, iy].px, cellSpaceArr[ix, iy].py);
                                 g.DrawString(Convert.ToString(cellSpaceArr[ix, iy].distance), font, brush, point);
                                 stop = false;
                                 if (ix == endX && iy == endY)
                                 {
                                     stop = true;
                                     break;
                                 }
                             } 
                         }
                     }  
                    
                 }

             }
             if (stop == true) { break; }
         
         
             q++;   // увеличение счетчика и после этого запуск следующей итерации распространения
         
         }
         while (!stop);
         if (cellSpaceArr[endX, endY].distance == 0)
         { return false; }
         else { return true; }
        }
    }
     
}
