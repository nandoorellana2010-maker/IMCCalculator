using IMCCalculator.Views;
using Microsoft.Extensions.DependencyInjection;

namespace IMCCalculator;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new IMCCalculatorView());
	}
}