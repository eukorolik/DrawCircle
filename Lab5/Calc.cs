using System;

namespace Lab5
{
    public partial class Calc : Gtk.Dialog
    {
        public Calc (int radius, bool square, bool length)
        {
            this.Build ();

            if (square)
            {
                Square.LabelProp = string.Format ("{0}", Math.PI * Math.Pow (radius, 2));
                Square.Visible = true;
                SquareLabel.Visible = true;
            }

            if (length)
            {
                Length.LabelProp = string.Format ("{0}", 2 * Math.PI * radius);
                Length.Visible = true;
                LengthLabel.Visible = true;
            }
        }

    }
}

