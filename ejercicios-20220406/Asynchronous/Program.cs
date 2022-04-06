// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
//Asynchronous.WaitForIt();
//await Asynchronous.WaitForIt2();

var timeElapsed = await Parallelism.Main();
Console.WriteLine($"Both proceses finished after {timeElapsed / 1000m} seconds");

public class Asynchronous
{
	//Asincrono
	public static async Task WaitForIt()
	{
		await Task.Delay(TimeSpan.FromSeconds(5));
		Console.WriteLine("Five seconds complete");
	}

	public static async Task WaitForIt2()
	{
		await Task.Delay(10000);
		Console.WriteLine("Ten seconds complete");
	}
}

public class Parallelism
{
	public static async Task<long> Main()
	{
		var stopwatch = new Stopwatch();
		stopwatch.Start();

		Process1();
		Process2();

		stopwatch.Stop();

		return stopwatch.ElapsedMilliseconds;
	}

	public static async Task Process1()
	{
		await Task.Run(() =>
		{
			Thread.Sleep(4000);
		});
	}

	public static async Task Process2()
	{
		await Task.Run(() =>
		{
			Thread.Sleep(1000);
		});
	}
}