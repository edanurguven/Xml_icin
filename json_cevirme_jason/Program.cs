using Newtonsoft.Json;
var arr = new Employee[1000];

using (System.IO.StreamReader _StreamReader = new System.IO.StreamReader(@"D:\MYAZ206-main\MYAZ206-main\data_with_json_format.json"))
{
    string jsonData = _StreamReader.ReadToEnd();
    List<Employee> listEmployee = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Employee>>(jsonData);
    for (int i = 0; i < listEmployee.Count; i++)
    {
        arr[i] = listEmployee[i];
    }
}

foreach (var item in arr)
    Console.WriteLine(item);

Console.ReadKey();


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
