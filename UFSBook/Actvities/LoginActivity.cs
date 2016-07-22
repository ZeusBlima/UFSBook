using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;

namespace UFSBook
{
    [Activity(MainLauncher = true)]
    public partial class LoginActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {            
            base.OnCreate(bundle);            
            SetContentView(Resource.Layout.Login);
            InitializeComponents();
           
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {

            await Sleep(1000);
            StartActivity(new Intent(this, typeof(MainActivity)));
        }
    }

    public partial class LoginActivity : Activity
    {
        public static async Task Sleep(int ms)
        {
            await Task.Delay(ms);
        }

        //Criação dos Controles
        EditText edtEmail;
        EditText edtSenha;
        CheckBox chkLembrar;
        Button btnLogin;
        

        private void InitializeComponents()
        {
            InitializeControls();
            InitializeEvents();
        }

        private void InitializeControls()
        {
            edtEmail = FindViewById<EditText>(Resource.Id.edtEmail);
            edtSenha = FindViewById<EditText>(Resource.Id.edtSenha);
            chkLembrar = FindViewById<CheckBox>(Resource.Id.chkLembrar);
            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
        }

        private void InitializeEvents()
        {
            btnLogin.Click += BtnLogin_Click;
        }
    }
}

