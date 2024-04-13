using System.Collections;

namespace Cw5;

public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public string Color { get; set; }
    public double Weight { get; set; }
    public List<Visit> Visits { get; set; }

}

public class Visit
{
    public DateTime DateOfVisit { get; set; }
    //public Animal VisitingAnimal { get; set; }
    public String Description { get; set; }
    public String Price { get; set; }
}


public interface IMockDb
{
    public ICollection<Animal> GetAll();
    public Animal? GetById(int id);
    public void Add(Animal animal);
    public bool Edit(int id,Animal animal);
    public bool Delete(int id);

    public List<Visit> GetVisits(int id);
    public bool AddVisit(Visit visit, int id);


}

public class MockDb : IMockDb
{
    private List<Animal> _animals;
    public MockDb()
    {
        _animals = new List<Animal>()
        {
            new Animal()
            {
                Id = 1,
                Color = "czarny",
                Category = "Kot",
                Name = "Luna",
                Weight = 10,
                Visits = new List<Visit>()
                {
                    new Visit()
                    {
                        DateOfVisit = new DateTime(2023, 3, 12),
                        Description = "Wizyta kontrolna",
                        Price = "80 zł",
                    }
                }
            },
            new Animal()
            {
                Id = 2,
                Color = "brązowy",
                Category = "Pies",
                Name = "Nono",
                Weight = 8,
                Visits = new List<Visit>()
                {
                    new Visit()
                    {
                        DateOfVisit = new DateTime(2023, 4, 1),
                        Description = "Wizyta kontrolna",
                        Price = "80 zł",
                    }
                }
            }
        };
    }
    
    public ICollection<Animal> GetAll()
    {
        return _animals;
    }

    public Animal? GetById(int id)
    {
        return _animals.FirstOrDefault(animal => animal.Id == id);
    }

    public void Add(Animal animal)
    {
        _animals.Add(animal);
    }

    public bool Edit(int id, Animal animal)
    {
        int index = _animals.FindIndex(a => a.Id == id);
        if (index != -1)
        {
             _animals[index] = animal;
             return true;
        }

        return false;
    }

    public bool Delete(int id)
    {
        int index = _animals.FindIndex(a => a.Id == id);
        if (index != -1)
        {
            _animals.RemoveAt(index);
            return true;
        }

        return false;
    }

    public List<Visit> GetVisits(int id)
    {
        int index = _animals.FindIndex(a => a.Id == id);
        if (index != -1)
        {
            return _animals[index].Visits;
        }

        return null;
    }

    public bool AddVisit(Visit visit, int id)
    {
        int index = _animals.FindIndex(a => a.Id == id);
        if (index != -1)
        {
            _animals[index].Visits.Add(visit);
            return true;
        }

        return false;
    }
}