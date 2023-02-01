using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace Pokemon_web
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Trainee user= new Trainee();
            TraineeNegocio traineeNegocio= new TraineeNegocio();
            EmailService emailService = new EmailService();

            user.Email = txtEmail.Text;
            user.Pass = txtPass.Text;
            //int Id = traineeNegocio.insertarNuevo(user); asi se usaba el registro antes pero no guardeba el usuario teniamos q loguearnos de nuevo
            user.Id = traineeNegocio.insertarNuevo(user);//aqui se ve el autologin
            Session.Add("Trainee", user);

            emailService.armarCorreo(user.Email, "Bienvenida nuevo trainnee", "Te damos la bienvenida a pokedex.....");
            emailService.enviarEmail();
            Response.Redirect("Default.aspx", false);
            


        }
    }
}