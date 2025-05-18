using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;
using Moq;

namespace IdeaManager.Tests.Services
{
    public class IdeaServiceTests
    {
        [Fact] 
        public async Task Test_AjouterIdeeValide()
        {
            // (mocks)
            var fauxRepo = new Mock<IRepository<Idea>>();
            var fauxUow = new Mock<IUnitOfWork>();
            fauxUow.Setup(u => u.IdeaRepository).Returns(fauxRepo.Object);

            // inject les mocks dans le service
            var service = new IdeaService(fauxUow.Object);

           
            var idee = new Idea
            {
                Title = "Idée test",
                Description = "Une idée de test"
            };

            // Call la méthode de service
            await service.SubmitIdeaAsync(idee);

           
            fauxRepo.Verify(r => r.AddAsync(It.Is<Idea>(i => i.Title == "Idée test")), Times.Once);
            fauxUow.Verify(u => u.SaveChangesAsync(), Times.Once);
        }

        [Fact] 
        public async Task Test_RefuserIdeeSansTitre()
        {
           
            var fauxUow = new Mock<IUnitOfWork>();
            var service = new IdeaService(fauxUow.Object);

            
            var ideeInvalide = new Idea
            {
                Title = "", 
                Description = "Sans titre"
            };

            // Check l'Exeption
            var erreur = await Assert.ThrowsAsync<ArgumentException>(() =>
                service.SubmitIdeaAsync(ideeInvalide));

            // Assert 
            Assert.Equal("Le titre est obligatoire.", erreur.Message);
        }

    }
}
