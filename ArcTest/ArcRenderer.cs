using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArcTest
{
    public partial class ArcRenderer : Control
    {
        private float _start;
        private float _end;
        private float _circleThickness;
        private bool _enabledRoundedEndPoint;
        private Pen? _stroke = new Pen(Color.FromArgb(126, 224, 126), 2);
        private Brush? _fill = new SolidBrush(Color.FromArgb(41, 51, 41));

        public ArcRenderer()
        {
            InitializeComponent();

            // 启用双缓冲, 避免绘图闪烁
            DoubleBuffered = true;
        }

        /// <summary>
        /// 起始角 (弧度制)
        /// </summary>
        public float Start
        {
            get => _start;
            set
            {
                _start = value;
                Invalidate();
            }
        }

        /// <summary>
        /// 结束角 (弧度制)
        /// </summary>
        public float End
        {
            get => _end;
            set
            {
                _end = value;
                Invalidate();
            }
        }

        /// <summary>
        /// 圆的厚度 (内圆和外圆之间的距离)
        /// </summary>
        public float CircleThickness
        {
            get => _circleThickness;
            set
            {
                _circleThickness = value;
                Invalidate();
            }
        }

        /// <summary>
        /// 启用圆形断点
        /// </summary>
        public bool EnabledRoundedEndPoint
        {
            get => _enabledRoundedEndPoint;
            set
            {
                _enabledRoundedEndPoint = value;
                Invalidate();
            }
        }

        /// <summary>
        /// 边缘绘制笔
        /// </summary>
        public Pen? Stroke
        {
            get => _stroke;
            set
            {
                _stroke = value;
                Invalidate();
            }
        }

        /// <summary>
        /// 填充笔刷
        /// </summary>
        public Brush? Fill
        {
            get => _fill;
            set
            {
                _fill = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            var g = pe.Graphics;

            var size = (float)Math.Min(Width, Height);
            if (Stroke is not null)
            {
                size -= Stroke.Width;
            }

            var radius = size / 2f;
            var innerRadius = radius - CircleThickness;
            var center = new PointF(Width / 2f, Height / 2f);

            var sinStart = MathF.Sin(Start);
            var cosStart = MathF.Cos(Start);
            var sinEnd = MathF.Sin(End);
            var cosEnd = MathF.Cos(End);

            var innerRect = new RectangleF(
                center.X - innerRadius,
                center.Y - innerRadius,
                innerRadius * 2,
                innerRadius * 2);

            var outerRect = new RectangleF(
                center.X - radius,
                center.Y - radius,
                radius * 2,
                radius * 2);

            var outerStartPoint = new PointF(
                center.X + cosStart * radius,
                center.Y + sinStart * radius);
            var innerStartPoint = new PointF(
                center.X + cosStart * innerRadius,
                center.Y + sinStart * innerRadius);
            var centerStartPoint = new PointF(
                (outerStartPoint.X + innerStartPoint.X) / 2,
                (outerStartPoint.Y + innerStartPoint.Y) / 2);

            var outerEndPoint = new PointF(
                center.X + cosEnd * radius,
                center.Y + sinEnd * radius);
            var innerEndPoint = new PointF(
                center.X + cosEnd * innerRadius,
                center.Y + sinEnd * innerRadius);
            var centerEndPoint = new PointF(
                (outerEndPoint.X + innerEndPoint.X) / 2,
                (outerEndPoint.Y + innerEndPoint.Y) / 2);

            var endGreatorThanStart = End > Start;

            var angleStart = Start / MathF.PI * 180;
            var angleEnd = End / MathF.PI * 180;

            using GraphicsPath path = new GraphicsPath();
            path.StartFigure();

            if (EnabledRoundedEndPoint)
            {
                path.AddArc(
                    new RectangleF(
                        centerEndPoint.X - CircleThickness / 2,
                        centerEndPoint.Y - CircleThickness / 2,
                        CircleThickness,
                        CircleThickness),
                    (End) / MathF.PI * 180,
                    endGreatorThanStart ? 180 : -180);
            }
            else
            {
                path.AddLine(innerEndPoint, outerEndPoint);
            }

            path.AddArc(outerRect, angleEnd, angleStart - angleEnd);

            if (EnabledRoundedEndPoint)
            {
                path.AddArc(
                    new RectangleF(
                        centerStartPoint.X - CircleThickness / 2,
                        centerStartPoint.Y - CircleThickness / 2,
                        CircleThickness,
                        CircleThickness),
                    (Start) / MathF.PI * 180,
                    endGreatorThanStart ? -180 : 180);
            }
            else
            {
                path.AddLine(outerStartPoint, innerStartPoint);
            }

            path.AddArc(innerRect, angleStart, angleEnd - angleStart);
            path.CloseFigure();

            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;

            if (Stroke is not null)
            {
                g.DrawPath(Stroke, path);
            }

            if (Fill is not null)
            {
                g.FillPath(Fill, path);
            }
        }
    }
}
