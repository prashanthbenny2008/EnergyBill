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
    [InlineData(1000, 280, 800)]
    [InlineData(10000, 2260, 2600)]
    [InlineData(4001, 940.22, 800.3)]
    [InlineData(4500, 1050, 950)]
    [InlineData(6000, 1380, 1400)]
    public void PassEneryTariffTest(float inputConsumption, float ExpectedBasic, float ExpectedPackage){
        var sut = new EnergyBillController();
        var TariffResult = (EnergyBill)sut.GetRates(inputConsumption);
        Assert.Equal(ExpectedBasic, TariffResult.basicTariff); 
        Assert.Equal(ExpectedPackage, TariffResult.PackagedTariff);
    }
}