using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Library;
using Handlers;
using System.IO;

namespace Ucu.Poo.TelegramBot
{
    /// <summary>
    /// Un programa que implementa un bot de Telegram.
    /// </summary>
    public class Program
    {
        // La instancia del bot.
        private static TelegramBotClient Bot;

        // El token provisto por Telegram al crear el bot.
        //
        // *Importante*:
        // Para probar este ejemplo, crea un bot nuevo y reemplaza este token por el de tu bot.
        private static string Token = "2106731481:AAEFbR6815bETThGqpF4T3L9yjAbi4zwQDI";

        private static IHandler firstHandler;

        /// <summary>
        /// Punto de entrada al programa.
        /// </summary>
        public static void Main()
        {
            Bot = new TelegramBotClient(Token);
            /*
            Rubro testRubro = new Rubro("Tecnologia", "Software", "Programacion");
            Habilitacion unit = new Habilitacion("UNIT", "9001");
            Clasificacion testClasifciacion = new Clasificacion("Reciclable", "se puede reciclar");
            Contenedor db = Contenedor.Instancia;
            Busqueda buscador = Busqueda.Instancia;
            Habilitacion msp = new Habilitacion("MSP", "msp");
            Rubro rubro = new Rubro("Forestal", "Leñeria", "Recursos");
            Rubro rubro2 = new Rubro("Tecnologia", "Leñeria", "Recursos");
            Emprendedor emprendedor = new Emprendedor("Gaston", rubro, "San Ramon", "Ruta 12", "Emprendimiento");
            Empresa maderaslr = new Empresa("Madera SRL", rubro, "San Bautista", "Ruta 6");
            Empresa maderaslr2 = new Empresa("Madera SRL", rubro, "San Bautista", "Ruta 6");
            Clasificacion madera = new Clasificacion("Madera", "Roble Oscuro");
            Oferta uno = new Oferta("Madera Para Reciclar", maderaslr, "San", "Bautista", "madera", madera, 1, "Tonelada", 5000, 0, DateTime.Parse("11/11/2021"));
            db.AddOferta(uno);
            Oferta dos = new Oferta("Madera Prohibida", maderaslr, "San", "Bautista", "madera", madera, 100, "Kilos", 4000, 0, DateTime.Parse("11/11/2021"));
            db.AddOferta(dos);
            db.AddClasificacion(madera);
            //uno.AddHabilitacion(msp);
            db.AddHabilitacion(unit);
            emprendedor.AddHabilitacion(msp);
            db.AddRubro(rubro);
            db.AddRubro(rubro2);
            db.AddHabilitacion(msp);
            

            //emprendedor.ID = "1234";
            //db.AddInvitado("1454175798");
            //uno.FechaVenta = DateTime.Parse("15/10/2021");
            //emprendedor.AddToRegister(uno);
            //db.AddEmprendedor("1234",emprendedor);
            //Añadir emprendedor (Poner ID de usuario y emprendedor)

            //db.AddEmpresa("1454175798",maderaslr); //Rafa
            //maderaslr.ID="1454175798"; //Rafa
            //Añadir Empresa (Poner ID de usuario y emprendedor)
            db.AddEmpresa("1599425094",maderaslr); //Guille
            //Añadir emprendedor (Poner ID de usuario y emprendedor)
            //db.AddEmprendedor("1599425094",emprendedor); //Guille
            */
            
            /*
            Oferta oferta1 = new Oferta("oferta1", maderaslr, "San", "Bautista", "madera", madera, 1, "Tonelada", 5000, 0, DateTime.Parse("11/11/2021"));
            oferta1.AddComprador("5",DateTime.Parse("24/11/2021"));
            maderaslr.AddToRegister(oferta1);

            Oferta oferta2 = new Oferta("NOmostrar", maderaslr, "San", "Bautista", "madera", madera, 1, "Tonelada", 5000, 0, DateTime.Parse("11/11/2021"));
            oferta2.AddComprador("5",DateTime.Parse("02/11/2021"));
            maderaslr.AddToRegister(oferta2);

            Oferta oferta3 = new Oferta("oferta3", maderaslr, "San", "Bautista", "madera", madera, 1, "Tonelada", 5000, 0, DateTime.Parse("11/11/2021"));
            oferta3.AddComprador("5",DateTime.Parse("21/11/2021"));
            maderaslr.AddToRegister(oferta3);
            
            Oferta oferta4 = new Oferta("oferta4", maderaslr, "San", "Bautista", "madera", madera, 1, "Tonelada", 5000, 5, DateTime.Parse("11/11/2021"));
            oferta4.AddComprador("1454175798",DateTime.Parse("21/11/2021"));
            maderaslr.AddToRegister(oferta4);

            Oferta oferta5 = new Oferta("NOmostrar", maderaslr, "San", "Bautista", "madera", madera, 1, "Tonelada", 5000, 5, DateTime.Parse("23/01/2021"));
            oferta5.AddComprador("0000",DateTime.Parse("21/11/2021"));
            maderaslr.AddToRegister(oferta5);

            Collection<Oferta> rest = maderaslr.BuscarEnHistorial(DateTime.Parse("20/11/2021"));
            Console.WriteLine(rest.Count);
            foreach(Oferta ofertaz in rest )
            {
                Console.WriteLine(ofertaz.Nombreoferta);
            }
            */
            
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
                new AñadirCompradorHandler(
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

            Rubro testRubro = new Rubro("Tecnologia", "Software", "Programacion");
            Habilitacion unit = new Habilitacion("UNIT", "9001");
            Clasificacion testClasifciacion = new Clasificacion("Reciclable", "se puede reciclar");
            Contenedor db = Contenedor.Instancia;
            Busqueda buscador = Busqueda.Instancia;
            Habilitacion msp = new Habilitacion("MSP", "msp");
            Rubro rubro = new Rubro("Forestal", "Leñeria", "Recursos");
            Rubro rubro2 = new Rubro("Tecnologia", "Leñeria", "Recursos");
            Emprendedor emprendedor = new Emprendedor("Gaston", rubro, "San Ramon", "Ruta 12", "Emprendimiento");
            Empresa maderaslr = new Empresa("Madera SRL", rubro, "San Bautista", "Ruta 6");
            Empresa maderaslr2 = new Empresa("Madera SRL", rubro, "San Bautista", "Ruta 6");
            Clasificacion madera = new Clasificacion("Madera", "Roble Oscuro");
            Oferta uno = new Oferta("Madera Para Reciclar", maderaslr, "San", "Bautista", "madera", madera, 1, "Tonelada", 5000, 0, DateTime.Parse("11/11/2021"));
            db.AddOferta(uno);
            Oferta dos = new Oferta("Madera Prohibida", maderaslr, "San", "Bautista", "madera", madera, 100, "Kilos", 4000, 0, DateTime.Parse("11/11/2021"));
            db.AddOferta(dos);
            db.AddClasificacion(madera);
            db.AddHabilitacion(unit);
            emprendedor.AddHabilitacion(msp);
            db.AddRubro(rubro);
            db.AddRubro(rubro2);
            db.AddHabilitacion(msp);
            //db.AddEmpresa("1599425094",maderaslr);
            
            // Comenzamos a escuchar mensajes. Esto se hace en otro hilo (en background). El primer método
            // HandleUpdateAsync es invocado por el bot cuando se recibe un mensaje. El segundo método HandleErrorAsync
            // es invocado cuando ocurre un error.
            Bot.StartReceiving(
                new DefaultUpdateHandler(HandleUpdateAsync, HandleErrorAsync),
                cts.Token
            );

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
        /// Lo único que hacemos por ahora es escuchar 3 tipos de mensajes:
        /// - "hola": responde con texto
        /// - "chau": responde con texto
        /// - "foto": responde con una foto
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