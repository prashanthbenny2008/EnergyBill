namespace EnergyBill;

using global::EnergyBill.Controllers;
using Xunit;

public class EnergyBillControllerTest{
    
    [Fact]
    public void PassValueTest(){
        var SystemUnderTask = new EnergyBillController();
        var get_result = SystemUnderTask.Get();
        Assert.Equal("success", get_result);
    }


    [Theory]
    [InlineData(1000, "success", 280, 800)]
    [InlineData(10000, "success", 2260, 2600)]
    [InlineData(4001, "success", 940.22, 800.3)]
    [InlineData(4500, "success", 1050, 950)]
    [InlineData(6000, "success", 1380, 1400)]
    [InlineData(0.5, "success", 60.11, 800)]
    [InlineData(-100, "error", -2.2, 800)]
    public void PassEneryTariffTest(float inputConsumption, string ResponseMessage, float ExpectedBasic, float ExpectedPackage){
        var sut = new EnergyBillController();
        var TariffResult = sut.GetRates(inputConsumption);
        if (TariffResult?.Data != null) {
            Assert.Equal(ExpectedBasic, TariffResult.Data.basicTariff); 
            Assert.Equal(ExpectedPackage, TariffResult.Data.PackagedTariff);
        }
        else {
            Assert.Equal(ResponseMessage, TariffResult?.Status);
        }
    }

}