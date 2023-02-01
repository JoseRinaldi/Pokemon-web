using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pokemon_web
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Seguridad.sesionActiva(Session["Trainee"])) ;
            //{
            //    Response.Redirect("Login.aspx", false);
            //}
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.sesionActiva(Session["Trainee"]))
                    {
                        Trainee user = (Trainee)Session["Trainee"];
                        txtEmail.Text = user.Email;
                        txtEmail.ReadOnly = true;
                        txtNombre.Text = user.Nombre;
                        txtApellido.Text = user.Apellido;
                        txtFechaNacimiento.Text = user.FechaNacimiento.ToString("yyyy-MM-dd");
                        if (!string.IsNullOrEmpty(user.ImagenPerfil))
                            imgNuevoPerfil.ImageUrl = "~/ImagesProfile/" + user.ImagenPerfil;
                    }
                }
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                TraineeNegocio negocio= new TraineeNegocio();   
                Trainee user= (Trainee)Session["Trainee"];
                
                if (txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./ImagesProfile/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");
                    user.ImagenPerfil = "perfil-" + user.Id + ".jpg";
                }
                
                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;   
                user.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);

                negocio.actualizar(user);

                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/ImagesProfile/" + user.ImagenPerfil;

            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
            }
        }
    }
}