using System;
using System.Drawing;


namespace Student
{

    public class MapLocation
    {
        public static PointF GetLocation(Point point, int width, int height, int No)
        {
            float num = 220f;
            float num2 = 297f;
            PointF tf = new PointF(223.387f, 100.407f);
            PointF tf2 = new PointF(85.192f, 163.587f);
            PointF tf3 = new PointF(254.097f, 113.857f);
            PointF tf4 = new PointF(54.482f, 148.857f);
            PointF tf5 = new PointF(236.796f, 22.017f);
            PointF tf6 = new PointF(236.796f, 198.417f);
            PointF tf7 = new PointF();
            if ((No >= 1) && (No <= 10))
            {
                tf7.Y = (tf.Y * height) / num;
                tf7.X = ((tf.X - (((No - 1) * (tf.X - tf2.X)) / 9f)) * width) / num2;
            }
            else if ((No >= 11) && (No <= 0x18))
            {
                tf7.Y = (tf3.Y * height) / num;
                tf7.X = ((tf3.X - (((No - 11) * (tf3.X - tf4.X)) / 13f)) * width) / num2;
            }
            else if ((No >= 0x19) && (No <= 0x26))
            {
                tf7.Y = (tf4.Y * height) / num;
                tf7.X = ((tf3.X - (((No - 0x19) * (tf3.X - tf4.X)) / 13f)) * width) / num2;
            }
            else if ((No >= 0x27) && (No <= 0x30))
            {
                tf7.Y = (tf2.Y * height) / num;
                tf7.X = ((tf.X - (((No - 0x27) * (tf.X - tf2.X)) / 9f)) * width) / num2;
            }
            else if (No == 0x31)
            {
                tf7.X = (tf5.X * width) / num2;
                tf7.Y = (tf5.Y * height) / num;
            }
            else
            {
                tf7.X = (tf6.X * width) / num2;
                tf7.Y = (tf6.Y * height) / num;
            }
            tf7.X += point.X;
            tf7.Y += point.Y;
            return tf7;
        }

        public static PointF GetLocation2(Point point, int width, int height, int No)
        {
            float num = 220f;
            float num2 = 297f;
            PointF tf = new PointF(223.983f, 100.996f);
            PointF tf2 = new PointF(86.018f, 164.176f);
            PointF tf3 = new PointF(254.693f, 114.446f);
            PointF tf4 = new PointF(55.078f, 149.446f);
            PointF tf5 = new PointF(237.393f, 22.606f);
            PointF tf6 = new PointF(237.393f, 199.006f);
            PointF tf7 = new PointF();
            if ((No >= 1) && (No <= 10))
            {
                tf7.Y = (tf.Y * height) / num;
                tf7.X = ((tf.X - (((No - 1) * (tf.X - tf2.X)) / 9f)) * width) / num2;
            }
            else if ((No >= 11) && (No <= 0x18))
            {
                tf7.Y = (tf3.Y * height) / num;
                tf7.X = ((tf3.X - (((No - 11) * (tf3.X - tf4.X)) / 13f)) * width) / num2;
            }
            else if ((No >= 0x19) && (No <= 0x26))
            {
                tf7.Y = (tf4.Y * height) / num;
                tf7.X = ((tf3.X - (((No - 0x19) * (tf3.X - tf4.X)) / 13f)) * width) / num2;
            }
            else if ((No >= 0x27) && (No <= 0x30))
            {
                tf7.Y = (tf2.Y * height) / num;
                tf7.X = ((tf.X - (((No - 0x27) * (tf.X - tf2.X)) / 9f)) * width) / num2;
            }
            else if (No == 0x31)
            {
                tf7.X = (tf5.X * width) / num2;
                tf7.Y = (tf5.Y * height) / num;
            }
            else
            {
                tf7.X = (tf6.X * width) / num2;
                tf7.Y = (tf6.Y * height) / num;
            }
            tf7.X += point.X;
            tf7.Y += point.Y;
            return tf7;
        }
    }
}

