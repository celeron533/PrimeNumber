using System;
using System.Collections.Generic;

namespace Prime
{
	class Program
	{
		static void Main(string[] args)
		{
			//the calculation will stop when satisfy one of the following parameters:
			const int range = int.MaxValue;	//set here
			const int maxHitPrimeCount = 1000;  //set here

			Console.WriteLine(String.Format("Find prime number from 1 to {0}", range));
			Console.WriteLine(String.Format("OR until find the {0}th prime number", maxHitPrimeCount));
			Console.WriteLine("===============");

			int calcLoopCount = 0;
			int hitPrimeCount = 1;

			DateTime startTime = DateTime.Now;

			// a collection of tested prime numbers. Add '2' as the first item
			List<int> primeCollection = new List<int>(range / 8);
			primeCollection.Add(2);

			// start at 3, skip all even numbers
			for(int target = 3; target <= range; target += 2)
			{
				bool isPrime = true;
				int squareRoot = (int)Math.Sqrt(target);
				for(int i = 1; i < primeCollection.Count; i++)
				{
					calcLoopCount++;
					int testFactor = primeCollection[i];
					if(testFactor > squareRoot)
						break;
					if(target % testFactor == 0)
					{
						isPrime = false;
						break;
					}
				}
				if(isPrime)
				{
					hitPrimeCount++;
					primeCollection.Add(target);
					//if(hitPrimeCount % 10000 == 0)
					//    Console.Write(String.Format("\rThe {0}th prime number is: {1}", hitPrimeCount, primeCollection[primeCollection.Count - 1]));
					if(hitPrimeCount >= maxHitPrimeCount)
						break;
				}

			}

			DateTime endTime = DateTime.Now;

			//StringBuilder sb=new StringBuilder();
			//foreach(int prime in primeCollection)
			//{
			//    sb.Append(String.Format("{0}, ", prime));
			//}

			//Console.WriteLine(sb.ToString());

			Console.WriteLine(String.Format("Last item: the {0}th prime number is: {1}", hitPrimeCount, primeCollection[primeCollection.Count - 1]));
			Console.WriteLine(String.Format("calcLoopCount: {0}", calcLoopCount));
			Console.WriteLine(String.Format("TimeSpan: {0} ms", endTime.Subtract(startTime).TotalMilliseconds));
			Console.Write("Press any key to continue...");
			Console.ReadKey();
		}
	}
}
