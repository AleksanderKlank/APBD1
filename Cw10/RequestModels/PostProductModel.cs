using Cw10.Models;

namespace Cw10.RequestModels;

public class PostProductModel
{
    public string ProductName { get; set; }
    
    public double ProductWeight { get; set; }
   
    public double ProductWidth { get; set; }
    
    public double ProductHeight { get; set; }
  
    public double ProductDepth { get; set; }
    
    public List<int> ProductCategories { get; set; }
}