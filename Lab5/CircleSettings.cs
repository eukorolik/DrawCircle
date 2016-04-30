using System;
using Gtk;

namespace Lab5
{
    public partial class CircleSettings : Gtk.Dialog
    {
        public CircleSettings () 
        {
            this.Build ();
        }

        public Tuple<int, bool, bool> GetData ()
        {
            return new Tuple<int, bool, bool> (Int32.Parse(Radius.Text), Square.Active, Length.Active);
        }

		protected void OnButtonOkPressed (object sender, EventArgs e)
		{
			int testNum;
			if (!Int32.TryParse (Radius.Text, out testNum) || (!Square.Active && !Length.Active))
			{
				throw new  Lab5Exception ("Пожалуйста, введите в окно 'Радиус' целочисленное значение и выберите интересующие вас флажки ^__^");

			}


			if (Int32.Parse(Radius.Text)>280)
			{
				throw new  Lab5Exception ("Пожалуйста, введите радиус поменьше, ибо окружность выходит за границы дозволенного ^__^");

			}


			if (Int32.Parse(Radius.Text)<=0)
			{
				throw new  Lab5Exception ("Извините, но окружность такого радиуса не будет видна в трёх измерениях... Пожалуйста, введите целое число ^__^");

			}


		}

    }
}

