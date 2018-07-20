using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using System;
using Android.Views;

namespace CalculaJuros
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        EditText edtValor;
        TextView txtTaxa;
        TextView txtValorParcela;
        //Button btnRecalcular;
         

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "Main" layout resource
            SetContentView(Resource.Layout.activity_main);

            edtValor = FindViewById<EditText>(Resource.Id.valor);

            txtTaxa = FindViewById<TextView>(Resource.Id.txtTaxa);

            txtValorParcela = FindViewById<TextView>(Resource.Id.txtValorParcela);

            //btnRecalcular = FindViewById<Button>(Resource.Id.btnRecalcular);

            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner);

            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.parcela_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;

            

        }
       
        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            Spinner spinner = (Spinner)sender;

            var value = spinner.GetItemAtPosition(e.Position);
            string myValue = value.ToString();
            double tax = 0;
            double resultado = 0;

            string valorDigitado = edtValor.Text;
            
            bool verificaValor = int.TryParse(valorDigitado, out int result);

            double valor = 0;
            valor = Convert.ToDouble(result);
                        
            CalculaValores(myValue,  tax,  resultado, valor);             
        
        }

        public void CalculaValores(string myValue, double tax,  double resultado, double valor)
        {
            if (myValue == "12")
            {

                tax = 0.02;
                txtTaxa.Text = tax.ToString() + "  % ";
                resultado = valor * (1 + (tax * 12.0)) / 12;        

            }
            else if (myValue == "24")
            {

                tax = 0.02;
                txtTaxa.Text = tax.ToString() + "  % ";
                resultado = valor * (1 + (tax * 24.0)) / 24;            

            }
            else if (myValue == "36")
            {

                tax = 0.04;
                txtTaxa.Text = tax.ToString();
                resultado = valor * (1 + (tax * 36.0)) / 36;
          
            }
            else if (myValue == "48")
            {

                tax = 0.04;
                txtTaxa.Text = tax.ToString() + "  % ";
                resultado = valor * (1 + (tax * 48.0)) / 48;                

            }
            else if (myValue == "50")
            {

                tax = 0.06;
                txtTaxa.Text = tax.ToString() + "  % ";
                resultado = valor * (1 + (tax * 50.0)) / 50;            

            }

            else if (myValue == "62")
            {

                tax = 0.06;
                txtTaxa.Text = tax.ToString() + "  % ";
                resultado = valor * (1 + (tax * 62.0)) / 62;           

            }

            string valorCorrigido = resultado.ToString("0.00");
            txtValorParcela.Text = "R$  " + valorCorrigido.ToString();
        }


    }
}

