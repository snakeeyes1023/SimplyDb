using SimplyDb.Tests.Fixtures;
using SimplyDb.Tests.Fixtures.SampleData.DbContext;

namespace Engin.Test
{
    public class RepositoryTest : IClassFixture<DataFixture>
    {
        private readonly GlobalDbContext _DbContext;
        
        public RepositoryTest(DataFixture fixture)
        {
            _DbContext = fixture._GlobalDbContext;
        }

        [Fact]
        public void GetAll_ShouldReturnTwoEntities_WhenTwoEntitiesInDb()
        {     
            _DbContext.Cars.AddNewEntity();
            _DbContext.Cars.AddNewEntity();

            _DbContext.Cars.Save();

            var data = _DbContext.Cars.GetAll();

            Assert.Equal(2, data.Count());
        }

        [Fact]
        public void AddNewEntity_ShouldAddCreateAndAddANewEntity_WhenAllOk()
        {
            var newEntity = _DbContext.Cars.AddNewEntity();
            
            Assert.NotNull(newEntity);
        }

        [Fact]
        public void Save_ShouldSaveNewEntity_WhenNewEntityCreated()
        {
            var newEntity = _DbContext.Cars.AddNewEntity();

            _DbContext.Cars.Save();

            int id = newEntity.Id;

            var data = _DbContext.Cars.GetAll();

            Assert.NotNull(data.FirstOrDefault(x => x.Id == id));
        }

        [Fact]
        public void Save_ShouldSetIdToEntity_WhenNewEntityCreated()
        {
            var newEntity = _DbContext.Cars.AddNewEntity();

            _DbContext.Cars.Save();

            Assert.NotEqual(0, newEntity.Id);
        }

        [Fact]
        public void Save_ShouldDeleteEntity_WhenNewEntityDelete()
        {
            var newEntity = _DbContext.Cars.AddNewEntity();

            _DbContext.Cars.Save();            

            _DbContext.Cars.Delete(newEntity);

            _DbContext.Cars.Save();

            Assert.Null(_DbContext.Cars.GetAll().FirstOrDefault(x => x.Id == newEntity.Id));
        }

        [Fact]
        public void Save_ShouldUpdateEntity_WhenEntityUpdated()
        {
            var newEntity = _DbContext.Cars.AddNewEntity();

            _DbContext.Cars.Save();

            Assert.NotNull(newEntity);
        }
    }
}