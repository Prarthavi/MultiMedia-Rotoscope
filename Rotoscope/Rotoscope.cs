using NAudio.Dmo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Rotoscope
{
    public class Rotoscope
    {
        public Rotoscope()
        {
        }
        private List<LinkedList<Point>> draw = new List<LinkedList<Point>>();
        private List<LinkedList<Line>> line = new List<LinkedList<Line>>();
        private List<LinkedList<Dictionary<Point,String>>> images = new List<LinkedList<Dictionary<Point, String>>>();
        public LinkedList<Point> GetFromDrawList(int frame)
        {
            if (frame < 0 || draw.Count == 0 || draw.Count <= frame)
                return null;

            //copy the list to ensure it is not overwritten
            return draw[frame];
        }

        public LinkedList<Line> GetFromLineList(int frame)
        {
            if (frame < 0 || line.Count == 0 || line.Count <= frame)
                return null;

            //copy the list to ensure it is not overwritten
            return line[frame];
        }

        public LinkedList<Dictionary<Point,string>> GetFromImageList(int frame)
        {
            if (frame < 0 || images.Count == 0 || images.Count <= frame)
                return null;

            //copy the list to ensure it is not overwritten
            return images[frame];
        }

        public void AddToDrawList(int frame, Point p)
        {
            //if the frame doesn't exists yet, add it
            while (draw.Count < frame + 1)
                draw.Add(new LinkedList<Point>());

            // Add the mouse point to the list for the frame
            draw[frame].AddLast(p);
        }

        public void AddToImageList(int frame, Point i, string type)
        {
            //if the frame doesn't exists yet, add it
            while (images.Count < frame + 1)
                images.Add(new LinkedList<Dictionary<Point,string>>());
            Dictionary<Point, string> temp = new Dictionary<Point, string>();
            temp.Add(i,type);
            // Add the mouse point to the list for the frame
            images[frame].AddLast(temp);
        }
        private void AddToLineList(int frame, Line l)
        {
            //if the frame doesn't exists yet, add it
            while (line.Count < frame + 1)
                line.Add(new LinkedList<Line>());

            // Add the mouse point to the list for the frame
            line[frame].AddLast(l);
        }
        public void OnSaveRotoscope(XmlDocument doc, XmlNode node)
        {
            for (int frame = 0; frame < draw.Count; frame++)
            {
                // Create an XML node for the frame
                XmlElement element = doc.CreateElement("frame");
                element.SetAttribute("num", frame.ToString());

                node.AppendChild(element);

                //
                // Now save the point data for the frame
                //

                foreach (Point p in draw[frame])
                {
                    // Create an XML node for the point
                    XmlElement pElement = doc.CreateElement("point");

                    // Add attributes for the point
                    pElement.SetAttribute("x", p.X.ToString());
                    pElement.SetAttribute("y", p.Y.ToString());

                    // Append the node to the node we are nested inside.
                    element.AppendChild(pElement);
                }

                //foreach (Line l in line[frame])
                //{
                //    // Create an XML node for the point
                //    XmlElement lElement = doc.CreateElement("line");

                //    XmlElement pElement = doc.CreateElement("p1");
                //    // Add attributes for the point
                //    pElement.SetAttribute("x", l.p1.X.ToString()); ;
                //    pElement.SetAttribute("y", l.p1.Y.ToString());

                //    XmlElement p2Element = doc.CreateElement("p2");
                //    // Add attributes for the point
                //    p2Element.SetAttribute("x", l.p2.X.ToString()); ;
                //    p2Element.SetAttribute("y", l.p2.Y.ToString());

                //    lElement.AppendChild(pElement);
                //    lElement.AppendChild(p2Element);
                //    // Append the node to the node we are nested inside.
                //    element.AppendChild(lElement) ;
                //}

                foreach (Dictionary<Point,string> img in images[frame])
                {
                    // Create an XML node for the point
                    XmlElement iElement = doc.CreateElement("image");

                    // Add attributes for the point
                    iElement.SetAttribute("x", img.Keys.ElementAt(0).X.ToString());
                    iElement.SetAttribute("y", img.Keys.ElementAt(0).Y.ToString());
                    iElement.SetAttribute("type", img.Values.ElementAt(0).ToString());
                    // Append the node to the node we are nested inside.
                    element.AppendChild(iElement);
                }
            }
        }

        public void OnOpenRotoscope(XmlNode node)
        {

            //
            // Traverse the frame node 
            //
           int frame = 0;
            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.Name == "frame")
                {
                    LoadFrame(child,frame);
                    frame += 1;
                }
            }

        }

        private void LoadFrame(XmlNode node,int frame)
        {
           //int frame = 0;
           // Get a list of all attribute nodes and the
            // length of that list
            //foreach (XmlAttribute attr in node.Attributes)
            //{
            //    if (attr.Name == "num")
            //    {
            //        frame = Convert.ToInt32(attr.Value);
            //    }
            //}

            //
            // Traverse the frame node 
            //
            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.Name == "point")
                {
                    LoadPoint(frame, child);
                }
                if(child.Name == "line")
                {
                    LoadLine(frame, child);
                }
                if(child.Name == "image")
                {
                    LoadImage(frame,child);
                }
            }
        }
        private void LoadLine(int frame, XmlNode node)
        {
            Point p1 = new Point(0,0);
            Point p2 = new Point(0,0);

            foreach (XmlNode child in node.ChildNodes)
            {
                int x = 0;
                int y =0;
                if (child.Name == "p1")
                {
                    foreach (XmlAttribute attr1 in child.Attributes)
                    {
                        if (attr1.Name == "x")
                        {
                            x = Convert.ToInt32(attr1.Value);
                        }
                        if (attr1.Name == "y")
                        {
                            y = Convert.ToInt32(attr1.Value);
                        }
                    }
                    p1.X = x;
                    p1.Y = y;
                }
                if (child.Name == "p2")
                {
                    
                    foreach (XmlAttribute attr1 in child.Attributes)
                    {
                        if (attr1.Name == "x")
                        {
                            x = Convert.ToInt32(attr1.Value);
                        }
                        if (attr1.Name == "y")
                        {
                            y = Convert.ToInt32(attr1.Value);
                        }
                    }
                    p2.X = x;
                    p2.Y = y;
                }
            }

            AddToLineList(frame, new Line(p1, p2));

        }



        private void LoadImage(int frame, XmlNode node)
        {
            int x = 0;
            int y = 0;
            string type ="";
            foreach (XmlAttribute attr in node.Attributes)
            {
                if (attr.Name == "x")
                {
                    x = Convert.ToInt32(attr.Value);
                }
                if (attr.Name == "y")
                {
                    y = Convert.ToInt32(attr.Value);
                }
                if(attr.Name == "type")
                {
                    type = attr.Value.ToString();
                }
            }
            AddToImageList(frame, new Point(x, y), type);

        }

        private void LoadPoint(int frame, XmlNode node)
        {
            int x = 0;
            int y = 0;

            foreach (XmlAttribute attr in node.Attributes)
            {
                if (attr.Name == "x")
                {
                    x = Convert.ToInt32(attr.Value);
                }
                if (attr.Name == "y")
                {
                    y = Convert.ToInt32(attr.Value);
                }
            }

            AddToDrawList(frame, new Point(x, y));

        }
        public void ClearFrame(int frame)
        {
            if (frame >= 0 && draw.Count > frame)
                draw[frame].Clear();
            if (frame >= 0 && line.Count > frame)
                line[frame].Clear();
            if (frame >= 0 && images.Count > frame)
                images[frame].Clear();
        }

        public void DrawLine(int framenum)
        {
            if(draw.Count < framenum || draw[framenum].Count < 2) return;
            int lastIndex = draw[framenum].Count - 1;
            LinkedList<Point> points = draw[framenum];

            AddToLineList(framenum, new Line(points.ElementAt(lastIndex), points.ElementAt(lastIndex - 1)));
            draw[framenum].RemoveLast();
            draw[framenum].RemoveLast();

        }

        public void makeImage(int framenum, string type)
        {
            if (draw.Count <= framenum || draw[framenum].Count < 1) 
                return;
            int lastIndex = draw[framenum].Count - 1;
            LinkedList<Point> points = draw[framenum];
            Point p = points.ElementAt(lastIndex);
            //BASKET
            AddToImageList(framenum,p,type);
            draw[framenum].RemoveLast();
        }

    }
}
