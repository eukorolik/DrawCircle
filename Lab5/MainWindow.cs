using System;
using Gtk;
using Cairo;

public partial class MainWindow: Gtk.Window
{
    int Radius;
    bool Square, Length;

    public MainWindow () : base (Gtk.WindowType.Toplevel)
    {
        Build ();
    }

    protected void OnDeleteEvent (object sender, DeleteEventArgs a)
    {
        Application.Quit ();
        a.RetVal = true;
    }

    protected void OnExitActionActivated (object sender, EventArgs e)
    {
        Environment.Exit (0);
    }

    protected void OnInputActionActivated (object sender, EventArgs e)
    {
        var circleSettings = new Lab5.CircleSettings ();
        circleSettings.Modal = true;
        var response = (ResponseType) circleSettings.Run();

        switch (response)
        {
            case ResponseType.DeleteEvent:
            {
                circleSettings.Destroy ();
            }
            break;

            case ResponseType.Cancel:
            {
                circleSettings.Destroy ();
            }
            break;

            case ResponseType.Ok:
            {
                var data = circleSettings.GetData ();
                Radius = data.Item1;
                Square = data.Item2;
                Length = data.Item3;

                circleSettings.Destroy ();
            }
            break;
        }
    }

    protected void OnCalcActionActivated (object sender, EventArgs e)
    {
        var calc = new Lab5.Calc (Radius, Square, Length);
        var response = (ResponseType) calc.Run();

        switch (response)
        {
            case ResponseType.DeleteEvent:
            case ResponseType.Ok:
                calc.Destroy ();
                break;
        }
    }

	protected void OnDrawActionActivated (object sender, EventArgs e)
	{
		if (Radius == 0)
			return;

		Area.GdkWindow.Clear ();

		var canvas = Gdk.CairoHelper.Create(Area.GdkWindow); // Создание холста для рисования

		canvas.SetSourceRGB (0.2, 0.23, 0.9); //цвет окружности
		canvas.Arc ((Area.WidthRequest + 20)/2, (Area.HeightRequest + 40)/2, Radius, 0, 2 * Math.PI); //задание параметров окружности
		canvas.StrokePreserve (); // Непосредственная отрисовка линии окружности
		canvas.SetSourceRGB (1, 1, 1); // Задание нового цвета для заполнения круга цветом
		canvas.Fill (); // Заполнение круга цветом
	}
}

