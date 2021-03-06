﻿// Licensed under the Apache License, Version 2.0. 
// Copyright (c) Alex Lee. All rights reserved.

using System;
using System.Collections.Generic;
using System.Drawing;

namespace SmartQuant.FinChart.Objects
{
    public class DrawingPath : IUpdatable
    {
        private int wigth = 1;
        private List<DrawingPoint> points;
        private Color color;
        private bool rangeY;

        public bool RangeY
        {
            get
            {
                return this.rangeY;
            }
            set
            {
                this.rangeY = value;
                EmitUpdated();
            }
        }

        public Color Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
                EmitUpdated();
            }
        }

        public int Width
        {
            get
            {
                return this.wigth;
            }
            set
            {
                this.wigth = value;
                EmitUpdated();
            }
        }

        public string Name { get; private set; }

        public List<DrawingPoint> Points
        {
            get
            {
                return this.points;
            }
        }

        public event EventHandler Updated;

        public DrawingPath(string name)
        {
            this.Name = name;
            this.points = new List<DrawingPoint>();
        }

        public void Add(DateTime x, double y)
        {
            this.points.Add(new DrawingPoint(x, y));
            EmitUpdated();
        }

        public void RemoveAt(int index)
        {
            this.points.RemoveAt(index);
            EmitUpdated();
        }

        public void Insert(int index, DateTime x, double y)
        {
            this.points.Insert(index, new DrawingPoint(x, y));
            EmitUpdated();
        }

        private void EmitUpdated()
        {
            if (Updated != null)
                Updated(this, EventArgs.Empty);
        }
    }
}
