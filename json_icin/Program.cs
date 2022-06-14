using Newtonsoft.Json;

var list = json_format.JsonLoad();
var dizi=list.ToArray();

foreach (var d in dizi)
    Console.WriteLine(d);
/*
dizi=sort(dizi);
var sonuc=Search(dizi, 529);
Console.WriteLine(sonuc);  */
Console.ReadKey();

static int Search(Employee[] arr, int searchedData)
{
    int i = 0;
    int arrLength = arr.Length - 1;
    while (i <= arrLength)
    {
        int index = i + (arrLength - i) / 2;
        if (arr[index].salary == searchedData)
        {
            return index;
        }
        if (arr[index].salary < searchedData)
        {
            i = index + 1;
        }
        else
        {
            arrLength = index - 1;
        }
    }

    return -1;
}

static Employee[] sort(Employee[] employees)
{
    var arrayLength = employees.Length;
    for (int i = 0; i < arrayLength - 1; i++)
    {
        var smallestVal = i;
        for (int j = i + 1; j < arrayLength; j++)
        {
            if (employees[j].salary < employees[smallestVal].salary)
            {
                smallestVal = j;
            }
        }
        var tempVar = employees[smallestVal];
        employees[smallestVal] = employees[i];
        employees[i] = tempVar;
    }
    return employees;

}

//------------------------------------------------------
public class json_format
{
    public static List<Employee> JsonLoad()
    {
        using (StreamReader r = new StreamReader(path: @"D:\MYAZ206-main\MYAZ206-main\data_with_json_format.json"))
        {
            string json = r.ReadToEnd();
            return JsonConvert.DeserializeObject<List<Employee>>(json);
        }
    }
}

public class Employee
{
    public int id { get; set; }
    public int salary { get; set; }
    public int FullName { get; set; }
    public string Title { get; set; }
    public override string ToString()
    {
        return $"{salary} |{FullName}";
    }
}

public class SelectionShort
{
    public static Employee[] sort(Employee[] employees)
    {
        var arrayLength = employees.Length;
        for (int i = 0; i < arrayLength - 1; i++)
        {
            var smallestVal = i;
            for (int j = i + 1; j < arrayLength; j++)
            {
                if (employees[j].salary < employees[smallestVal].salary)
                {
                    smallestVal = j;
                }
            }
            var tempVar = employees[smallestVal];
            employees[smallestVal] = employees[i];
            employees[i] = tempVar;
        }
        return employees;
    }
}

public class BinarySearch
{
    public static int Search(Employee[] arr, int searchedData)
    {
        int i = 0;
        int arrLength = arr.Length - 1;
        while (i <= arrLength)
        {
            int index = i + (arrLength - i) / 2;
            if (arr[index].salary == searchedData)
            {
                return index;
            }
            if (arr[index].salary < searchedData)
            {
                i = index + 1;
            }
            else
            {
                arrLength = index - 1;
            }
        }
        return -1;
    }
}
