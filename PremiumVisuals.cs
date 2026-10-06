using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace AshkanHotelManager
{
    internal sealed class PremiumBackgroundPanel : Panel
    {
        public Image BackgroundArtwork { get; set; }
        public int OverlayAlpha { get; set; } = 122;
        public PremiumBackgroundPanel(){ DoubleBuffered=true; ResizeRedraw=true; }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            var r=ClientRectangle;
            using(var b=new LinearGradientBrush(r,Color.FromArgb(12,22,45),Color.FromArgb(30,41,78),LinearGradientMode.ForwardDiagonal)) e.Graphics.FillRectangle(b,r);
            if(BackgroundArtwork!=null)
            {
                e.Graphics.InterpolationMode=InterpolationMode.HighQualityBicubic;
                var src=Cover(BackgroundArtwork.Size,r.Size);
                e.Graphics.DrawImage(BackgroundArtwork,r,src,GraphicsUnit.Pixel);
                using(var veil=new SolidBrush(Color.FromArgb(OverlayAlpha,7,15,34))) e.Graphics.FillRectangle(veil,r);
            }
        }
        static Rectangle Cover(Size image,Size box)
        {
            double ir=(double)image.Width/image.Height, br=(double)box.Width/Math.Max(1,box.Height);
            if(ir>br){int nw=(int)(image.Height*br);return new Rectangle((image.Width-nw)/2,0,nw,image.Height);}
            int nh=(int)(image.Width/br);return new Rectangle(0,(image.Height-nh)/2,image.Width,nh);
        }
    }

    internal sealed class GlassPanel : Panel
    {
        public Color GlassColor { get; set; } = Color.FromArgb(225,24,35,56);
        public int Radius { get; set; } = 18;
        public GlassPanel(){DoubleBuffered=true;BackColor=Color.Transparent;Padding=new Padding(18);}
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode=SmoothingMode.AntiAlias;
            using(var p=RoundRect(new Rectangle(1,1,Width-3,Height-3),Radius))
            using(var b=new SolidBrush(GlassColor)) e.Graphics.FillPath(b,p);
            using(var p=RoundRect(new Rectangle(1,1,Width-3,Height-3),Radius))
            using(var pen=new Pen(Color.FromArgb(55,180,205,235))) e.Graphics.DrawPath(pen,p);
        }
        static GraphicsPath RoundRect(Rectangle r,int radius)
        {
            int d=Math.Max(2,radius*2);var p=new GraphicsPath();
            p.AddArc(r.X,r.Y,d,d,180,90);p.AddArc(r.Right-d,r.Y,d,d,270,90);p.AddArc(r.Right-d,r.Bottom-d,d,d,0,90);p.AddArc(r.X,r.Bottom-d,d,d,90,90);p.CloseFigure();return p;
        }
    }

    internal static class PremiumAssets
    {
        public static Image TryLoad(string file)
        {
            try{var p=Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Assets",file);return File.Exists(p)?Image.FromFile(p):null;}catch{return null;}
        }
    }
}
