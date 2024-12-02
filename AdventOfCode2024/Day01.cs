namespace AdventOfCode2024;

public class Day01
{
  //Maybe the lists are only off by a small amount! To find out, pair up the numbers and measure how far apart they are.
  //Pair up the smallest number in the left list with the smallest number in the right list,
  //then the second-smallest left number with the second-smallest right number, and so on.

  static void Main(string[] args)
  { 
    var lines = File.ReadLines("/Users/brevin/Documents/GitHub/AdventOfCode2024/AdventOfCode2024/assets/day01input.txt");
    List<int> firstCol = new List<int>();
    List<int> secondCol = new List<int>();
    foreach (var line in lines)
    {
      var tempItem = line.Split(' ');
      // Console.WriteLine(tempItem[3]);
      firstCol.Add(Int32.Parse(tempItem[0]));
      secondCol.Add(Int32.Parse(tempItem[3]));
    }

    firstCol.Sort();
    secondCol.Sort();
    
    partOne(firstCol, secondCol);
    partTwo(firstCol, secondCol);
  }

  static void partOne(List<int> firstCol, List<int> secondCol)
  {
    var total = 0;

    for (int i = 0; i < firstCol.Count; i++)
    {
      total += Math.Abs(firstCol[i] - secondCol[i]);
     
    }
    Console.WriteLine("Total: " + total);
  }

  static void partTwo(List<int> firstCol, List<int> secondCol)
  {
    var total = 0;
    
    foreach (var num in firstCol)
    {
      var count = 0;
      foreach (var num2 in secondCol)
      {
        if (num == num2)
        {
          count += 1;
        }
      }

      total += count * num;

    }
    
    Console.WriteLine("Part Two Total: " + total);
  }
}