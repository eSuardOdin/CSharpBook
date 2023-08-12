int[] arr = new int[] {1,9,2,8,3,7,4,6,5};

ProceduralSort(arr);
var test = QuerySort(arr);
foreach(var item in test) Console.WriteLine(item);
IEnumerable<int> ProceduralSort(int[] array)
{
    List<int> result = new List<int>();
    foreach (int item in array)
    {
        if(item % 2 == 0) 
        {
            result.Add(item*2); 
        }
    }
    result.Sort();
    return result;
}

IEnumerable<int> QuerySort(int[] arr) => 
        from elmt in arr
        where elmt % 2 == 0
        orderby elmt
        select elmt*2;
