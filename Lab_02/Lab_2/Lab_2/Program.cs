using Lab_2;

UsdCourse.Current = await UsdCourse.GetUsdCourseAsync();

List<Fruit> fruits = new List<Fruit>();

for (int i = 0; i < 15; i++)
{
    fruits.Add(Fruit.Create());
}

var filtered = fruits.Where(f => f.IsSweet == true);
foreach(var x in filtered)
{
    Console.WriteLine(x.ToString());
}