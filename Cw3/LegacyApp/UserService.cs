using System;

namespace LegacyApp
{
    
    public class UserService
    {
        private IClientRepository _clientRepository;
        private IUserCreditService _userCreditService;

        public UserService(IClientRepository clientRepository, IUserCreditService userCreditService)
        {
            _clientRepository = clientRepository;
            _userCreditService = userCreditService;
        }

        [Obsolete]
        public UserService()
        {
            _clientRepository = new ClientRepositoryAdapter(new ClientRepository());
            _userCreditService = new UserCreditServiceAdapter(new UserCreditService());
        }
        
        
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!NameValidation(firstName, lastName) || !EmailValidation(email) || !AgeValidation(dateOfBirth))
            {
                return false;
            }
            
            var client = _clientRepository.GetById(clientId);
            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };
            
            //Podaje user jako referencje, żeby mieć pewność, że hasCreditLimit i creditLimit zostana zapisane w obiekcie
            if (!CreditLimitValidation(ref user, client))
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }

        public bool NameValidation(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool EmailValidation(string email)
        {
            if (!email.Contains("@") && !email.Contains("."))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool AgeValidation(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

            if (age < 21)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CreditLimitValidation(ref User user, Client client)
        {
            if (client.Type == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }
            else if (client.Type == "ImportantClient")
            {
                int creditLimit = _userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                creditLimit = creditLimit * 2;
                user.CreditLimit = creditLimit;
            }
            else
            {
                user.HasCreditLimit = true;
                int creditLimit = _userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth); 
                user.CreditLimit = creditLimit;
            }

            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        
        
    }
}