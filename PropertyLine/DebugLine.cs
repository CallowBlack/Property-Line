using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Properties.Properties;

namespace Properties
{

    public partial class DebugLine : Form
    {
        [DllImport("user32.dll")]
        static extern bool GetCursorPos(out Point pt);

        internal bool GetCursor(out Point lpPos)
        {
            return GetCursorPos(out lpPos);
        }

        internal bool GetCursorIn(Rectangle F)
        {
            Point curs;
            GetCursor(out curs);
            return (F.X <= curs.X && F.X + F.Width >= curs.X && F.Y <= curs.Y && F.Y + F.Height >= curs.Y);

        }

        void checkMousePosition()
        {
            while (true)
            {
                if (!DragMode)
                {
                    if (GetCursorIn(new Rectangle(Location, maxFormSize)))
                    {
                        if (InvokeRequired)
                        {
                            Invoke(new Action<Size>(x => Size = x), new Size(0, 0));
                        }
                    }
                    else if (maxFormSize != Size)
                    {
                        this?.Invoke(new Action<Size>(x => Size = x), maxFormSize);
                    }
                }
                else
                {
                    Size nsize = new Size(maxFormSize.Width, maxFormSize.Height < 25 ? 25 : maxFormSize.Height);
                    if (Size != nsize)
                    {
                        this?.Invoke(new Action<Size>(x => Size = x), nsize);
                    }
                    
                }
                Thread.Sleep(100);
            }
        }

        private class StatusLine
        {
            private Label head;
            private Label element;
            private bool visible;
            private Form formToAttach;

            #region Events
            public EventHandler VisibleChanged;
            public EventHandler TextSizeChanged;
            #endregion

            #region Accessors
            public bool Visible
            {
                get => visible;
                set
                {
                    if (visible != value) {
                        visible = value;
                        Size tSize = TextSize;
                        head.Size = new Size(head.Size.Width, value ? tSize.Height : 0);
                        element.Size = new Size(element.Size.Width, value ? tSize.Height : 0);
                        VisibleChanged?.Invoke(this, null);
                    }
                }
            }

            public Label Head { get => head; }

            public Label Element { get => element; }

            public Size Size
            {
                set { Head.Size = value; Element.Size = value; }
                get => new Size(Head.Size.Width + Element.Size.Width, Head.Size.Height);
            }

            public Size TextSize
            {
                get => new Size((TextRenderer.MeasureText(head.Text, head.Font) +
                        TextRenderer.MeasureText(element.Text, element.Font)).Width,
                        TextRenderer.MeasureText(element.Text, element.Font).Height);
            }

            public Point Location
            {
                get => head.Location;
                set
                {
                    head.Location = value;
                    element.Location = new Point(value.X + head.Size.Width, value.Y);
                }
            }
            #endregion

            public StatusLine(Form form, string Header, string Text)
            {
                formToAttach = form;

                initialLabel(out head);
                initialLabel(out element);

                head.Text = Header;
                element.Text = Text;
                visible = true;
            }

            private void initialLabel(out Label label)
            {
                label = new Label();
                label.Text = " ";
                formToAttach.Controls.Add(label);
                label.BackColor = Color.White;
                label.Size = TextRenderer.MeasureText(label.Text, label.Font);
                label.TextChanged += onTextChange;
            }

            private void onTextChange(object sender, EventArgs e)
            {
                Label lSender = (Label)sender;
                Size tSize;
                if ((tSize = new Size(TextRenderer.MeasureText(lSender.Text, head.Font).Width, lSender.Size.Height)) != lSender.Size) {
                    lSender.Size = tSize;
                    if (lSender == head)
                        element.Location = new Point(Location.X + head.Size.Width, Location.Y);
                    TextSizeChanged?.Invoke(this, null);
                }
            }

            ~StatusLine()
            {
                if (formToAttach != null)
                {
                    formToAttach.Controls.Remove(head);
                    formToAttach.Controls.Remove(element);
                }
            }

        }

        private bool dragMode;
        public bool DragMode{
            get => dragMode;
            set { dragMode = value; btnMove.Visible = value; }
        }

        private List<StatusLine> StatusLines;
        private Size maxFormSize;
        private Thread checkMousePositionThread;

        public DebugLine()
        {
            InitializeComponent();
        }

        private void DebugLine_Load(object sender, EventArgs e)
        {
            StatusLines = new List<StatusLine>();
            maxFormSize = new Size();
            DragMode = false;

            TransparencyKey = BackColor;
            checkMousePositionThread = new Thread(checkMousePosition);
            checkMousePositionThread.Start();
        }
        
        public void reloadDebug()
        {
            TopMost = true;
        }

        public void setStatusLine(string header, string text, Color color)
        {
            StatusLine statusLine;
            if ((statusLine = StatusLines.Find(x => x.Head.Text == header)) == null)
            {
                statusLine = new StatusLine(this, header, text);
                addStatusLine(statusLine);
            }

            statusLine.Element.Text = text;
            statusLine.Element.ForeColor = color;
        }

        public void setVisible(string header, bool visible)
        {
            StatusLine statusLine;
            if ((statusLine = StatusLines.Find(x => x.Head.Text == header)) != null)
            {
                statusLine.Visible = visible;
            }
        }

        private void addStatusLine(StatusLine line)
        {
            StatusLines.Add(line);
            line.Location = new Point(0, maxFormSize.Height);
            line.VisibleChanged = onVisibleChanged;
            //line.TextSizeChanged = onTextSizeChanged;
            maxFormSize.Height += line.Size.Height;
            if (line.Size.Width > maxFormSize.Width)
                maxFormSize.Width = line.Size.Width;
            Location = PositionCorrect(ConvertTo(Settings.Default.WindowPosition, (CornerRelativity)Settings.Default.RelativeCorner));
        }


        private void onVisibleChanged(object sender, EventArgs e)
        {
            StatusLine senderLine = (StatusLine)sender;
            maxFormSize.Height += senderLine.Visible ? senderLine.Size.Height : -senderLine.TextSize.Height;
            updateStatusLines(StatusLines.IndexOf(senderLine) + 1);
        }

        private void onTextSizeChanged(object sender, EventArgs e)
        {
            updateStatusLines(-1);
        }

        void updateStatusLines(int start = 0)
        {
            int maxWidth = 0;
            for (int i = 0; i < StatusLines.Count; i++)
            {
                if (StatusLines[i].Size.Width > maxWidth && StatusLines[i].Visible)
                    maxWidth = StatusLines[i].Size.Width;
                if (start >= 0 && i >= start)
                {
                    if (i == 0)
                    {
                        StatusLines[i].Location = new Point(0, 0);
                    }
                    else
                    {
                        StatusLines[i].Location = new Point(0,
                                                  StatusLines[i - 1].Location.Y + StatusLines[i - 1].Size.Height);
                    }
                }
            }
            maxFormSize.Width = maxWidth;
            Location = PositionCorrect(ConvertTo(Settings.Default.WindowPosition, (CornerRelativity)Settings.Default.RelativeCorner));
        }

        private void DebugLine_FormClosing(object sender, FormClosingEventArgs e)
        {
            checkMousePositionThread.Abort();
        }

        #region Drag and drop

        private bool startDrag;
        private Point startPos;
        private void btnMove_MouseDown(object sender, MouseEventArgs e)
        {
            if (DragMode)
            {
                startDrag = true;
                startPos = new Point(e.X, e.Y);
            }
        }
        
        private void btnMove_MouseMove(object sender, MouseEventArgs e)
        {
            if (startDrag) {
                Point dragPosition = new Point(Location.X + (e.X - startPos.X), Location.Y + (e.Y - startPos.Y));
                Location = PositionCorrect(dragPosition); 
            }
        }

        private void btnMove_MouseUp(object sender, MouseEventArgs e)
        {
            if (startDrag)
            {
                startDrag = false;
                Settings.Default.WindowPosition = ConvertTo(Location, (CornerRelativity)Settings.Default.RelativeCorner);
                Settings.Default.Save();
            }
        }
        #endregion


        public Point ConvertTo(Point position, CornerRelativity relativeCorner)
        {
            Point globalPosition = position;
            switch (relativeCorner)
            {
                case CornerRelativity.TopRight:
                    globalPosition.X = Screen.PrimaryScreen.Bounds.Width - position.X - maxFormSize.Width;
                    break;
                case CornerRelativity.BottomLeft:
                    globalPosition.Y = Screen.PrimaryScreen.Bounds.Height - position.Y - maxFormSize.Height;
                    break;
                case CornerRelativity.BottomRight:
                    globalPosition =
                        new Point(
                            Screen.PrimaryScreen.Bounds.Width - position.X - maxFormSize.Width, 
                            Screen.PrimaryScreen.Bounds.Height - position.Y - maxFormSize.Height
                            );
                    break;
            }
            return globalPosition;
        }

        private Point PositionCorrect(Point position)
        {
            if (position.X < 0)
                position.X = 0;
            else if (position.X + maxFormSize.Width > Screen.PrimaryScreen.Bounds.Width)
            {
                position.X = Screen.PrimaryScreen.Bounds.Width - maxFormSize.Width;
            }
            if (position.Y < 0)
                position.Y = 0;
            else if (position.Y + maxFormSize.Height > Screen.PrimaryScreen.Bounds.Height)
            {
                position.Y = Screen.PrimaryScreen.Bounds.Height - maxFormSize.Height;
            }
            return position;
        }
    }
}
