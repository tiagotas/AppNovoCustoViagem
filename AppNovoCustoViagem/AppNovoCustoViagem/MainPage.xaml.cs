using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppNovoCustoViagem
{
    public partial class MainPage : ContentPage
    {
        private App PropriedadesApp;

        public MainPage()
        {
            InitializeComponent();

            PropriedadesApp = (App)Application.Current;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new ListaPedagios());

            } catch(Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "OK");
            }

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                int nro_pedagio = PropriedadesApp.ListaPedagios.Count;

                PropriedadesApp.ListaPedagios.Add(new Model.Pedagio()
                {
                    NumeroPedagio = nro_pedagio + 1,
                    Valor = Convert.ToDecimal(txt_valor_pedagio.Text)
                });

                DisplayAlert("Deu certo!", "Pedágio adicionado.", "OK");

                txt_valor_pedagio.Text = "";
            }
            catch (Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "OK");
            }
        }

        private void Button_Clicked_Calcular(object sender, EventArgs e)
        {
            try
            {
                decimal distancia = Convert.ToDecimal(txt_distancia.Text);
                decimal consumo = Convert.ToDecimal(txt_consumo.Text);
                decimal preco_combustivel = Convert.ToDecimal(txt_valor_combustivel.Text);

                // Calculando o quanto o carro gasta
                decimal gasto_veiculo = (distancia / consumo) * preco_combustivel;

                // Usando expressão lambda calculamos o custo (somatório) de todos os pedágios
                decimal custo_pedagios = PropriedadesApp.ListaPedagios.Sum(item => item.Valor);

                decimal custo_viagem = gasto_veiculo + custo_pedagios;

                string mensagem = string.Format(
                    "Sua viagem de {0} até {1} custará {2}",
                    txt_origem.Text,
                    txt_destino.Text,
                    custo_viagem.ToString("C")
                );

                DisplayAlert("Custo da Viagem", mensagem, "OK");

            }
            catch (Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "OK");
            }

        }

        private async void Button_Clicked_Limpar(object sender, EventArgs e)
        {
            try
            {
                bool confirm = await DisplayAlert("Tem Certeza?", "Limpar todos os dados", "OK", "Cancelar");

                if (confirm)
                {
                    PropriedadesApp.ListaPedagios.Clear();

                    txt_origem.Text = "";
                    txt_destino.Text = "";
                    txt_distancia.Text = "";
                    txt_consumo.Text = "";
                    txt_valor_combustivel.Text = "";
                    txt_valor_pedagio.Text = "";
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }
    }
}
