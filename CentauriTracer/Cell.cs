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
    class Cell
    {
        public int type=0 ; // 0 - свободная, 1 - начало, 2 - конец, 3 - запрещенная
        const int HEIGHT = 20; // размеры ячейки
        const int WIDTH = 20;
        public int px; // координаты точки начала ячейки
        public int py;
        public int distance; // данные о расстоянии от начальной точки


//конструктор
  public  Cell(Brush brsh, Graphics graphSirface, int x, int y)
               {
                  
                   graphSirface.FillRectangle(brsh, new Rectangle(x, y, HEIGHT, WIDTH));
                   graphSirface.DrawRectangle(SystemPens.ControlDark, new Rectangle(x, y, HEIGHT, WIDTH));
                   this.px = x;
                   this.py = y;
                    return;

              }

  public void MakeStartCell(Graphics graphSirface) // пометить ячейку начальной
  {
      this.type = 1;
      graphSirface.FillRectangle(new SolidBrush(Color.Red), new Rectangle (this.px, this.py, HEIGHT, WIDTH));

  }
  public void MakeEndCell(Graphics graphSirface) // пометить ячейку конечной
  {
      this.type = 2;
      graphSirface.FillRectangle(new SolidBrush(Color.Orange), new Rectangle(this.px, this.py, HEIGHT, WIDTH));

  }

  public void MakeRestrictedCell(Graphics graphSirface) // пометить ячейку запрещенной
  {
      this.type = 3;
      graphSirface.FillRectangle(new SolidBrush(Color.Black), new Rectangle(this.px, this.py, HEIGHT, WIDTH));

  }
  public void Repaint(Graphics graphSirface) //обновление изображения
  {
      Font font = new Font("Arial", 12);
      Brush brush = new SolidBrush(Color.Red);
      PointF drawPoint = new PointF(0, 0);
    
      switch (this.type)
      {
          case 0:
              graphSirface.FillRectangle(new SolidBrush(Color.White), new Rectangle(this.px, this.py, HEIGHT, WIDTH));
              break;

          case 1:
              graphSirface.FillRectangle(new SolidBrush(Color.Red), new Rectangle(this.px, this.py, HEIGHT, WIDTH));
              break;
          case 2:
              graphSirface.FillRectangle(new SolidBrush(Color.Orange), new Rectangle(this.px, this.py, HEIGHT, WIDTH));
              break;
          case 3:
              graphSirface.FillRectangle(new SolidBrush(Color.Black), new Rectangle(this.px, this.py, HEIGHT, WIDTH));
              break;

      }
      graphSirface.DrawRectangle(SystemPens.ControlDark, new Rectangle(this.px, this.py, HEIGHT, WIDTH));
      drawPoint.X = this.px;
      drawPoint.Y = this.py;
      graphSirface.DrawString(Convert.ToString(this.distance), font, brush, drawPoint);
  }
          }
}
