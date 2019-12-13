// Author: shmakovpn
// Date: 2019-12-13
using System;
using System.Collections.Generic;
					
public class Program
{
	protected static List<int> get_dividers(int num) {
		var dividers = new List<int>();
		int divider = 2;
		while(num>1) {
			if((num%divider)==0) {
				dividers.Add(divider);
				num /= divider;
			} else {
				divider++;
			}
		}
		return dividers;
	}
	
	protected static void test_dividers(List<int> dividers, int num) {
		int mul = 1;
		foreach(int divider in dividers) {
			mul *= divider;
		}
		if(mul!=num) throw new System.ApplicationException("get_divider failed");
	}
	
	public static void Main()
	{
		Console.WriteLine("Prime multipliers calculator");
		Console.Write("Enter numbers: ");
		String line = Console.ReadLine();
		String[] words = line.Split(' ');
		List<int> nums = new List<int>();
		foreach(String word in words) {
			try {
				nums.Add(System.Convert.ToInt32(word));
			} catch (FormatException) {
				throw new FormatException("could not convert '"+word+"' to integer");
			} catch (OverflowException) {
				throw new OverflowException("could not convert '"+word+"' to integer, item is too large");
			}
		}
		foreach(int num in nums) {
			List<int> dividers = get_dividers(num);
			test_dividers(dividers, num);
			Console.WriteLine(String.Join(",", dividers));
		}
		Console.WriteLine("END");
	}
}
