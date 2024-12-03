namespace AdventOfCode2024;

public class Day02
{
    public static void Day02Run()
    {
        var total = 0;
        var lines = File.ReadLines("/Users/brevin/Documents/GitHub/AdventOfCode2024/AdventOfCode2024/assets/day02input.txt");
        foreach (var line in lines)
        {
            var lineVal = line.Split(' ');
            List<int> newList = new List<int>();
            foreach (var val in lineVal)
            {
                newList.Add(Int32.Parse(val));
            }

            var isSafe = checkRowP2(newList);
            if (isSafe)
            {
                total += 1;
            }
        }
        
        Console.WriteLine("Total: " + total);
    }

    static bool checkRow(List<int> row) 
    {
        var increasing = true;
        var safe = true; 
        
        for (int i = 0; i < row.Count - 1; i++)
        {
            if (i == 0)
            {
                if (row[i] > row[i + 1]) // 48 and 51
                {
                    increasing = false;
                }
                else
                {
                    increasing = true;
                }
            }
            
            if (row[i] > row[i + 1]) // 53 52
            {
                if (increasing)
                {
                    safe = false;
                    return safe;
                }
                increasing = false;
            }
            else if (row[i] == row[i + 1])
            {
                safe = false;
                return safe;
            } 
            else 
            {
                if (!increasing)
                {
                    safe = false;
                    return safe;
                }
                increasing = true;
            }

            if (safe)
            {
                if (Math.Abs(row[i] - row[i + 1]) > 3)
                {
                    safe = false;
                    return safe;
                }
            }
            
        }

        return safe;
    }

    static bool checkRowP2(List<int> row)
    {
        var increasing = true;
        
        for (int i = 0; i < row.Count - 1; i++)
        {
            if (i == 0)
            {
                if (row[i] > row[i + 1]) // 48 and 51
                {
                    increasing = false;
                }
                else
                {
                    increasing = true;
                }
            }
            
            if (row[i] > row[i + 1]) // 53 52
            {
                if (increasing)
                {
                    row.Remove(row[i]);
                    break;
                }
                increasing = false;
            }
            else if (row[i] == row[i + 1])
            {
                row.Remove(row[i + 1]);
                break;
            } 
            else 
            {
                if (!increasing)
                {
                    row.Remove(row[i]);
                    break;
                }
                increasing = true;
            }

            if (row.Count - 1 > i)
            {
                if (Math.Abs(row[i] - row[i + 1]) > 3)
                {
                    row.Remove(row[i + 1]);
                    break;
                }
            }
        }
        
        return checkRow(row);

    }
    
}