using System;
using Gtk;
using GLib;

namespace Lab5
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var h = new UnhandledExceptionHandler (HandleException);
			ExceptionManager.UnhandledException += h;

			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}

		// Ошибка -> Исключение Lab5Exception -> UnhandledException : Lab5Exception ->
		// ExceptionManager -> HandleException (struct args { UnhandledException }) ->
		// ExceptionObject == UnhandledException -> InnerException -> Lab5Exception

		static void HandleException (UnhandledExceptionArgs args)
		{
			var exception = new Exception ();
			exception.SetText (((System.Exception) args.ExceptionObject).InnerException.Message);
			var response = (ResponseType) exception.Run();

			switch (response)
			{
			case ResponseType.DeleteEvent:
			case ResponseType.Ok:
				exception.Destroy ();
				break;
			}
		}
	}

	public class Lab5Exception : System.Exception
	{
		public Lab5Exception (string message)
			: base (message) {}
	}
} 