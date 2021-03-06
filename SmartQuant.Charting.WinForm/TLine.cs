﻿// Decompiled with JetBrains decompiler
// Type: SmartQuant.Charting.TLine
// Assembly: SmartQuant.Charting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=23953e483e363d68
// MVID: F3B55EE9-4DBA-4875-B18A-7BD8DFCF4D88
// Assembly location: C:\Program Files\SmartQuant Ltd\OpenQuant 2014\SmartQuant.Charting.dll

using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SmartQuant.Charting
{
    [Serializable]
    public class TLine : IDrawable
    {
        public bool ToolTipEnabled { get; set; }

        public string ToolTipFormat { get; set; }

        public double X1 { get; set; }

        public double Y1 { get; set; }

        public double X2 { get; set; }

        public double Y2 { get; set; }

        public DashStyle DashStyle { get; set; }

        public Color Color { get; set; }

        public int Width { get; set; }

        public TLine(double x1, double y1, double x2, double y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            Color = Color.Black;
            DashStyle = DashStyle.Solid;
            Width = 1;
        }

        public TLine(DateTime x1, double y1, DateTime x2, double y2)
            : this(x1.Ticks, y1, x2.Ticks, y2)
        {
        }

        public virtual void Draw()
        {
            if (Chart.Pad == null)
            {
                var canvas = new Canvas("Canvas", "Canvas");
            }
            Chart.Pad.Add((object)this);
        }

        public virtual void Paint(Pad pad, double xMin, double xMax, double yMin, double yMax)
        {
            pad.DrawLine(new Pen(Color) { Width = Width, DashStyle = DashStyle }, X1, Y1, X2, Y2);
        }

        public TDistance Distance(double X, double Y)
        {
            return null;
        }
    }
}
