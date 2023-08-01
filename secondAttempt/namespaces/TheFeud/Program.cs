using McDroid;
using IField;
using McPig = McDroid.Pig;
using IPig = IField.Pig;


var mPig = new McPig();
var iPig = new IPig();
var sheep = new Sheep();
var cow = new Cow();

Console.WriteLine($"{mPig.GetType()}   {iPig.GetType()}   {sheep.GetType()}   {cow.GetType()}");