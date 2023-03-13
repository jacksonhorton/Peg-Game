using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace PegTest
{
    public class Board : UIElement
    {
        private int numOfRows;
        private int numOfPegs;
        public Dictionary<PegPosition, Point> PegPoints;

        // Constructor
        public Board(int numOfRows, int numOfPegs, BoardWindow w1)
        {
            PegPoints = new Dictionary<PegPosition, Point>();
            PegPoints.Add(PegPosition.Peg0, new Point(260, 282));
            PegPoints.Add(PegPosition.Peg1, new Point(218, 214));
            PegPoints.Add(PegPosition.Peg2, new Point(299, 214));
            PegPoints.Add(PegPosition.Peg3, new Point(179, 146));
            PegPoints.Add(PegPosition.Peg4, new Point(258, 146));
            PegPoints.Add(PegPosition.Peg5, new Point(339, 146));
            PegPoints.Add(PegPosition.Peg6, new Point(141,79));
            PegPoints.Add(PegPosition.Peg7, new Point(219, 79));
            PegPoints.Add(PegPosition.Peg8, new Point(299, 79));
            PegPoints.Add(PegPosition.Peg9, new Point(380, 79));
            PegPoints.Add(PegPosition.Peg10, new Point(100, 12));
            PegPoints.Add(PegPosition.Peg11, new Point(179, 12));
            PegPoints.Add(PegPosition.Peg12, new Point(258, 12));
            PegPoints.Add(PegPosition.Peg13, new Point(339, 12));
            PegPoints.Add(PegPosition.Peg14, new Point(420, 12));



            List<Ellipse> renderedHoles = new List<Ellipse>();
            List<Hole> holes = new List<Hole>();
            this.numOfRows = numOfRows;
            this.numOfPegs = numOfPegs;


            for (int i=0; i<numOfPegs; i++)
            {
                Ellipse temp = new Ellipse();
                
                // gets the left and bottom margin from the dictionary
                // TODO: change the Point to a struct or something else to specifically store margin info
                Point p = PegPoints[(PegPosition)i];

                // fill in ellipse data, some is constant
                temp.Width = 47;
                temp.Height = 47;
                temp.Margin = new Thickness(p.X,0,0,p.Y);
                temp.HorizontalAlignment = HorizontalAlignment.Left;
                temp.VerticalAlignment= VerticalAlignment.Bottom;
                temp.Fill = Brushes.Orange;

                if ( (PegPosition)i == PegPosition.Peg4 )
                {
                    temp.Opacity = 0;    
                }

                w1.Game_Board_Grid.Children.Add(temp);
            }
        }

    }
}
