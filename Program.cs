var t = Convert.ToInt32(Console.ReadLine());
Console.ReadLine();

for (int z = 0; z < t; z++)
{
    string[] nq = Console.ReadLine().Trim().Split(' ');
    int n = Convert.ToInt32(nq[0]);
    int q = Convert.ToInt32(nq[1]);
    Dictionary<int, string> available = new Dictionary<int, string>();
    for (int i = 1; i <= 2 * n; i++)
    {
        available.Add(i, "free");
    }

    SortedSet<int> availableCupe = new SortedSet<int>();
    for (int i = 1; i <= n; i++)
    {
        availableCupe.Add(i);
    }

    for (int x = 0; x < q; x++)
    {
        string oneQ = Console.ReadLine().Trim();
        if (oneQ.Length == 1)
        {
            string otvet = NearestCupe(available,availableCupe);
            Console.WriteLine(otvet);
        }
        else
        {
            string[] oneOfTheQ = oneQ.Split(' ');
            int zapros = Convert.ToInt32(oneOfTheQ[0]);
            int mesto = Convert.ToInt32(oneOfTheQ[1]);
            if (zapros == 1)
            {
                string otvet = Zanyat(mesto, available, availableCupe);
                Console.WriteLine(otvet);
            }
            else if (zapros == 2)
            {
                string otvet = Otmenit(mesto, available, availableCupe);
                Console.WriteLine(otvet);
            }
        }
    }

    Console.ReadLine();


}


string Zanyat(int mesto, Dictionary<int, string> available, SortedSet<int> availableCupe)
{
    if ( mesto <= available.Count && available[mesto] == "free")
    {
        available[mesto] = "occupied";
        if (mesto % 2 == 0)
        {
            int n = mesto / 2;
            availableCupe.Remove(n);
        }
        else
        {
            int n = (mesto + 1) / 2;
            availableCupe.Remove(n);
        }
        return "SUCCESS";

    }

    return "FAIL";
}

string Otmenit(int mesto, Dictionary<int, string> available, SortedSet<int> availableCupe)
{
    if (mesto <= available.Count && available[mesto] == "occupied")
    {
        available[mesto] = "free";
        if (mesto % 2 == 0)
        {
            if (available[mesto - 1] == "free")
            {
                availableCupe.Add(mesto / 2);
            }
        }
        else
        {
            if (available[mesto + 1] == "free")
            {
                availableCupe.Add((mesto + 1) / 2);
            }
        }

        return "SUCCESS";
    }

    return "FAIL";
}

string NearestCupe(Dictionary<int, string> available, SortedSet<int> availableCupe)
{
    if (availableCupe.Count > 0)
    {
        int numberOfCupe = availableCupe.Min();
        available[numberOfCupe * 2] = "occupied";
        available[(numberOfCupe * 2)-1] = "occupied";
        availableCupe.Remove(numberOfCupe);
        return $"SUCCESS {(numberOfCupe * 2) - 1}-{numberOfCupe * 2}";
    }

    return "FAIL";
}

