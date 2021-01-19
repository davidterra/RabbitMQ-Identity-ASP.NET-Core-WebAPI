using Bogus;
using Bogus.Extensions.Brazil;
using Identity.API;
using Identity.API.Models;
using System.Threading.Tasks;
using Xunit;

namespace IdentityTests
{
    [TestCaseOrderer("IdentityTests.PriorityOrderer", "IdentityTests")]
    [Collection(nameof(IntegrationApiTestsFixtureCollection))]
    public class UserTests
    {
        private readonly IntegrationTestsFixture<Startup> _testsFixture;

        public UserTests(IntegrationTestsFixture<Startup> testsFixture)
        {
            _testsFixture = testsFixture;
        }

        [Fact(DisplayName = "Adicionar um novo usuário"), TestPriority(1)]
        [Trait("Categoria", "Identity API - Novo")]
        public async Task Signup_ShuldBeInSuccess()
        {
            // Arrange
            var faker = new Faker("pt_BR");

            string firstName = faker.Person.FirstName;
            string lastName = faker.Person.LastName;

            var payload = new UserRegister
            {
                Name = $"{firstName} {lastName}",
                Cpf = faker.Person.Cpf(false),
                Email = faker.Internet.Email(firstName, lastName),                
            };

            string pass = faker.Internet.Password(8, false, "", "!Cc1");

            payload.Password = pass;
            payload.PasswordConfirmed = pass;

            // Act

            var postResponse = await _testsFixture.Client.PostAsync("api/signup", payload);

            // Asset

            var responseString = await postResponse.Content.ReadAsStringAsync();

            postResponse.EnsureSuccessStatusCode();

            Assert.Contains("accessToken", responseString);
        }
    }
}
