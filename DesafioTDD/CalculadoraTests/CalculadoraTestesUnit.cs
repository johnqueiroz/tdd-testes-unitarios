using Calculadora.Services;

namespace CalculadoraTests;

public class CalculadoraTests
{

    private CalculadoraImp _calc;

    public CalculadoraTests(){
        string data = "03/10/2023";
       _calc = new CalculadoraImp(data);
    }

    [Theory]
    [InlineData(1,2,3)]
    [InlineData(5,5,10)]
    public void TesteParaSomaDeNumeros(int numero1, int numero2, int resultadoEsperado)
    {
        //Act
        int resultadoCalc = _calc.Somar(numero1, numero2);

        //Assert
        Assert.Equal(resultadoEsperado, resultadoCalc);
    }


    [Theory]
    [InlineData(2,1,1)]
    [InlineData(5,5,0)]
    public void TesteParaSubtracaoDeNumeros(int numero1, int numero2, int resultadoEsperado)
    {
        //Act
        int resultadoCalc = _calc.Subtrair(numero1, numero2);

        //Assert
        Assert.Equal(resultadoEsperado, resultadoCalc);
    }


    [Theory]
    [InlineData(2,1,2)]
    [InlineData(5,5,25)]
    public void TesteParaMultiplicacaoDeNumeros(int numero1, int numero2, int resultadoEsperado)
    {
        //Act
        int resultadoCalc = _calc.Multiplicar(numero1, numero2);

        //Assert
        Assert.Equal(resultadoEsperado, resultadoCalc);
    }


    [Theory]
    [InlineData(4,2,2)]
    [InlineData(5,5,1)]
    public void TesteParaDivisaoDeNumeros(int numero1, int numero2, int resultadoEsperado)
    {
        //Act
        int resultadoCalc = _calc.Dividir(numero1, numero2);

        //Assert
        Assert.Equal(resultadoEsperado, resultadoCalc);
    }



    [Fact]
    public void TesteDivisaoPorZero(){
        
        //Arrange
        int numero1 = 3;
        int numero2 = 0;

        //Act //Assert
        Assert.Throws<DivideByZeroException>(
            () => _calc.Dividir(numero1, numero2)
            );
    }



    [Fact]
    public void TestarSeOHistoricoNaoEstaVazio()
    {
        //Act
      
        _calc.Somar(1,2);
        _calc.Somar(6,2);
        _calc.Somar(5,2);
        _calc.Somar(5,2);
        _calc.Somar(2,2);

        var resultadoCalc = _calc.Historico();

        //Assert
        Assert.NotEmpty(resultadoCalc);
        Assert.Equal(3, resultadoCalc.Count);
    }


    [Fact]
    public void TestarHistoricoVazio(){

        Assert.Throws<ArgumentOutOfRangeException>(
            () => _calc.Historico()
        );
    }


    [Theory]
    [InlineData(10,1)]
    [InlineData(100,10)]
    public void TestarConversaoMilimetroCentimetro(int milimetro, int centimetroEsperado){

        //Act//Assert
        Assert.Equal(centimetroEsperado, _calc.ConversaoMilimetrosCentimetros(milimetro));
    }

    
}