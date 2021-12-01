using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Library;
using Handlers;

namespace Ucu.Poo.TelegramBot
{
    /// <summary>
    /// Un programa que implementa un bot de Telegram.
    /// </summary>
    public class Program
    {
        // La instancia del bot.
        private static TelegramBotClient Bot;

        private static string Token = "2084958009:AAHpP2r7z0q7rgouWVpJur5302Jm_kFRha0";

        private static IHandler firstHandler;

        /// <summary>
        /// Punto de entrada al programa.
        /// </summary>
        public static void Main()
        {
            Bot = new TelegramBotClient(Token);
            
            firstHandler =
                new HelloHandler(
                new InfoUsuarioHandler(
                new CancelHandler(
                new GoodByeHandler(
                new BuscarHandler(
                new BuscarUbiHandler(
                new AdminInvitationHandler(
                new StartHandler(
                new AddAdminHandler(
                new BuscarClasificHandler(
                new HelpHandler(
                new AddPalabraClaveHandler(
                new Registro(
                new AddHabilitacionHandler(
                new PublicarOfertaHandler(
                new MisPublicacionesHandler(
                new AnadirCompradorHandler(
                new HistorialUsuarioHandler(null)
                )))))))))))))))));

            var cts = new CancellationTokenSource();

            Contenedor contenedor = Contenedor.Instancia;
            string deserializaradmin = System.IO.File.ReadAllText(@"..\..\Listas_Json\ListaAdmin.Json");
            string deserializarhabilitacion = System.IO.File.ReadAllText(@"..\..\Listas_Json\ListaHabilitacion.Json");
            string deserializarrubro = System.IO.File.ReadAllText(@"..\..\Listas_Json\ListaRubro.Json");
            string deserializarclasificacion = System.IO.File.ReadAllText(@"..\..\Listas_Json\ListaClasificacion.Json");
            string deserializaroferta = System.IO.File.ReadAllText(@"..\..\Listas_Json\ListaOferta.Json");
            string deserializaremprendedor = System.IO.File.ReadAllText(@"..\..\Listas_Json\ListaEmprendedor.Json");
            string deserializarempresa = System.IO.File.ReadAllText(@"..\..\Listas_Json\ListaEmpresa.Json");
            string deserializarinvitado = System.IO.File.ReadAllText(@"..\..\Listas_Json\ListaInvitados.Json");
            contenedor.Deserializar( deserializarhabilitacion, deserializarrubro, deserializarclasificacion, deserializaremprendedor, deserializarempresa, deserializaradmin, deserializarinvitado, deserializaroferta);

            // Comenzamos a escuchar mensajes. Esto se hace en otro hilo (en background). El primer método
            // HandleUpdateAsync es invocado por el bot cuando se recibe un mensaje. El segundo método HandleErrorAsync
            // es invocado cuando ocurre un error.
            Bot.StartReceiving(
                new DefaultUpdateHandler(HandleUpdateAsync, HandleErrorAsync),
                cts.Token
            );

            //=========================================
            // Lineas utiles para probar nuestro código:
            //=========================================
            // para añadir emprendedor (Poner ID de usuario y emprendedor)
            // contenedor.AddEmprendedor("user", emprendedor)
            
            // Para añadir empresa (Poner ID del usuario y instancia de empresa)
            // contenedor.AddEmpresa("user", empresa)

            // Para añadir invitados (Poner ID del usuario)
            //contenedor.AddInvitado("user");


            // Este es el setup que tenemos para las ofertas
            /*
            Rubro testRubro = new Rubro("Tecnologia", "Software", "Programacion");
            Habilitacion unit = new Habilitacion("UNIT", "9001");
            Clasificacion testClasifciacion = new Clasificacion("Reciclable", "se puede reciclar");
            Busqueda buscador = Busqueda.Instancia;
            Habilitacion msp = new Habilitacion("MSP", "msp");
            Rubro rubro = new Rubro("Forestal", "Leñeria", "Recursos");
            Rubro rubro2 = new Rubro("Tecnologia", "Leñeria", "Recursos");
            Emprendedor emprendedor = new Emprendedor("Gaston", rubro, "San Ramon", "Ruta 12", "Emprendimiento");
            Empresa maderaslr = new Empresa("Madera SRL", rubro, "San Bautista", "Ruta 6");
            Empresa maderaslr2 = new Empresa("Madera SRL", rubro, "San Bautista", "Ruta 6");
            Clasificacion madera = new Clasificacion("Madera", "Roble Oscuro");
            Oferta uno = new Oferta("Madera Para Reciclar", maderaslr, "San", "Bautista", "madera", madera, 1, "Tonelada", 5000, 0, DateTime.Parse("11/11/2021"));
            contenedor.AddOferta(uno);
            Oferta dos = new Oferta("Madera Prohibida", maderaslr, "San", "Bautista", "madera", madera, 100, "Kilos", 4000, 0, DateTime.Parse("11/11/2021"));
            contenedor.AddOferta(dos);
            contenedor.AddClasificacion(madera);
            //uno.AddHabilitacion(msp);
            contenedor.AddHabilitacion(unit);
            emprendedor.AddHabilitacion(msp);
            contenedor.AddRubro(rubro);
            contenedor.AddRubro(rubro2);
            contenedor.AddHabilitacion(msp);
            

            //emprendedor.ID = "1234";
            //contenedor.AddInvitado("1454175798");
            //uno.FechaVenta = DateTime.Parse("15/10/2021");
            //emprendedor.AddToRegister(uno);
            //contenedor.AddEmprendedor("1234",emprendedor);
            //Añadir emprendedor (Poner ID de usuario y emprendedor)

            //contenedor.AddEmpresa("1454175798",maderaslr); //Rafa
            //maderaslr.ID="1454175798"; //Rafa
            //Añadir Empresa (Poner ID de usuario y emprendedor)
            contenedor.AddEmpresa("1599425094",maderaslr); // Empresa Guille
            //Añadir emprendedor (Poner ID de usuario y emprendedor)
            //contenedor.AddEmprendedor("1599425094",emprendedor); // Emprendedor Guille 
            */

            Console.WriteLine($"Bot is up!");

            // Esperamos a que el usuario aprete Enter en la consola para terminar el bot.
            Console.ReadLine();
            contenedor = Contenedor.Instancia;
            contenedor.Serializar();
                System.IO.File.WriteAllText(@"..\..\Listas_Json\ListaEmprendedor.Json", contenedor.jsonemprendedor);
                System.IO.File.WriteAllText(@"..\..\Listas_Json\ListaOferta.Json", contenedor.jsonoferta);
                System.IO.File.WriteAllText(@"..\..\Listas_Json\ListaRubro.Json", contenedor.jsonrubro);
                System.IO.File.WriteAllText(@"..\..\Listas_Json\ListaHabilitacion.Json", contenedor.jsonhabilitacion);
                System.IO.File.WriteAllText(@"..\..\Listas_Json\ListaClasificacion.Json", contenedor.jsonclasificacion);
                System.IO.File.WriteAllText(@"..\..\Listas_Json\ListaEmpresa.Json", contenedor.jsonempresa);
                System.IO.File.WriteAllText(@"..\..\Listas_Json\ListaAdmin.Json", contenedor.jsonadmin);
                System.IO.File.WriteAllText(@"..\..\Listas_Json\ListaInvitados.Json", contenedor.jsoninvitado);
            // Terminamos el bot.
            cts.Cancel();
        }

        /// <summary>
        /// Maneja las actualizaciones del bot (todo lo que llega), incluyendo mensajes, ediciones de mensajes,
        /// respuestas a botones, etc. En este ejemplo sólo manejamos mensajes de texto.
        /// </summary>
        public static async Task HandleUpdateAsync(Update update, CancellationToken cancellationToken)
        {
            try
            {
                // Sólo respondemos a mensajes de texto
                if (update.Type == UpdateType.Message)
                {
                    await HandleMessageReceived((new TelegramMSGadapter(update.Message)));
                }
            }
            catch(Exception e)
            {
                await HandleErrorAsync(e, cancellationToken);
            }
        }

        /// <summary>
        /// Maneja los mensajes que se envían al bot.
        /// </summary>
        /// <param name="message">El mensaje recibido</param>
        /// <returns></returns>
        private static async Task HandleMessageReceived(IMessage message)
        {
            Console.WriteLine($"Received a message from {message.ID} saying: {message.Text}");

            string response = string.Empty;

            firstHandler.Handle(message, out response);

            if (!string.IsNullOrEmpty(response))
            {
                await Bot.SendTextMessageAsync(message.ID, response);
            }
        }

        /// <summary>
        /// Manejo de excepciones. Por ahora simplemente la imprimimos en la consola.
        /// </summary>
        public static Task HandleErrorAsync(Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(exception.Message);
            return Task.CompletedTask;
        }
    }
}