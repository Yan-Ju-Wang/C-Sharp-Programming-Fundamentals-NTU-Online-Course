using System;
using System.Diagnostics;

namespace Lab3Demo
{

	public class Program
    {

		static int repl = 10; // repeat N times for each size
		static string[] titles = { "Bubble Sort", "Selection Sort", "Insertion Sort", "Array.Sort" };
		static int[] data_sizes = { 1000, 2000, 4000, 8000, 16000, 32000, 64000 };
		static double[,] tbl = new double[titles.Length, data_sizes.Length];

		static void Main()
		{

			for (int i = titles.Length - 1; i >= 0; i--)
			{
				Simulate(i);
			}
			Summary();

		}

		static void Simulate(int id)
		{

			Console.Write("Simulating {0}: ", titles[id]);

			for (int i = 0; i < data_sizes.Length; i++)
			{
				for (int j = 1; j <= repl; j++)
				{
					int[] A = ArrayFactory(data_sizes[i]);
					Stopwatch timer = new Stopwatch();
					timer.Start();
					switch (id)
					{
						case 0:
							BubbleSort(A);
							break;
						case 1:
							SelectionSort(A);
							break;
						case 2:
							InsertionSort(A);
							break;
						case 3:
							Array.Sort(A);
							break;
					}
					timer.Stop();

					tbl[id, i] += 1000.0 * timer.ElapsedTicks / Stopwatch.Frequency;
				}

				Console.Write("."); // progress bar
				tbl[id, i] /= repl; // average the time cost
			}
			Console.WriteLine("done.");

		}


		static void Summary()
		{

			Console.WriteLine("Benchmark (time unit: ms)");
			Console.Write("{0, 7}", "Size");
			foreach (String title in titles)
				Console.Write("{0, 17}", title);
			Console.WriteLine();

			for (int i = 0; i < data_sizes.Length; i++)
			{
				Console.Write("{0, 7}", data_sizes[i]);
				for (int j = 0; j < titles.Length; j++)
					Console.Write("{0, 17:f2}", tbl[j, i]);
				Console.WriteLine();
			}

		}

		static int[] ArrayFactory(int N)
		{

			Random rng = new Random();
			var A = new int[N];
			for (int i = 0; i < A.Length; i++)
				A[i] = rng.Next(0x7fffffff);
			return A;

		}

		static void Display(int[] A)
		{

			foreach (var item in A)
				Console.Write("{0} ", item);
			Console.WriteLine();

		}

		static void BubbleSort(int[] A)
		{

			for (int i = 0; i < A.Length; i++)
			{
				for (int j = 0; j < A.Length - i - 1; j++)
				{
					if (A[j] > A[j + 1])
					{
						int tmp = A[j];
						A[j] = A[j + 1];
						A[j + 1] = tmp;
					}
				}
			}

		}

		static void SelectionSort(int[] A)
		{

			for (int i = 0; i < A.Length; i++)
			{

				int idx = i;
				for (int j = i; j < A.Length; j++)
				{
					if (A[j] < A[idx])
					{
						idx = j;
					}
				}

				int tmp = A[i];
				A[i] = A[idx];
				A[idx] = tmp;

			}

		}

		static void InsertionSort(int[] A)
		{

			for (int i = 1; i < A.Length; i++)
			{

				int tmp = A[i];
				int j = i - 1;
				for (; j >= 0 && A[j] > tmp; j--)
				{
					A[j + 1] = A[j];
				}
				A[j + 1] = tmp;

			}

		}
	}
}