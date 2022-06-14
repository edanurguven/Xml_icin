using System.Data;
using System.Xml;


XmlDocument doc = new XmlDocument();
doc.Load(@"D:\MYAZ206-main\MYAZ206-main\data_with_xml_format.xml");

XmlNode node = doc.FirstChild;

//XmlNodeList prop = node.SelectNodes("Items");

var lstitems = new List<Employee>();

foreach (XmlNode item in node)
{
    var e = new Employee();
    e.FullName = item.ChildNodes[0].FirstChild.Value;
    e.Id = Convert.ToInt32(item.ChildNodes[1].FirstChild.Value);
    e.Salary = Convert.ToDouble(item.ChildNodes[2].FirstChild.Value);
    e.Title = item.ChildNodes[3].FirstChild.Value;



    //items Temp = new items();
    //Temp.AssignInfo(item);
    lstitems.Add(e);
}

var array = lstitems.ToArray();

MergeSort.Sort(array);

Employee ep = new Employee() { Salary = 529.00 };


int index = BinarySearch.Search<Employee>(array, ep);
Console.WriteLine(index);

Console.ReadLine();




public class Employee : IComparable<Employee>
{
    public string FullName { get; set; }
    public int Id { get; set; }
    public double Salary { get; set; }
    public string Title { get; set; }

    public int CompareTo(Employee? other)
    {

        Employee deger = other as Employee;
        int sonuc = 0;
        if (deger != null)
        {
            sonuc = Salary.CompareTo(deger.Salary);
        }
        return sonuc;
    }


    public override bool Equals(object? obj)
    {
        return CompareTo((Employee)obj) == 0;
    }
}



public static class MergeSort
{
    public static void Sort<T>(T[] arr) where T : IComparable<T>
    {
        Sort(arr, 0, arr.Length - 1);
    }
    private static void Sort<T>(T[] Array, int left, int right)
        where T : IComparable<T>
    {
        if (left < right)
        {
            int middle = (left + right) / 2;

            Sort(Array, left, middle);
            Sort(Array, middle + 1, right);
            Merge(Array, left, middle, right);
        }
    }
    private static void Merge<T>(T[] Array, int left, int middle, int right)
        where T : IComparable<T>
    {
        T[] leftArray = new T[middle - left + 1];
        T[] rightArray = new T[right - middle];

        System.Array.Copy(Array, left, leftArray, 0, middle - left + 1);
        System.Array.Copy(Array, middle + 1, rightArray, 0, right - middle);

        int i = 0;
        int j = 0;
        for (int k = left; k < right + 1; k++)
        {
            if (i == leftArray.Length)
            {
                Array[k] = rightArray[j];
                j++;
            }
            else if (j == rightArray.Length)
            {
                Array[k] = leftArray[i];
                i++;
            }
            else if (leftArray[i].CompareTo(rightArray[j]) < 0)
            {
                Array[k] = leftArray[i];
                i++;
            }
            else
            {
                Array[k] = rightArray[j];
                j++;
            }
        }
    }
}
public static class BinarySearch
{
    public static int Search<T>(T[] array, T key) where T : IComparable<T>
    {
        return searchh(array, 0, array.Length - 1, key);
    }

    private static int searchh<T>(T[] array, int i, int j, T key) where T : IComparable<T>
    {
        while (true)
        {

            if (i == j)
            {
                if (array[i].Equals(key))
                {
                    return i;
                }
                return -1;
            }

            int middle = (i + j) / 2;

            if (array[middle].Equals(key))
            {
                return middle;
            }
            if (array[middle].CompareTo(key) >= 1)   //buyukte 1,eşitte 0,küçükte -1  döner    
            {
                j = middle;
                continue;
            }
            i = middle + 1;
        }

    }
}