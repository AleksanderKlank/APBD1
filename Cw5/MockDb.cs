using System.Collections;

namespace Cw5;

public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public string Color { get; set; }
    public double Weight { get; set; }
    
}

public interface IMockDb
{
    public ICollection<Animal> GetAll();
    public Animal? GetById(int id);
    public void Add(Animal animal);
    public void Edit(int id,Animal animal);
    public void Delete(int id);


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
                Weight = 10
            },
            new Animal()
            {
                Id = 2,
                Color = "brązowy",
                Category = "Pies",
                Name = "Nono",
                Weight = 8
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

    public void Edit(int id, Animal animal)
    {
        int index = _animals.FindIndex(a => a.Id == id);
        if (index != -1)
            _animals[index] = animal;
    }

    public void Delete(int id)
    {
        int index = _animals.FindIndex(a => a.Id == id);
        if (index != -1)
            _animals.RemoveAt(index);
    }
}