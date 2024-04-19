namespace climaxee;

public partial class MainPage : ContentPage
{
	int count = 0;
     Results resultado;
	public MainPage()
	{
		InitializeComponent();
		TestaLayout();
		PreencherTela();
	}
  void TestaLayout()
	{
    resultado = new Results();
		resultado.temp=23;
		resultado.description="tempo frio";
		resultado.rain=10;
		resultado.city="Apucarana,PR";
		resultado.humidity=38;
		resultado.sunrise="06:20";
		resultado.sunset="18:2";
		resultado.wind_speedy=3;
		resultado.wind_direction=395;
		resultado.moon_phase="nova";
		resultado.cloudness=10;
		resultado.currently="dia";
	}
	void PreencherTela()
	{
		labelTemperatura.Text = resultado.temp.ToString();
		labelDescrição.Text = resultado.description;
		labelCidade.Text = resultado.city;
		labelChuva.Text = resultado.rain.ToString();
		labelUmidade.Text = resultado.humidity.ToString();
		labelAmanhecer.Text = resultado.sunrise;
		labelAnoitecer.Text = resultado.sunset;
		labelForça.Text = resultado.wind_speedy.ToString();
		labelDireção.Text = resultado.wind_direction.ToString();
		labelFasedalua.Text = resultado.moon_phase;
	   
		if(resultado.currently == "dia")
		{
			if(resultado.rain >=10)
				ImgBackground.Source="diachuva.jpg";
			else if (resultado.temp <=15)
				ImgBackground.Source="diafrio.jpg";
			else 
				ImgBackground.Source="diasol.jpg";
	  }
	  else
	  {
			if (resultado.rain >=10)
				ImgBackground.Source="noitechuva.jpg";
			else if (resultado.cloudness <=15)
				ImgBackground.Source="noitenublada.jpg";
			else 
				ImgBackground.Source="noiteestrelada.jpg";
	  }

	}
}


