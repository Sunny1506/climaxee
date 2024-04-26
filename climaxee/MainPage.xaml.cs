using System.Text.Json;
using System.Text.Json.Serialization;

namespace climaxee;

public partial class MainPage : ContentPage
{
	const string Url="https://api.hgbrasil.com/weather?woeid=455927&key=1d275343";
	
     Resposta resposta;
	public MainPage()
	{
		InitializeComponent();
		AtualizaTempo();
	}

	void PreencherTela()
	{
		labelTemperatura.Text = resposta.results.temp.ToString();
		labelDescrição.Text =  resposta.results.description;
		labelCidade.Text =  resposta.results.city;
		labelChuva.Text =  resposta.results.rain.ToString();
		labelUmidade.Text =  resposta.results.humidity.ToString();
		labelAmanhecer.Text =  resposta.results.sunrise;
		labelAnoitecer.Text =  resposta.results.sunset;
		labelForça.Text =  resposta.results.wind_speedy.ToString();
		labelDireção.Text =  resposta.results.wind_direction.ToString();
		labelFasedalua.Text =  resposta.results.moon_phase;
		forecast.ItemsSource = resposta.results.forecast;
	   
		if( resposta.results.currently == "dia")
		{
			if( resposta.results.rain >=10)
				ImgBackground.Source="diachuva.jpg";
			else if ( resposta.results.temp <=15)
				ImgBackground.Source="diafrio.jpg";
			else 
				ImgBackground.Source="diasol.jpg";
	  }
	  else
	  {
			if ( resposta.results.rain >=10)
				ImgBackground.Source="noitechuva.jpg";
			else if ( resposta.results.cloudiness <=15)
				ImgBackground.Source="noitenublada.jpg";
			else 
				ImgBackground.Source="noiteestrelada.jpg";
	  }

	}
	async void AtualizaTempo()
	{
		try
		{
			var httpClient= new HttpClient();
			var response= await httpClient.GetAsync(Url);
			if(response.IsSuccessStatusCode)
			{
				var content= await response.Content.ReadAsStringAsync();
				resposta= JsonSerializer.Deserialize<Resposta>(content);
			}
		}
		catch(Exception e)
		{
			System.Diagnostics.Debug.WriteLine(e);
		}
		
		PreencherTela();
	
	}
}

