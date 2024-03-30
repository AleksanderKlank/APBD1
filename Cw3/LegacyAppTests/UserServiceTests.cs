using LegacyApp;

namespace LegacyAppTests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_Should_Return_False_When_Email_Without_Dot_And_At()
    {
        //Arrange
        string firstName = "John";
        string lastName = "Wick";
        DateTime dateOfBirth = new DateTime(1973, 2, 1);
        int clientId = 5;
        string email = "wick";
        var service = new UserService();
        
        //Act
        bool result = service.AddUser(firstName, lastName, email, dateOfBirth, clientId);
        
        //Assert
        Assert.Equal(false,result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_FirstName_Is_Null()
    {
    //Arrange
    string firstName = "";
    string lastName = "Wick";
    DateTime dateOfBirth = new DateTime(1973, 2, 1);
    int clientId = 5;
    string email = "wick@wp.pl";
    var service = new UserService();
        
    //Act
    bool result = service.AddUser(firstName, lastName, email, dateOfBirth, clientId);
        
    //Assert
    Assert.Equal(false,result);
    } 
    
    [Fact]
    public void AddUser_Should_Return_False_When_LastName_Is_Null()
    {
        //Arrange
        string firstName = "John";
        string lastName = "";
        DateTime dateOfBirth = new DateTime(1973, 2, 1);
        int clientId = 5;
        string email = "wick@wp.pl";
        var service = new UserService();
        
        //Act
        bool result = service.AddUser(firstName, lastName, email, dateOfBirth, clientId);
        
        //Assert
        Assert.Equal(false,result);
    }  
    
    [Fact]
    public void AddUser_Should_Return_False_When_Age_Is_Less_Than_21()
    {
        //Arrange
        string firstName = "John";
        string lastName = "Wick";
        DateTime dateOfBirth = new DateTime(2010, 2, 1);
        int clientId = 5;
        string email = "wick@wp.pl";
        var service = new UserService();
        
        //Act
        bool result = service.AddUser(firstName, lastName, email, dateOfBirth, clientId);
        
        //Assert
        Assert.Equal(false,result);
    } 


}