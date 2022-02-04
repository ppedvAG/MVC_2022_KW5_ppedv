#nullable disable
namespace MVCAndRazorSamples.Models
{
    
    public class Person
    {
        
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public Person()
        {
            Name = default!;
            Age = default!;
            Email = default!;   
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            Email = default!;
        }
    }
}
