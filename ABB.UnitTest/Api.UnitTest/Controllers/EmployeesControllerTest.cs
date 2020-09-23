using ABB.Api.Controllers.v1;
using ABB.Application.Models.v1.Employee;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ABB.UnitTest.Api.UnitTest.Controllers
{
    public class EmployeesControllerTest
    {
        private readonly EmployeesController sut;
        private readonly Mock<IMediator> mockMediator;
        public EmployeesControllerTest()
        {
            mockMediator = new Mock<IMediator>();
            sut = new EmployeesController(mockMediator.Object);
        }
        [Fact]
        public async Task GetEmployeesTest_ShouldReturn_Ok()
        {

            var employees = new List<GetAllEmployeesResponseModel> { new GetAllEmployeesResponseModel { Id = "1", FirstName = "Gautam", LastName = "Nayak", Department = "IT" } };
            mockMediator.Setup(x => x.Send(It.IsAny<GetAllEmployeesRequestModel>(), default)).ReturnsAsync(employees);
            var response = await sut.Get(It.IsAny<GetAllEmployeesRequestModel>()).ConfigureAwait(false);
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }
        [Fact]
        public async Task GetEmployeesTest_ShouldReturn_NotFound()
        {

            mockMediator.Setup(x => x.Send(It.IsAny<GetAllEmployeesRequestModel>(), default)).ReturnsAsync(It.IsAny<List<GetAllEmployeesResponseModel>>());
            var response = await sut.Get(It.IsAny<GetAllEmployeesRequestModel>()).ConfigureAwait(false);
            Assert.NotNull(response);
            Assert.IsType<NotFoundResult>(response);
        }
        [Fact]
        public async Task GetEmployeeByIdTest_ShouldReturn_Ok()
        {
            var requestModel = new GetEmployeeByIdRequestModel { Id = "1" };
            var employee = new GetEmployeeByIdResponseModel { Id = "1", FirstName = "Gautam", LastName = "Nayak", Department = "IT" };
            mockMediator.Setup(x => x.Send(requestModel, default)).ReturnsAsync(employee);
            var response = await sut.GetEmployeeById(requestModel).ConfigureAwait(false);
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }
        [Fact]
        public async Task GetEmployeeByIdTest_ShouldReturn_NotFound()
        {

            mockMediator.Setup(x => x.Send(It.IsAny<GetEmployeeByIdResponseModel>(), default)).ReturnsAsync(It.IsAny<GetEmployeeByIdResponseModel>());
            var response = await sut.Get(It.IsAny<GetAllEmployeesRequestModel>()).ConfigureAwait(false);
            Assert.NotNull(response);
            Assert.IsType<NotFoundResult>(response);
        }
        [Fact]
        public async Task CreateEmployeeTest_ShouldReturn_Ok()
        {
            mockMediator.Setup(x => x.Send(It.IsAny<CreateEmployeeRequestModel>(), default)).ReturnsAsync("1");
            var response = await sut.Post(It.IsAny<CreateEmployeeRequestModel>()).ConfigureAwait(false);
            Assert.NotNull(response);
            Assert.IsType<CreatedAtRouteResult>(response);
        }
        [Fact]
        public async Task DeleteEmployeeTest_ShouldReturn_Ok()
        {
            mockMediator.Setup(x => x.Send(It.IsAny<DeleteEmployeeRequestModel>(), default));
            var response = await sut.Delete(It.IsAny<DeleteEmployeeRequestModel>()).ConfigureAwait(false);
            Assert.NotNull(response);
            Assert.IsType<NoContentResult>(response);
        }
    }
}
